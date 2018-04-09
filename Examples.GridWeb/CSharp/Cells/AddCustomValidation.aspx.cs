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
            // ExStart:AddCustomValidation
            // Accessing the cells collection of the worksheet that is currently active
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Access "B1" cell and add some text
            GridCell cell = sheet.Cells[0, 1];
            cell.PutValue("Date (yyyy-mm-dd):");

            // Access "C1" cell and add to it custom expression validation to accept dates in yyyy-mm-dd format
            cell = sheet.Cells[0, 2];
            var validation = cell.CreateValidation(GridValidationType.CustomExpression, true);
            validation.RegEx = @"\d{4}-\d{2}-\d{2}";
            // ExEnd:AddCustomValidation

            sheet.Cells.SetColumnWidth(1, 30);

            // Assigning the name of JavaScript function to OnValidationErrorClientFunction property of GridWeb
            //GridWeb1.OnValidationErrorClientFunction = "ValidationErrorFunction";
        }
    }
}