using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Cells
{
    public partial class AddDropdownListValidation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddDropDownListValidation_Click(object sender, EventArgs e)
        {
            // ExStart:AddDropDownListValidation
            // Accessing the cells collection of the worksheet that is currently active
            WebWorksheet sheet = GridWeb1.WebWorksheets[GridWeb1.ActiveSheetIndex];

            // Accessing "B1" cell
            WebCell cell = sheet.Cells[0, 1];

            // Putting value to "B1" cell
            cell.PutValue("Select Degree:");

            // Accessing "C1" cell
            cell = sheet.Cells[0, 2];

            // Creating DropDownList validation for the "C1" cell
            cell.CreateValidation(ValidationType.DropDownList, true);
                        
            // Adding values to DropDownList validation
            cell.Validation.ValueList.Add("Bachelor");
            cell.Validation.ValueList.Add("Master");
            cell.Validation.ValueList.Add("Doctor");
            // ExEnd:AddDropDownListValidation
        }
    }
}