using System.Web;

namespace hellolib;

public class MyCleaner
{
    public static string CleanUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return "";
        }
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
        return null;
    }
}
