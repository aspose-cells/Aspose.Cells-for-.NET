using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Cells
{
    public partial class ModifyCells : System.Web.UI.Page
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
            // Clear GridWeb 
            GridWeb1.WorkSheets.Clear();

            // Add a new sheet by name and put some info text in cells
            GridWorksheet sheet = GridWeb1.WorkSheets.Add("Modify-Cells");
            GridCells cells = sheet.Cells;
            cells["A1"].PutValue("String Value:");
            cells["A3"].PutValue("Int Value:");
            cells["A5"].PutValue("Double Value:");

            cells.SetColumnWidth(0, 30);
            cells.SetColumnWidth(1, 20);
        }

        protected void btnModifyCellValue_Click(object sender, EventArgs e)
        {
            AddStringValue();
            AddIntValue();
            AddDoubleValue();
        }

        private void AddStringValue()
        {
            // ExStart:AddCellStringValue
            // Accessing the worksheet of the Grid that is currently active
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Accessing "B1" cell of the worksheet
            GridCell cell = sheet.Cells["B1"];

            // Accessing the string value of "B1" cell
            Label1.Text = cell.StringValue;

            // Modifying the string value of "B1" cell
            cell.PutValue("Hello Aspose.Grid");
            // ExEnd:AddCellStringValue
        }

        private void AddIntValue()
        {
            // ExStart:AddCellIntValue
            // Accessing the worksheet of the Grid that is currently active
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Accessing "B3" cell of the worksheet
            GridCell cell = sheet.Cells["B3"];

            // Putting a value in "B3" cell
            cell.PutValue(30);
            // ExEnd:AddCellIntValue
        }

        private void AddDoubleValue()
        {
            // ExStart:AddCellDoubleValue
            // Accessing the worksheet of the Grid that is currently active
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Accessing "B5" cell of the worksheet
            GridCell cell = sheet.Cells["B5"];

            // Putting a numeric value as string in "B5" cell that will be converted to a suitable data type automatically
            cell.PutValue("19.4", true);
            // ExEnd:AddCellDoubleValue
        }
    }
}