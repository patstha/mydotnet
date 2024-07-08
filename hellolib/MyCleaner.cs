using System.Net.Http;
using System.Threading.Tasks;

namespace hellolib;

public class MyCleaner(ILogger<MyCleaner> logger, HttpClient httpClient)
{
    public async Task<string> CleanUrlAsync(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return "";
        }

        try
        {
            Uri uri = new(url);
            var queryParams = HttpUtility.ParseQueryString(uri.Query);

            // Check for 'u' parameter directly
            string uParam = queryParams.Get("u");
            if (uParam != null)
            {
                return HttpUtility.UrlDecode(uParam);
            }

            // Check for 'url' parameter
            string urlParam = queryParams.Get("url");
            if (urlParam != null)
            {
                return HttpUtility.UrlDecode(urlParam);
            }

            // Check for 'return' parameter
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

            // If no known parameters are found, follow the URL
            HttpResponseMessage response = await httpClient.GetAsync(url);
            string finalRedirectUrl = response.RequestMessage.RequestUri.ToString();

            // Remove extra path segments for amazon.com URLs
            if (finalRedirectUrl.Contains("amazon.com"))
            {
                finalRedirectUrl = RemoveAmazonExtraPathSegments(finalRedirectUrl);
            }

            return finalRedirectUrl;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error processing URL: {Url}", url);
            return null;
        }
    }

    private static string RemoveAmazonExtraPathSegments(string url)
    {
        Uri uri = new(url);
        string[] segments = uri.Segments;
        if (segments.Length > 3 && segments[1].TrimEnd('/') == "gp" && segments[2].TrimEnd('/') == "product")
        {
            // Reconstruct the URL with only the first three segments
            string cleanUrl = $"{uri.Scheme}://{uri.Host}{segments[0]}{segments[1]}{segments[2]}{segments[3]}";
            return cleanUrl;
        }
        return uri.GetLeftPart(UriPartial.Path);
    }
}
