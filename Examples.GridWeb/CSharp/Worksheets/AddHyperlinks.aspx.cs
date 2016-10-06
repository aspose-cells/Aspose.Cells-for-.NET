using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Aspose.Cells.GridWeb;
using Aspose.Cells.GridWeb.Data;
using System.Collections.Specialized;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Worksheets
{
    public partial class AddHyperlinks : System.Web.UI.Page
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
            AddCellCommandHyperlinks();
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
            // ExStart:AddImageHyperlinks
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
            // ExEnd:AddImageHyperlinks
        }

        private void AddCellCommandHyperlinks()
        {
            // ExStart:AddCellCommandHyperlinks
            // Accessing the reference of the worksheet that is currently active
            WebWorksheet sheet = GridWeb1.WebWorksheets[GridWeb1.ActiveSheetIndex];

            // Adding hyperlink to the worksheet
            Hyperlink link1 = sheet.Hyperlinks.AddHyperlink("B8");

            // Setting the action type of the link to CellCommand
            link1.ActionType = HyperlinkActionType.CellCommand;

            // Setting the cell command for the link
            link1.CellCommand = "Click";

            // Setting tool tip of the hyperlink
            link1.ToolTip = "Click Here";

            // Setting URL of the button image that will be displayed as hyperlink
            link1.ImageUrl = "../Images/button.jpg";

            // Resize the row to display image nicely
            sheet.Cells.SetRowHeight(7, 30);
            // ExEnd:AddCellCommandHyperlinks
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            InitData();
        }

        protected void GridWeb1_SaveCommand(object sender, EventArgs e)
        {
            // Generates a temporary file name.
            string filename = Session.SessionID + "_out_.xls";

            string path = (this.Master as Site).GetDataDir() + "\\Worksheets\\";

            // Saves to the file.
            this.GridWeb1.SaveToExcelFile(path + filename);

            // Sents the file to browser.
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment; filename=" + filename);
            Response.WriteFile(path + filename);
            Response.End();   
        }

        // ExStart:HandleCellCommandHyperlinkEvent
        // Event Handler for CellCommand event
        protected void GridWeb1_CellCommand(object sender, Aspose.Cells.GridWeb.CellEventArgs e)
        {
            // Checking the CellCommand of the hyperlink
            if (e.Argument.Equals("Click"))
            {
                // Accessing the reference of the worksheet that is currently active
                WebWorksheet sheet = GridWeb1.WebWorksheets[GridWeb1.ActiveSheetIndex];

                // Adding value to "C8" cell
                sheet.Cells["C8"].PutValue("Cell Command Hyperlink Clicked");

                // Resize the column to display message nicely
                sheet.Cells.SetColumnWidth(2, 250);
            }
        }
        // ExEnd:HandleCellCommandHyperlinkEvent
    }
}
