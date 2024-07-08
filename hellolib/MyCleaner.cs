namespace hellolib;

public class MyCleaner(ILogger<MyCleaner> logger)
{
    public string CleanUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return "";
        }

        try
        {
            Uri uri = new(url);
            string returnUrl = HttpUtility.ParseQueryString(uri.Query).Get("return");
            if (returnUrl != null)
            {
                string decodedUrl = HttpUtility.UrlDecode(returnUrl);
                string finalUrl = HttpUtility.ParseQueryString(new Uri(decodedUrl).Query).Get("u");
                if (finalUrl != null)
                {
                    return HttpUtility.UrlDecode(finalUrl);
                }
            }
            else
            {
                string urlParam = HttpUtility.ParseQueryString(uri.Query).Get("url");
                if (urlParam != null)
                {
                    return HttpUtility.UrlDecode(urlParam);
                }

                string uParam = HttpUtility.ParseQueryString(uri.Query).Get("u");
                if (uParam != null)
                {
                    return HttpUtility.UrlDecode(uParam);
                }
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error processing URL: {Url}", url);
        }

        return null;
    }
}
