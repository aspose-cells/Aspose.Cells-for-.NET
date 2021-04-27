using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Aspose.Cells.UI.Services
{
    public abstract class BaseApiCacheService
    {
        protected static HttpClient HttpClient = new HttpClient();

        protected TV GetCached<TK, TV>(Dictionary<TK, TV> dict, TK key, Func<Task<TV>> refresh)
        {
            lock (dict)
            {
                if (dict.ContainsKey(key)) return dict[key];

                var result = Task.Run(async () => await refresh()).Result;
                dict.Add(key, result);

                return dict[key];
            }
        }

        protected string GetVirtualPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }

            strPath = strPath.Replace("/", "\\");
            if (strPath.StartsWith("\\") || strPath.StartsWith("~"))
            {
                strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
            }

            return System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, strPath);
        }
    }
}