using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Worksheets
{
    public partial class ManageHyperlinks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if first visit this page init GridWeb1 
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                InitData();
            }
        }

        private void InitData()
        {
            // Gets the web application's path.
            string path = (this.Master as Site).GetDataDir();

            string fileName = path + "\\Worksheets\\Hyperlink.xls";

            // Clears datasheets first.
            GridWeb1.WorkSheets.Clear();
            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);

            AddTextHyperlinks();
            AddImageHyPerlinks();     
        }

        private void AddTextHyperlinks()
        {
            // ExStart:AddTextHyperlinks
            //Accessing the reference of the worksheet that is currently active
            WebWorksheet sheet = GridWeb1.WebWorksheets[GridWeb1.ActiveSheetIndex];

            // Adds a text hyperlink that gos to Aspose site and opens in new window
            Hyperlink link1 = sheet.Hyperlinks.AddHyperlink("B1");
            link1.Target = "_blank";

            // Setting text of the hyperlink
            link1.Text = "Aspose";

            // Setting URL of the hyperlink
            link1.Url = "http://www.aspose.com";

            // Setting tool tip of the hyperlink
            link1.ToolTip = "Open Aspose Web Site in new window";

            // Adding hyperlink to the worksheet to open in parent window
            Hyperlink link2 = sheet.Hyperlinks.AddHyperlink("B2");
            link2.Target = "_parent";

            // Setting text of the hyperlink
            link2.Text = "Aspose.Grid Docs";

            // Setting URL of the hyperlink
            link2.Url = "http://www.aspose.com/docs/display/cellsnet/Aspose.Cells.GridWeb";

            // Setting tool tip of the hyperlink
            link2.ToolTip = "Open Aspose.Grid Docs in parent window";
            // ExEnd:AddTextHyperlinks
        }

        private void AddImageHyPerlinks()
        {
            // Accessing the reference of the worksheet that is currently active
            WebWorksheet sheet = GridWeb1.WebWorksheets[GridWeb1.ActiveSheetIndex];

            // Adding hyperlink to the worksheet
            Hyperlink link1 = sheet.Hyperlinks.AddHyperlink("B5");
            link1.Target = "_blank";

            // Setting URL of the image that will be displayed as hyperlink
            link1.ImageUrl = "../Images/Aspose.Banner.gif";

            // Setting URL of the hyperlink
            link1.Url = "http://www.aspose.com";

            // Setting tool tip of the hyperlink
            link1.ToolTip = "Open Aspose Web Site in new window";

            // Resize the row to display image nicely
            sheet.Cells.SetRowHeight(4, 40);

            // Adding hyperlink to the worksheet
            Hyperlink link2 = sheet.Hyperlinks.AddHyperlink("B6");
            link2.Target = "_blank";

            // Setting URL of the image that will be displayed as hyperlink
            link2.ImageUrl = "../Images/Aspose.Grid.gif";

            // Setting URL of the hyperlink
            link2.Url = "http://www.aspose.com/docs/display/cellsnet/Aspose.Cells.GridWeb";

            // Setting tool tip of the hyperlink
            link2.ToolTip = "Open Aspose.Grid Docs in new window";

            // Setting text of the hyperlink. It will be displayed if image is not displayed due to some reason
            link2.Text = "Open Aspose.Grid Docs Page in new window";
        }

        protected void btnUpdateHyperlinks_Click(object sender, EventArgs e)
        {
            // ExStart:AccessHyperlinks
            // Accessing the reference of the worksheet that is currently active
            WebWorksheet sheet = GridWeb1.WebWorksheets[GridWeb1.ActiveSheetIndex];

            // Accessing a specific cell that contains hyperlink
            WebCell cell = sheet.Cells["B1"];
                        
            // Accessing the hyperlink from the specific cell
            Hyperlink link = sheet.Hyperlinks.GetHyperlink(cell);

            if (link != null)
            {
                // Modifying the text of hyperlink
                link.Text = "Aspose.Blogs";

                // Modifying the URL of hyperlink
                link.Url = "http://www.aspose.com/Community/Blogs";
            }            
            // ExEnd:AccessHyperlinks
        }

        protected void btnRemoveHyperlinks_Click(object sender, EventArgs e)
        {
            // ExStart:RemoveHyperlink
            // Accessing the reference of the worksheet that is currently active
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Accessing a specific cell that contains hyperlink
            GridCell cell = sheet.Cells["B1"];

            // Removing hyperlink from the specific cell
            GridWeb1.WebWorksheets[GridWeb1.ActiveSheetIndex].Hyperlinks.RemoveHyperlink(cell);
            // ExEnd:RemoveHyperlink
        }
    }
}