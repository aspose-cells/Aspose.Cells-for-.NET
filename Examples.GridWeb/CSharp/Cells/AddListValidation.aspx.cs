using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Cells
{
    public partial class AddListValidation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddListValidation_Click(object sender, EventArgs e)
        {
            // ExStart:AddListValidation
            // Accessing the cells collection of the worksheet that is currently active
            WebWorksheet sheet = GridWeb1.WebWorksheets[GridWeb1.ActiveSheetIndex];

            // Accessing "B1" cell
            WebCell cell = sheet.Cells[0, 1];

            // Putting value to "B1" cell
            cell.PutValue("Select Course:");

            // Accessing "C1" cell
            cell = sheet.Cells[0, 2];

            // Creating List validation for the "C1" cell
            cell.CreateValidation(ValidationType.List, true);

            // Adding values to List validation
            cell.Validation.ValueList.Add("Fortran");
            cell.Validation.ValueList.Add("Pascal");
            cell.Validation.ValueList.Add("C++");
            cell.Validation.ValueList.Add("Visual Basic");
            cell.Validation.ValueList.Add("Java");
            cell.Validation.ValueList.Add("C#");
            // ExEnd:AddListValidation 
        }
    }
}