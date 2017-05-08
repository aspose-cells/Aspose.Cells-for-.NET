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
using Aspose.Cells.GridWeb.DemosCS.DataBind;
using Aspose.Cells.GridWeb.DemosCS;


public partial class demos_GridWebForm_GridWebForm1 : System.Web.UI.Page
{
    protected Aspose.Cells.GridWeb.DemosCS.DataBind.DataSet1 dataSet11;

    protected void Page_Load(object sender, EventArgs e)
    {
      // Put user code to initialize the page here
      if (!IsPostBack)
        BindWithoutInSheetHeaders();
    }

  private void BindWithoutInSheetHeaders()
  {
    //Create dataset object
    this.dataSet11 = new Aspose.Cells.GridWeb.DemosCS.DataBind.DataSet1();

    //Create demo database object
    ExampleDatabase db = new ExampleDatabase();

    //Create path to database file
    string path = Server.MapPath("~");
    path = path.Substring(0, path.LastIndexOf("\\"));	

    //Create connection string to database
    db.oleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "\\Database\\demos.mdb";
    try
    {
      // Connects to database and fetches data.
      db.oleDbDataAdapter1.Fill(dataSet11);
      db.oleDbDataAdapter2.Fill(dataSet11);

      //Create web worksheet object
      WebWorksheet sheet = GridWeb1.WebWorksheets[0];

      //// Create the "CategoryID" field dropdownlist value list.
      //sheet.BindColumns["CategoryID"].Validation.ValidationType = ValidationType.List;
      //sheet.BindColumns["CategoryID"].Validation.LoadValueList(dataSet11.Categories.DefaultView, "CategoryID", "CategoryName", true);

      // Bind the sheet to the dataset.
      sheet.DataSource = dataSet11;
      sheet.DataBind();
    }
    finally
    {
      //Close database connection
      db.oleDbConnection1.Close();
    }
  }

  // Uses the cell command type bind column to create a link for each row to switch to the form view.
  protected void GridWeb1_CellCommand(object sender, Aspose.Cells.GridWeb.CellEventArgs e)
  {
    if (e.Argument.Equals("VIEWDETAIL"))
    {
      //Show grid form and line no
      GridWebForm2.ShowForm();
      GridWebForm2.LineNumber = e.Cell.Row;
    }
  }

}
