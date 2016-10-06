using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics
{
    public partial class WriteClientSideScript : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If first visit this page init GridWeb
            if (!Page.IsPostBack)
            {
                // Initialize GridWeb 
                InitGridWeb();
            }
        }

        private void InitGridWeb()
        {
            // ExStart:WriteClientSideScript
            // Assigning the name of JavaScript function to OnSubmitClientFunction property of GridWeb
            GridWeb1.OnSubmitClientFunction = "ConfirmFunction";

            // Assigning the name of JavaScript function to OnValidationErrorClientFunction property of GridWeb
            GridWeb1.OnValidationErrorClientFunction = "ValidationErrorFunction";

            // Accessing the cells collection of the worksheet that is currently active
            WebWorksheet sheet = GridWeb1.WebWorksheets[GridWeb1.ActiveSheetIndex];

            // Accessing "B1" cell
            WebCell cell = sheet.Cells[0, 1];

            // Putting value to "B1" cell
            cell.PutValue("Date (yyyy-mm-dd):");

            // Accessing "C1" cell
            cell = sheet.Cells[0, 2];

            // Creating a custom expression validation for the "C1" cell
            cell.CreateValidation(ValidationType.CustomExpression, true);

            // Setting regular expression for the validation to accept dates in yyyy-mm-dd format
            cell.Validation.RegEx = @"\d{4}-\d{2}-\d{2}";
            // ExEnd:WriteClientSideScript
        }

        protected void GridWeb1_SaveCommand(object sender, EventArgs e)
        {
            // Generates a temporary file name.
            string filename = Session.SessionID + "_out_.xls";

            string path = (this.Master as Site).GetDataDir() + "\\GridWebBasics\\";

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