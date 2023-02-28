using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Articles
{
    public partial class SpecifySessionStorePath : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                LoadData();
                GridWeb1.SessionMode = SessionMode.File;
                // ExStart:SpecifySessionStorePath
                GridWeb1.SessionStorePath = Server.MapPath("~")+ "/tmpstorecache/session";
                // ExEnd:SpecifySessionStorePath
            }
        }

        private void LoadData()
        {
            // Gets the web application's path.
            string path = (this.Master as Site).GetDataDir();

           

            // Load the file
            GridWeb1.ImportExcelFile(path + "\\Articles\\Data.xlsx");
        }
    }
}