using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Cells
{
    public partial class AddCustomValidation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddCustomValidation_Click(object sender, EventArgs e)
        {
            // Accessing the cells collection of the worksheet that is currently active
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Access cell B1 and add input message text
            GridCell cell = sheet.Cells["B1"];
            cell.PutValue("Please enter Date in cell C3 e.g. 2018-02-18");

            //Access cell B3 and add the Date Pattern
            cell = sheet.Cells["B3"];
            cell.PutValue("Date (yyyy-mm-dd):");

            // Access cell C3 and add to it custom expression validation to accept dates in yyyy-mm-dd format
            cell = sheet.Cells["C3"];
            var validation = cell.CreateValidation(GridValidationType.CustomExpression, true);
            validation.RegEx = @"\d{4}-\d{2}-\d{2}";

            //Set the column widths
            sheet.Cells.SetColumnWidth(1, 40);
            sheet.Cells.SetColumnWidth(2, 30);

            // Assigning the name of JavaScript function to OnCellErrorClientFunction property of GridWeb
            GridWeb1.OnCellErrorClientFunction = "ValidationErrorFunction";
        }
    }
}