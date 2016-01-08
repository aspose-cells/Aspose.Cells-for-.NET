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
using System.Data.OleDb;
using System.Drawing;
using Aspose.Cells.GridWeb.Data;

public partial class demos_Grouping_Subtotal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      // Put user code to initialize the page here
      if (!IsPostBack&&!GridWeb1.IsPostBack)
      {
        //Load data against selected drop down value
        LoadData(ddlSort.SelectedItem.Value);
      }
    }

  private void LoadData(string sort)
  {
    // Loads data from access database.
    DataSet ds = new DataSet();

    //Create path to database file
    string path = Server.MapPath("~");
    path = path.Substring(0, path.LastIndexOf("\\"));	

    //Create database connection object
    OleDbConnection conn = new OleDbConnection();

    //Create connection string to database
    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "\\Database\\demos.mdb";

    //Write select command
    string sql = "SELECT Products.ProductID, Categories.CategoryName, Suppliers.CompanyName, Products.ProductName, Products.QuantityPerUnit, Products.UnitPrice FROM Suppliers INNER JOIN (Categories INNER JOIN Products ON Categories.CategoryID = Products.CategoryID) ON Suppliers.SupplierID = Products.SupplierID";

    //Create data adapter object
    OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
    try
    {
      // Connects to database and fetches data.
      da.Fill(ds, "Products");
      // Sorting
      DataView productsView = new DataView(ds.Tables["Products"], "", sort, DataViewRowState.CurrentRows);

      //Clear gridweb worksheet
      GridWeb1.WebWorksheets.Clear();

      //Import data from dataview
      GridWeb1.WebWorksheets.ImportDataView(productsView, null, null);

      // Sets column width.
      GridWeb1.WebWorksheets[0].Cells.SetColumnWidth(0, new Unit(108.75, UnitType.Point));
      GridWeb1.WebWorksheets[0].Cells.SetColumnWidth(1, new Unit(74.25, UnitType.Point));
      GridWeb1.WebWorksheets[0].Cells.SetColumnWidth(2, new Unit(181.5, UnitType.Point));
      GridWeb1.WebWorksheets[0].Cells.SetColumnWidth(3, new Unit(155.25, UnitType.Point));
      GridWeb1.WebWorksheets[0].Cells.SetColumnWidth(4, new Unit(96, UnitType.Point));
      GridWeb1.WebWorksheets[0].Cells.SetColumnWidth(5, new Unit(47.25, UnitType.Point));
    }
    finally
    {
      //Close database connection
      conn.Close();
    }
  }

  protected void ddlSort_SelectedIndexChanged(object sender, System.EventArgs e)
  {
    // Reload data, sort by the select value.
    LoadData(ddlSort.SelectedItem.Value);
  }

  protected void btnCreate_Click(object sender, System.EventArgs e)
  {
    //Fill web worksheet object
    WebWorksheet sheet = GridWeb1.WebWorksheets[0];

    // Removes the created subtotal first.
    sheet.RemoveSubtotal();

    // Creates the subtotal.
    int groupByIndex;
    if (ddlSort.SelectedItem.Value == "CategoryName")
      groupByIndex = 1;
    else
      groupByIndex = 2;
   
    // Creates GrandTotal and Subtotal style.
    Aspose.Cells.GridWeb.TableItemStyle grandStyle = new Aspose.Cells.GridWeb.TableItemStyle();
    grandStyle.BackColor = Color.Gray;
    grandStyle.ForeColor = Color.Black;
    Aspose.Cells.GridWeb.TableItemStyle subtotalStyle = new Aspose.Cells.GridWeb.TableItemStyle();
    subtotalStyle.BackColor = Color.SkyBlue;
    subtotalStyle.ForeColor = Color.Black;

    sheet.CreateSubtotal(0, sheet.Cells.MaxRow, groupByIndex, (SubtotalFunction)System.Enum.Parse(typeof(SubtotalFunction), ddlFunction.SelectedItem.Value), new int[] { 1, 2, 3, 4, 5 }
				, ddlFunction.SelectedItem.Text, grandStyle, subtotalStyle, NumberType.General, null);
  }

  protected void GridWeb1_SaveCommand(object sender, System.EventArgs e)
  {
    // Generates a memory stream.
    System.IO.MemoryStream ms = new System.IO.MemoryStream();

    // Saves to the stream.
    this.GridWeb1.SaveToExcelFile(ms);

    // Sents the file to browser.
    Response.ContentType = "application/vnd.ms-excel";

    //Adds header.
    Response.AddHeader("content-disposition", "attachment; filename=book1.xls");

    // Writes file content to the response stream.
    Response.OutputStream.Write(ms.GetBuffer(), 0, (int)ms.Length);

    // OK.
    Response.End();
  }

}
