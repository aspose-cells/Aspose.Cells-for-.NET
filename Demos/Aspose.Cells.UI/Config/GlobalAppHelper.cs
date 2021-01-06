using System.Web;
using System.Xml;
using System.Web.Caching;
using System.IO;
using System.Linq;

namespace Aspose.Cells.UI.Config
{
    /// <summary>
    /// Acts as a helper class for the website's global.asax file
    /// </summary>
    public class GlobalAppHelper
    {
        public GlobalAppHelper(HttpContext hc, string sessionId, string language)
        {
            AsposeToolsContext.atcc = new AsposeToolsContext(hc); // sync the context

            var resourcesFile = hc.Server.MapPath("~/App_Data/resources_EN" + ".xml"); // reference all the extra info and resources files       
            if (language.Trim() != "")
            {
                var filPath = hc.Server.MapPath("~/App_Data/resources_" + language + ".xml");
                if (File.Exists(filPath))
                {
                    resourcesFile = filPath;
                }
            }

            // Load info from all these files into the cache
            InitResources(resourcesFile, sessionId);
        }

        /// <summary>
        /// Reads/parses the resources file and loads them into the cache in form of a dictionary
        /// </summary>
        /// <param name="resourcesFile"></param>
        /// <param name="sessionId"></param>
        private static void InitResources(string resourcesFile, string sessionId)
        {
            sessionId = "R" + sessionId;
            if (AsposeToolsContext.Current.Cache[sessionId] != null) return;
            // Added to solve the file not found problem, the wait is one time only when the application initializes or associated files are modified
            //System.Threading.Thread.Sleep(500);
            var xd = new XmlDocument();
            // TextWriter tr = (TextWriter)File.CreateText("F:\\assets\\my.log");tr.WriteLine(ResourcesFile);
            // tr.WriteLine(File.Exists(ResourcesFile)); tr.Close();
            if (resourcesFile.Trim() != "")
            {
                xd.Load(resourcesFile);
            }

            var xl = xd.SelectNodes("resources/res"); // use xpath to reach the res tag within resources
            var resources = xl.Cast<XmlNode>().ToDictionary(n => n.Attributes["name"].Value, n => n.InnerText);

            // Add this dictionary into the cache with no expiration and associate a reload method in case of file change
            AsposeToolsContext.Current.Cache.Add(
                sessionId,
                resources,
                new CacheDependency(resourcesFile),
                Cache.NoAbsoluteExpiration,
                Cache.NoSlidingExpiration,
                CacheItemPriority.NotRemovable,
                delegate { InitResources(resourcesFile, sessionId); });
        }
    }
}