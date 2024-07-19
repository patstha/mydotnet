namespace hellolib;

public class MyCleaner(ILogger<MyCleaner> logger, HttpClient httpClient)
{
    public async Task<string> CleanUrlAsync(string url)
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
            string finalRedirectUrl = await FollowRedirectsAsync(url);

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

    private async Task<string> FollowRedirectsAsync(string url)
    {
        HttpResponseMessage response = await httpClient.GetAsync(url);
        while (response.StatusCode == System.Net.HttpStatusCode.Redirect || response.StatusCode == System.Net.HttpStatusCode.MovedPermanently)
        {
            string redirectUrl = response.Headers.Location.ToString();
            if (!Uri.IsWellFormedUriString(redirectUrl, UriKind.Absolute))
            {
                Uri baseUri = new(url);
                redirectUrl = new Uri(baseUri, redirectUrl).ToString();
            }
            try
            {
                response = await httpClient.GetAsync(redirectUrl);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Exception in method {Method}", nameof(FollowRedirectsAsync));
                return ExtractFromAddress(redirectUrl);
            }
        }
        return response.RequestMessage.RequestUri.ToString();
    }

    private static string ExtractFromAddress(string url)
    {
        Uri uri = new(url);
        var queryParams = HttpUtility.ParseQueryString(uri.Query);

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
