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
using Aspose.Cells.GridWeb.Data;
using System.Drawing;
using Aspose.Cells.GridWeb;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Worksheets
{
    public partial class SortData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If first visit, initialize data for GridWeb
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                InitData();
            }
        }

        private void InitData()
        {
            // Gets the web application's path.
            string path = (this.Master as Site).GetDataDir();

            string fileName = path + "\\Worksheets\\Sort.xls";

            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);

            // Creates sorting header style.
            GridTableItemStyle itemStyle = new GridTableItemStyle();
            itemStyle.BorderStyle = BorderStyle.Outset;
            itemStyle.BorderWidth = 2;
            itemStyle.BorderColor = Color.White;
            itemStyle.BackColor = Color.Silver;
            itemStyle.HorizontalAlign = HorizontalAlign.Center;
            itemStyle.VerticalAlign = VerticalAlign.Middle;

            // Creates Hyperlinks Sheet1. Sorts from top to bottom orientation.
            GridHyperlink cellcmd;
            GridCells cells0 = GridWeb1.WorkSheets[0].Cells;
            cells0["A1"].CopyStyle(itemStyle);
            GridHyperlinkCollection ghc = GridWeb1.WorkSheets[0].Hyperlinks;
            int i = ghc.Add("A1", "");
            cellcmd = ghc[i];
            cellcmd.Command = "A1";
            cellcmd.ScreenTip = "Sorts Descending";
            cellcmd.TextToDisplay = "OrderId";

            cells0["B1"].CopyStyle(itemStyle);
            cellcmd = ghc[ghc.Add("B1", "")];
            cellcmd.Command = "B1";
            cellcmd.ScreenTip = "Sorts Ascending";
            cellcmd.TextToDisplay = "Sales Amout";

            cells0["C1"].CopyStyle(itemStyle);
            cellcmd = ghc[ghc.Add("C1", "")];
            cellcmd.Command = "C1";
            cellcmd.ScreenTip = "Sorts Descending";
            cellcmd.TextToDisplay = "Percent of Saler's Total";

            cells0["D1"].CopyStyle(itemStyle);
            cellcmd = ghc[ghc.Add("D1", "")];

            cellcmd.Command = "D1";
            cellcmd.ScreenTip = "Sorts Ascending";
            cellcmd.TextToDisplay = "Percent of Country Total";

            // Creates Hyperlinks Sheet2. Sorts from left to right orientation.
            GridCells cells1 = GridWeb1.WorkSheets[1].Cells;
            GridHyperlinkCollection ghcb = GridWeb1.WorkSheets[1].Hyperlinks;
            cells1["A1"].CopyStyle(itemStyle);
            cellcmd = ghcb[ghcb.Add("A1", "")];

            cellcmd.Command = "1A1";
            cellcmd.ScreenTip = "Sorts Ascending";
            cellcmd.TextToDisplay = "Product";

            cells1["A2"].CopyStyle(itemStyle);
            cellcmd = ghcb[ghcb.Add("A2", "")];

            cellcmd.Command = "1A2";
            cellcmd.ScreenTip = "Sorts Ascending";
            cellcmd.TextToDisplay = "Category";

            cells1["A3"].CopyStyle(itemStyle);
            cellcmd = ghcb[ghcb.Add("A3", "")];

            cellcmd.Command = "1A3";
            cellcmd.ScreenTip = "Sorts Ascending";
            cellcmd.TextToDisplay = "Package";

            cells1["A4"].CopyStyle(itemStyle);
            cellcmd = ghcb[ghcb.Add("A4", "")];

            cellcmd.Command = "1A4";
            cellcmd.ScreenTip = "Sorts Ascending";
            cellcmd.TextToDisplay = "Quantity";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            InitData();
        }

        protected void GridWeb1_CellCommand(object sender, Aspose.Cells.GridWeb.CellEventArgs e)
        {
            // Handles sorting of columns and rows
            if (e.Argument.ToString() == "A1")
            {
                // ExStart:SortTopToBottom
                // Sorts Column 1 from top to bottom in descending order
                // Cells.Sort(int startRow, int startColumn, int rows, int columns, int index, bool isAsending, bool isCaseSensitive, bool islefttoright);
                GridWeb1.WorkSheets[0].Cells.Sort(1, 0, 20, 4, 0, false, true, false);
                // ExEnd:SortTopToBottom
            }
            else if (e.Argument.ToString() == "B1")
            {
                GridWeb1.WorkSheets[0].Cells.Sort(1, 0, 20, 4, 1, true, true, false);
            }
            else if (e.Argument.ToString() == "C1")
            {
                GridWeb1.WorkSheets[0].Cells.Sort(1, 0, 20, 4, 2, false, true, false);
            }
            else if (e.Argument.ToString() == "D1")
            {                
                GridWeb1.WorkSheets[0].Cells.Sort(1, 0, 20, 4, 3, true, true, false);                                
            }
            else if (e.Argument.ToString() == "1A1")
            {
                // ExStart:SortLeftToRight
                // Sorts Row 1 from left to right in ascending order
                // Cells.Sort(int startRow, int startColumn, int rows, int columns, int index, bool isAsending, bool isCaseSensitive, bool islefttoright);
                GridWeb1.WorkSheets[1].Cells.Sort(0, 1, 4, 7, 0, true, true, true);
                // ExEnd:SortLeftToRight
            }
            else if (e.Argument.ToString() == "1A2")
            {
                GridWeb1.WorkSheets[1].Cells.Sort(0, 1, 4, 7, 1, true, true, true);
            }
            else if (e.Argument.ToString() == "1A3")
            {
                GridWeb1.WorkSheets[1].Cells.Sort(0, 1, 4, 7, 2, true, true, true);
            }
            else if (e.Argument.ToString() == "1A4")
            {
                GridWeb1.WorkSheets[1].Cells.Sort(0, 1, 4, 7, 3, true, true, true);
            }
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
    }
}

