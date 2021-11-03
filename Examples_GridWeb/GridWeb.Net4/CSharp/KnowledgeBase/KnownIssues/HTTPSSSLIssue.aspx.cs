using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.KnowledgeBase.KnownIssues
{
    public partial class HTTPSSSLIssue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack&&!GridWeb1.IsPostBack)
            {
                string path = (this.Master as Site).GetDataDir();

                this.GridWeb1.ImportExcelFile(path + "\\KnowledgeBase\\SampleData.xlsx");
            }

        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {               
           

            // ExStart:SSLIssue
            // Saves file to memory
            MemoryStream stream = new MemoryStream();
            this.GridWeb1.SaveToExcelFile(stream, Data.GridSaveFormat.Excel2003);
            

            Response.ContentType = "application/vnd.ms-excel";

            // This is same as OpenInExcel option
            Response.AddHeader("content-disposition", "attachment;  filename=book1.xls");

            // This is same as OpenInBrowser option
            // response.AddHeader("content-disposition", "inline;  filename=book1.xls");

            Response.BinaryWrite(stream.ToArray());
            // ExEnd:SSLIssue
        }
    }
}