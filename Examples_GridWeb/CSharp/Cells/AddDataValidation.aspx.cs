using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Cells
{
    public partial class AddDataValidation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddDataValidation_Click(object sender, EventArgs e)
        {
            // ExStart:AddDataValidation
            // Access first worksheet
            GridWorksheet sheet = GridWeb1.WorkSheets[0];

            // Access cell B3
            GridCell cell = sheet.Cells["B3"];

            // Add validation inside the gridcell
            // Any value which is not between 20 and 40 will cause error in a gridcell
            GridValidation val = cell.CreateValidation(GridValidationType.WholeNumber, true);
            val.Formula1 = "=20";
            val.Formula2 = "=40";
            val.Operator = GridOperatorType.Between;
            val.ShowError = true;
            val.ShowInput = true;
            // ExEnd:AddDataValidation

            Label1.Text = "Data Validation is added in cell B3. Any value which is not between 20 and 40 will cause error.";
        }
    }
}