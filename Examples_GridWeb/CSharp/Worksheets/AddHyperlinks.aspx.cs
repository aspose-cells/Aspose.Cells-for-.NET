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
            // If first visit this page init GridWeb1 
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
            // Accessing the reference of the worksheet that is currently active
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Adds a text hyperlink that goes to Aspose site and opens in new window
            int linkIndex = sheet.Hyperlinks.Add("B1", "http://www.aspose.com");
            GridHyperlink link1 = sheet.Hyperlinks[linkIndex];
            link1.Target = "_blank";

            // Setting text and tool tip of the hyperlink
            link1.TextToDisplay = "Aspose";
            link1.ScreenTip = "Open Aspose Web Site in new window";
             
            // Adding hyperlink to the worksheet to open in parent window
            linkIndex = sheet.Hyperlinks.Add("B2", "http://www.aspose.com/docs/display/cellsnet/Aspose.Cells.GridWeb");
            GridHyperlink link2 = sheet.Hyperlinks[linkIndex];
            link2.Target = "_parent";

            // Setting text and tool tip of the hyperlink
            link2.TextToDisplay = "Aspose.Grid Docs";
            link2.ScreenTip = "Open Aspose.Grid Docs in parent window";
            // ExEnd:AddTextHyperlinks
        }

        private void AddImageHyPerlinks()
        {
            // ExStart:AddImageHyperlinks
            // Accessing the reference of the worksheet that is currently active
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Adding hyperlink to the worksheet
            int linkIndex = sheet.Hyperlinks.Add("B5", "http://www.aspose.com");
            GridHyperlink link1 = sheet.Hyperlinks[linkIndex];
            link1.Target = "_blank";

            // Setting Image URL and tool tip of hyperlink
            link1.ImageURL = "../Images/Aspose.Banner.gif";
            link1.ScreenTip = "Open Aspose Web Site in new window";

            // Adding hyperlink to the worksheet
            linkIndex = sheet.Hyperlinks.Add("B6", "http://www.aspose.com/docs/display/cellsnet/Aspose.Cells.GridWeb");
            GridHyperlink link2 = sheet.Hyperlinks[linkIndex];
            link2.Target = "_blank";

            // Setting URL, tool tip and alt text of hyperlink
            link2.ImageURL = "../Images/Aspose.Grid.gif";
            link2.ScreenTip = "Open Aspose.Grid Docs in new window";
            link2.AltText = "Open Aspose.Grid Docs in new window";

            // Resize the rows to display image nicely
            sheet.Cells.SetRowHeight(4, 40);
            sheet.Cells.SetRowHeight(5, 40);
            // ExEnd:AddImageHyperlinks
        }

        private void AddCellCommandHyperlinks()
        {
            // ExStart:AddCellCommandHyperlinks
            // Accessing the reference of the worksheet that is currently active
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Adding hyperlink to the worksheet
            int linkIndex = sheet.Hyperlinks.Add("B8", "");
            GridHyperlink link1 = sheet.Hyperlinks[linkIndex];

            // Setting the cell command, tool tip and image URL for the hyperlink
            link1.Command = "Click";
            link1.ScreenTip = "Click Here";
            link1.ImageURL = "../Images/button.jpg";

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
            string filename = Session.SessionID + "_out.xls";

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
                GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

                // Adding value to "C8" cell
                sheet.Cells["C8"].PutValue("Cell Command Hyperlink Clicked");

                // Resize the column to display message nicely
                sheet.Cells.SetColumnWidth(2, 250);
            }
        }
        // ExEnd:HandleCellCommandHyperlinkEvent
    }
}
