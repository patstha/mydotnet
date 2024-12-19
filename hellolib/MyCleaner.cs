using System.Collections.Specialized;
using System.Net;
using System.Threading;

namespace hellolib;

public class MyCleaner(ILogger<MyCleaner> logger, HttpClient httpClient)
{
    public async Task<string> CleanUrlAsync(string url, CancellationToken token = default)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return "";
        }

        string extractedUrl = ExtractFromAddress(url);
        if (extractedUrl != url)
        {
            return RemoveQueryParameters(extractedUrl);
        }

        try
        {
            string finalRedirectUrl = await FollowRedirectsAsync(url, token);

            if (finalRedirectUrl.Contains("amazon.com"))
            {
                finalRedirectUrl = RemoveAmazonExtraPathSegments(finalRedirectUrl);
            }

            return RemoveQueryParameters(finalRedirectUrl);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error processing URL: {Url}", url);
            return null;
        }
    }

    private static string RemoveQueryParameters(string url)
    {
        Uri uri = new(url);
        return uri.GetLeftPart(UriPartial.Path);
    }
    
    private async Task<string> FollowRedirectsAsync(string url, CancellationToken token = default)
    {
        HttpResponseMessage response = await httpClient.GetAsync(url, token);
        while (response.StatusCode == HttpStatusCode.Redirect || response.StatusCode == HttpStatusCode.MovedPermanently)
        {
            string redirectUrl = response.Headers.Location?.ToString() ?? "";
            if (!Uri.IsWellFormedUriString(redirectUrl, UriKind.Absolute))
            {
                Uri baseUri = new(url);
                redirectUrl = new Uri(baseUri, redirectUrl).ToString();
            }
            response = await httpClient.GetAsync(redirectUrl, token);
        }
        return response.RequestMessage?.RequestUri?.ToString() ?? "";
    }
    
    private static string ExtractFromAddress(string url)
    {
        Uri uri = new(url);
        NameValueCollection queryParams = HttpUtility.ParseQueryString(uri.Query);

        string uParam = queryParams.Get("u");
        if (uParam != null)
        {
            return HttpUtility.UrlDecode(uParam);
        }

        string urlParam = queryParams.Get("url");
        if (urlParam != null)
        {
            return HttpUtility.UrlDecode(urlParam);
        }

        string returnUrl = queryParams.Get("return");
        if (returnUrl != null)
        {
            string decodedUrl = HttpUtility.UrlDecode(returnUrl);
            string finalUrl = HttpUtility.ParseQueryString(new Uri(decodedUrl).Query).Get("u");
            if (finalUrl != null)
            {
                return HttpUtility.UrlDecode(finalUrl);
            }
        }

        return url;
    }

    private static string RemoveAmazonExtraPathSegments(string url)
    {
        Uri uri = new(url);
        string[] segments = uri.Segments;
        if (segments.Length > 3 && segments[1].TrimEnd('/') == "gp" && segments[2].TrimEnd('/') == "product")
        {
            return $"{uri.Scheme}://{uri.Host}{segments[0]}{segments[1]}{segments[2]}{segments[3]}";
        }

        return uri.GetLeftPart(UriPartial.Path);
    }
}