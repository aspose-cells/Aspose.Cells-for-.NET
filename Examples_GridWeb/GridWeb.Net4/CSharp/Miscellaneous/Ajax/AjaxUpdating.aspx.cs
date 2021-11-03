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
using System.Drawing;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Ajax
{
    public partial class AjaxUpdating : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            // Define maximum rows and columns
            GridWeb1.MaxColumn = 3;
            GridWeb1.MaxRow = 5;

            // Create web worksheet object
            GridWorksheet sheet = GridWeb1.WorkSheets[0];

            // Clear worksheet content
            sheet.Cells.Clear();

            // Adding a sample value and formatting to "B1" cell
            sheet.Cells["B1"].PutValue("BMI Calculator");
            sheet.Cells["B1"].Style.BackColor = Color.Yellow;
            sheet.Cells["B1"].Style.ForeColor = Color.Green;
            sheet.Cells["B1"].Style.Font.Bold = true;
            sheet.Cells["B1"].Style.HorizontalAlign = HorizontalAlign.Center;
            sheet.Cells["B1"].Style.VerticalAlign = VerticalAlign.Middle;

            // Merge B1 and B2 columns  
            sheet.Cells.Merge(0, 1, 1, 2);

            // Set columns width
            sheet.Cells.SetColumnWidth(1, 200);
            sheet.Cells.SetColumnWidth(2, 200);

            // Adding a sample value and formatting to "B3" cell
            sheet.Cells["B3"].PutValue("Your Height(CM):");
            sheet.Cells["B3"].Style.BackColor = Color.Blue;
            sheet.Cells["B3"].Style.ForeColor = Color.Silver;

            // Adding a sample value and formatting to "B4" cell
            sheet.Cells["B4"].PutValue("Your Weight(KG):");
            sheet.Cells["B4"].Style.BackColor = Color.Blue;
            sheet.Cells["B4"].Style.ForeColor = Color.Silver;

            // Adding a sample value and formatting to "B5" cell
            sheet.Cells["B5"].PutValue("Your BMI is:");
            sheet.Cells["B5"].Style.BackColor = Color.Green;
            sheet.Cells["B5"].Style.ForeColor = Color.Silver;

            // Adding a sample value and formatting to "B6" cell
            sheet.Cells["B6"].PutValue("Evaluation:");
            sheet.Cells["B6"].Style.BackColor = Color.Green;
            sheet.Cells["B6"].Style.ForeColor = Color.Silver;

            //Adding a formula value and formatting to "C5" cell
            sheet.Cells["C5"].Formula = "=C4/(C3/100)^2";
            sheet.Cells["C5"].Style.BackColor = Color.LightGreen;
            sheet.Cells["C5"].Style.ForeColor = Color.Red;
            sheet.Cells["C5"].Style.HorizontalAlign = HorizontalAlign.Right;
            GridTableItemStyle style = new GridTableItemStyle();
            style.Custom = "0.00";
            sheet.Cells["C5"].Style = style;

            // Adding a formula value and formatting to "C6" cell 
            sheet.Cells["C6"].Formula = "=IF(C5<18.5, \"Too Thin\", IF(C5<21, \"Good\", IF(C5<=23, \"Very Good\", IF(C5<=25, \"Good\", \"Too Fat\"))))";
            sheet.Cells["C6"].Style.BackColor = Color.LightGreen;
            sheet.Cells["C6"].Style.ForeColor = Color.Red;
            sheet.Cells["C6"].Style.HorizontalAlign = HorizontalAlign.Right;

            // Adding validation and formatting to "C3" cell
            sheet.Cells["C3"].CreateValidation(GridValidationType.WholeNumber, true);
            sheet.Cells["C3"].Style.HorizontalAlign = HorizontalAlign.Right;

            // Adding validation and formatting to "C4" cell
            sheet.Cells["C4"].CreateValidation(GridValidationType.WholeNumber, true);
            sheet.Cells["C4"].Style.HorizontalAlign = HorizontalAlign.Right;

            // Set GridWeb properties
            GridWeb1.EnableAJAX = true;
            GridWeb1.EnableClientColumnOperations = false;
            GridWeb1.EnableClientFreeze = false;
            GridWeb1.EnableClientMergeOperations = false;
            GridWeb1.EnableClientRowOperations = false;
            GridWeb1.EnableStyleDialogbox = false;
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}

