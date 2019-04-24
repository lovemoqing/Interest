using FileService.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileService.Common
{
    public class Tools
    {
        private readonly SiteConfig _siteConfig;
        public Tools(IOptions<SiteConfig> siteConfig)
        {
            _siteConfig = siteConfig.Value;
        }
        public string GetPath(string currPath)
        {
            string path = _siteConfig.RootPath;
            if (currPath!=null && currPath.Contains(","))
            {
                var res = string.Empty;
                string[] paths = currPath.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in paths)
                {
                    path += "\\" + item;
                }
            }
            return path;
        }
    }
}
