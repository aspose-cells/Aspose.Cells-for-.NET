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

        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {               
            string path = (this.Master as Site).GetDataDir();
            Workbook excel = new Workbook(path + "\\KnowledgeBase\\SampleData.xlsx");

            // ExStart:SSLIssue
            // Saves file to memory
            MemoryStream stream = new MemoryStream();
            excel.Save(stream, SaveFormat.Excel97To2003);

            Response.ContentType = "application/vnd.ms-excel";

            // This is same as OpenInExcel option
            Response.AddHeader("content-disposition", "attachment;  filename=book1.xls");

            // This is same as OpenInBrowser option
            //response.AddHeader( "content-disposition","inline;  filename=book1.xls");

            Response.BinaryWrite(stream.ToArray());
            // ExEnd:SSLIssue
        }
    }
}