using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aspose.Cells.GridWeb;
using Aspose.Cells.GridWeb.Data;


namespace Aspose.Cells.GridWeb.Examples
{   
    [Serializable]
    class MyServerValidation : GridCustomServerValidation, ISerializable
    {
        public string Validate(GridWorksheet sheet, int row, int col, string value)
        {
            if ((row == 1) || (row == 2))
            {
                return "Value Not Passed!";
            }
            else
            {
                return string.Empty;
            }
        }
    }

    public partial class AddCustomServerSideFunctionValidation : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !this.GridWeb1.IsPostBack)
            {
                lblVersion.Text = GridWeb.GetVersion();

                //Input values to B2:C3 cells in the active worksheet.
                GridWeb1.ActiveSheet.Cells["B2"].PutValue("This");
                GridWeb1.ActiveSheet.Cells["C2"].PutValue("cannot");
                GridWeb1.ActiveSheet.Cells["B3"].PutValue("be");
                GridWeb1.ActiveSheet.Cells["C3"].PutValue("changed");
                
                //Get the validations of the active sheet.
                var gridValidationCollection = GridWeb1.ActiveSheet.Validations;
                
                //Add data validation to range/area: B2:C3
                GridValidation gv = gridValidationCollection.Add(new GridCellArea(1, 1, 2, 2));
                
                //Set the validation type to custom server function.
                gv.ValidationType = GridValidationType.CustomServerFunction;
                
                //Set the server validation class which implements the GridCustomServerValidation interface.
                gv.ServerValidation = new MyServerValidation();
                
                //Set the client validation function (written in JavaScript on client-side).
                //This function is compulsory to validate the data on client end on callback.
                gv.ClientValidationFunction = "ValidationErrorClientFunctionCallback";
                
                //Set the error message string.
                gv.ErrorMessage = "Error found! You cannot change this value.";
                
                //Set the error title.
                gv.ErrorTitle = "Error";
            }
        }
    }
}