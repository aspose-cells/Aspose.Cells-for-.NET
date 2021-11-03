using System;
using Aspose.Cells.GridWeb.Data;
using System.Collections.Specialized;
using Aspose.Cells.GridWeb;

public partial class demos_Common_DataValidation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        License lic = new  License();
        //lic.SetLicense(@"C:\CellLicense\Aspose.Total.NET.lic");
        //lic.SetLicense(@"D:\DotNet Projects\Aspose\2019\Aspose.Total.NET.lic");

        if (!IsPostBack && !GridWeb1.IsPostBack)
        {
            
            GridWeb1.WorkSheets.Add();

            //set sheets selectedIndex to 0
            GridWeb1.WorkSheets.ActiveSheetIndex = 0;
            this.initData();
      }
    }

    // input Entry protection/validation data
    private void initData()
    {
      // Forces validation.
      //GridWeb1.ForceValidation = true;

      string path = Server.MapPath("~");
      path = path.Substring(0, path.LastIndexOf("\\"));
      string fileName = path + "\\File\\Input.xls";

        // Imports from a excel file.
        GridWeb1.ImportExcelFile(fileName);
        GridWorksheetCollection sheets = GridWeb1.WorkSheets;

        // Sets cell validation.
        GridValidationCollection gridValidationCollection = sheets[0].Validations;

        // Regular expression.
        GridValidation C5 = gridValidationCollection.Add("C5");
        //C5.Operator = OperatorType.BETWEEN;
        C5.ValidationType = GridValidationType.CustomExpression;
        C5.RegEx = @"\d{6}";

        // Number.
        GridValidation C6 = gridValidationCollection.Add("C6");
        C6.ValidationType = GridValidationType.Decimal;

        // Integer.
        GridValidation C7 = gridValidationCollection.Add("C7");
        C7.ValidationType = GridValidationType.WholeNumber;

        // Date.
        GridValidation C8 = gridValidationCollection.Add("C8");
        C8.ValidationType = GridValidationType.Date;

        // DateTime
        GridValidation C9 = gridValidationCollection.Add("C9");
        C9.ValidationType = GridValidationType.DateTime;

        // List.
        GridValidation C10 = gridValidationCollection.Add("C10");
        C10.ValidationType = GridValidationType.List;
        StringCollection value = new StringCollection();
        value.Add("Fortran");
        value.Add("Pascal");
        value.Add("C++");
        value.Add("Visual Basic");
        value.Add("Java");
        value.Add("C#");
        C10.ValueList = value;
        value.Clear();

        // DropDownList.
        GridValidation C11 = gridValidationCollection.Add("C11");
        C11.ValidationType = GridValidationType.DropDownList;
        value.Add("Bachelor");
        value.Add("Master");
        value.Add("Doctor");
        C11.ValueList = value;

        // FreeList
        GridValidation C12 = gridValidationCollection.Add("C12");
        C12.ValidationType = GridValidationType.FreeList;
        value.Add("US");
        value.Add("Britain");
        value.Add("France");
        C12.ValueList = value;

        // Custom function
        GridValidation C13 = gridValidationCollection.Add("C13");
        C13.ValidationType = GridValidationType.CustomFunction;
        C13.ClientValidationFunction = "myvalidation1";

        // CheckBox
        GridValidation C14 = gridValidationCollection.Add("C14");
        C14.ValidationType = GridValidationType.CheckBox;
    }

  protected void Button1_Click(object sender, EventArgs e)
  {
    initData();
  }

  protected void Checkbox1_CheckedChanged(object sender, EventArgs e)
  {
    GridWeb1.ForceValidation = Checkbox1.Checked;
  }

  protected void GridWeb1_SaveCommand(object sender, EventArgs e)
  {
    // Generates a temporary file name.
    string filename = System.IO.Path.GetTempPath() + Session.SessionID + ".xls";

    // Saves to the file.
    this.GridWeb1.SaveToExcelFile(filename);

    // Sents the file to browser.
    Response.ContentType = "application/vnd.ms-excel";

    //Adds header.
    Response.AddHeader("content-disposition", "attachment; filename=book1.xls");

    // Writes file content to the response stream.
    Response.WriteFile(filename);

    // OK.
    Response.End();
  }
}
