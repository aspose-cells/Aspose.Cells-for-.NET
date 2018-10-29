using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.Cells.GridWeb.Examples.CSharp
{
    public class Site: System.Web.UI.MasterPage
    {
        public string GetDataDir()
        {
            // Gets the web application's path.
            string path = Server.MapPath("~");

            path = path.Replace("CSharp", "Data");
            path = path.Substring(0, path.LastIndexOf("\\"));

            return path;
        }
    }
}