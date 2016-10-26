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
           //Accessing the reference of the worksheet that is currently active
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Adds a text hyperlink that gos to Aspose site and opens in new window
            int linkIndex = sheet.Hyperlinks.Add("B1", "http://www.aspose.com");
            GridHyperlink link1 = sheet.Hyperlinks[linkIndex];

            link1.Target = "_blank";

            // Setting text of the hyperlink
            link1.TextToDisplay = "Aspose";

            // Setting tool tip of the hyperlink
            link1.ScreenTip = "Open Aspose Web Site in new window";
             
            // Adding hyperlink to the worksheet to open in parent window
            linkIndex = sheet.Hyperlinks.Add("B2", "http://www.aspose.com/docs/display/cellsnet/Aspose.Cells.GridWeb");
            GridHyperlink link2 = sheet.Hyperlinks[linkIndex];

            link2.Target = "_parent";

            // Setting text of the hyperlink
            link2.TextToDisplay = "Aspose.Grid Docs";

            // Setting tool tip of the hyperlink
            link2.ScreenTip = "Open Aspose.Grid Docs in parent window";
        }

        private void AddImageHyPerlinks()
        {
            // Accessing the reference of the worksheet that is currently active
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Adding hyperlink to the worksheet
            int linkIndex = sheet.Hyperlinks.Add("B5", "http://www.aspose.com");
            GridHyperlink link1 = sheet.Hyperlinks[linkIndex];
            link1.Target = "_blank";

            // Setting URL of the image that will be displayed as hyperlink
            link1.ImageURL = "../Images/Aspose.Banner.gif";

            // Setting tool tip of the hyperlink
            link1.ScreenTip = "Open Aspose Web Site in new window";

            // Resize the row to display image nicely
            sheet.Cells.SetRowHeight(4, 40);

            // Adding hyperlink to the worksheet
            linkIndex = sheet.Hyperlinks.Add("B6", "http://www.aspose.com/docs/display/cellsnet/Aspose.Cells.GridWeb");
            GridHyperlink link2 = sheet.Hyperlinks[linkIndex];
            link2.Target = "_blank";

            // Setting URL of the image that will be displayed as hyperlink
            link2.ImageURL = "../Images/Aspose.Grid.gif";

            // Setting tool tip of the hyperlink
            link2.ScreenTip = "Open Aspose.Grid Docs in new window";

            // Setting text of the hyperlink. It will be displayed if image is not displayed due to some reason
            //            link2.TextToDisplay = "Open Aspose.Grid Docs Page in new window";
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