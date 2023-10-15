using Aquality.Selenium.Browsers;
using FinalTask.Configurations;
using FinalTask.Constants;

namespace FinalTask.Utilities
{
    public static class BasicAuthUtil
    {
        public static void Authenticate(string username, string password)
        {
            string url = Config.StartUrl;
            string credentials = $"{username}:{password}@";
            string authUrl = url.Insert(url.IndexOf("//") + UrlConstants.DoubleSlashConstant, credentials);
            AqualityServices.Browser.GoTo(authUrl);
        }
    }
}
