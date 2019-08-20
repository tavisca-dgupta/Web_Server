using System.Collections.Generic;

namespace Webserver
{
    public class WebAppList
    {
        private static Dictionary<string, string> _webApps = new Dictionary<string, string>();
        public WebAppList()
        {
            _webApps.Add("google.com", "C:/WebPages/google");
            _webApps.Add("stackoverflow.com", "C:/WebPages/stackoverflow");
        }
        public string GetRootDirectory(string webBaseUrl)
        {
            return _webApps[webBaseUrl];
        }
        public bool IsWebAppPresent(string webBaseUrl)
        {
            return _webApps.ContainsKey(webBaseUrl);
        }
    }
}
