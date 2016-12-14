using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.KnowledgeBase.KnownIssues
{
    public partial class HTTPCompression : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            string path = (this.Master as Site).GetDataDir();

            // ExStart:HTTPCompression
            FileStream fs1 = new FileStream(path + "\\KnowledgeBase\\SampleData.xlsx", FileMode.Open, FileAccess.Read);
            byte[] data1 = new byte[fs1.Length];
            fs1.Read(data1, 0, data1.Length);

            this.Response.ContentType = "application/xls";
            Response.AddHeader("content-disposition", "inline;  filename=book1.xls");
            Response.BinaryWrite(data1);
            Response.End();
            // ExEnd:HTTPCompression
        }
    }
}