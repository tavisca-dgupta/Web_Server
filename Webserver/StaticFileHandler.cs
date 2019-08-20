using System;
using System.IO;

namespace Webserver
{
    public class StaticFileHandler : IFileSystem
    {
        public string ResolveVirtualPath(string virtualPath, string rootDirectoryPath, string websiteUrl)
        {
            return virtualPath.Replace(websiteUrl, rootDirectoryPath);
        }

        public string TryGetFile(string filePath)
        {
            string data;
            try
            {
                data = File.ReadAllText(filePath);
            }
            catch (Exception)
            {
                return null;
            }
            return data;
        }
    }
}
