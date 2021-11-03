using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Cells
{
    public partial class AccessCells : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If first visit, load GridWeb data
            if (!Page.IsPostBack && !GridWeb1.IsPostBack)
            {
                LoadData();
            }
            else
            {
                Label1.Text = "";
            }
        }

        private void LoadData()
        {
            // Gets the web application's path.
            string path = (this.Master as Site).GetDataDir();

            string fileName = path + "\\Cells\\Products.xlsx";

            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);
            GridWeb1.ActiveCell = GridWeb1.WorkSheets[0].Cells["A1"];
        }

        protected void btnAccessCellValue_Click(object sender, EventArgs e)
        {
            AccessCellByName();
            AccessCellByRowColumnIndex();
        }
        
        private void AccessCellByName()
        {
            // ExStart:AccessCellByName
            // Accessing the worksheet of the Grid that is currently active
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Accessing "A1" cell of the worksheet
            GridCell cell = sheet.Cells["A1"];

            // Display cell name and value
            Label1.Text += "Cell Value of " + cell.Name +" is " + cell.StringValue + "<br/>";
            // ExEnd:AccessCellByName
        }
        
        private void AccessCellByRowColumnIndex()
        {
            // ExStart:AccessCellByRowColumnIndex
            // Accessing the worksheet of the Grid that is currently active
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Accessing "B1" cell of the worksheet using its row and column indices
            GridCell cell = sheet.Cells[0, 1];

            // Display cell name and value
            Label1.Text += "Cell Value of " + cell.Name +" is " + cell.StringValue + "<br/>";
            // ExEnd:AccessCellByRowColumnIndex        
        }
    }
}