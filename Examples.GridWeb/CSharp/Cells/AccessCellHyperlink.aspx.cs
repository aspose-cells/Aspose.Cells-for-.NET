using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Cells
{
    public partial class AccessCellHyperlink : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && !GridWeb1.IsPostBack)
            {
                InitGridWeb();
            }
            else
            {
                Label1.Text = "";
            }
        }

        private void InitGridWeb()
        {
            // Accessing the reference of the worksheet that is currently active
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Adds a text hyperlink that gos to Aspose site and opens in new window
            int linkIndex = sheet.Hyperlinks.Add("A1", "http://www.aspose.com");
            GridHyperlink link1 = sheet.Hyperlinks[linkIndex];

            link1.Target = "_blank";

            // Setting text of the hyperlink
            link1.TextToDisplay = "Aspose";

            // Setting tool tip of the hyperlink
            link1.ScreenTip = "Open Aspose Web Site in new window";

            // Adding hyperlink to the worksheet to open in parent window
            linkIndex = sheet.Hyperlinks.Add("A2", "http://www.aspose.com/docs/display/cellsnet/Aspose.Cells.GridWeb");
            GridHyperlink link2 = sheet.Hyperlinks[linkIndex];

            link2.Target = "_parent";

            // Setting text of the hyperlink
            link2.TextToDisplay = "Aspose.Grid Docs";

            // Setting tool tip of the hyperlink
            link2.ScreenTip = "Open Aspose.Grid Docs in parent window";
        }

        protected void btnAccessCellHyperlink_Click(object sender, EventArgs e)
        {
            // ExStart:AccessHyperlink
            // Access first worksheet of gridweb and cell A1
            GridWorksheet sheet = GridWeb1.WorkSheets[0];
            GridCell cellA1 = sheet.Cells["A1"];

            // Access hyperlink of cell A1 if it contains any
            GridHyperlink cellHyperlink = sheet.Hyperlinks.GetHyperlink(cellA1);

            if (cellHyperlink == null)
            {
                Label1.Text = "Cell A1 does not have any hyperlink";
            }
            else
            {
                // Access hyperlink properties e.g. address
                string hyperlinkAddress = cellHyperlink.Address;
                Label1.Text = "Address of hyperlink in cell A1 :" + hyperlinkAddress;
            }
            // ExEnd:AccessHyperlink
        }
    }
}