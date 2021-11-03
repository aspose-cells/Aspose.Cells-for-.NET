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
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Access "B1" cell and add some text
            GridCell cell = sheet.Cells[0, 1];
            cell.PutValue("Select Course:");

            // Accessing "C1" cell
            cell = sheet.Cells[0, 2];

            // Creating List validation for the "C1" cell
            var validation = cell.CreateValidation(GridValidationType.List, true);

            // Adding values to List validation
            var values = new System.Collections.Specialized.StringCollection();
            values.Add("Fortran");
            values.Add("Pascal");
            values.Add("C++");
            values.Add("Visual Basic");
            values.Add("Java");
            values.Add("C#");
            validation.ValueList = values;
            // ExEnd:AddListValidation 
        }
    }
}