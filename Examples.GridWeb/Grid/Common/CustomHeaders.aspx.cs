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
using Aspose.Cells.GridWeb.Data;

public partial class demos_Common_CustomHeaders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Put user code to initialize the page here
        if (!IsPostBack&&!GridWeb1.IsPostBack)
        {
            GridWeb1.WorkSheets.Clear();
            GridWeb1.WorkSheets.Add();

            //set sheets selectedIndex to 0
            GridWeb1.WorkSheets.ActiveSheetIndex = 0;
        }
    }
  protected void Button1_Click(object sender, EventArgs e)
  {
    // Only showss 3 columns.
    GridWeb1.MaxColumn = 2;
    GridWorksheet workSheet = GridWeb1.WorkSheets[0];
    GridCells cells = workSheet.Cells;

    // Creates Custom Header Caption.
    workSheet.SetColumnCaption(0, "Product");
    workSheet.SetColumnCaption(1, "Category");
    workSheet.SetColumnCaption(2, "Price");
    workSheet.SetRowCaption(2, "row2");
    // Put some values.
    cells["A1"].PutValue("Aniseed Syrup");
    cells["A2"].PutValue("Boston Crab Meat");
    cells["A3"].PutValue("Chang");

    cells["B1"].PutValue("Condiments");
    cells["B2"].PutValue("Seafood");
    cells["B3"].PutValue("Beverages");

    cells["C1"].PutValue(14.95);
    Aspose.Cells.GridWeb.GridTableItemStyle style = cells["C1"].Style;
    style.NumberType = (int)NumberType.Currency3;
    style.HorizontalAlign = HorizontalAlign.Right;
    cells["C1"].Style = style;

    cells["C2"].PutValue(24.99);
    cells["C2"].Style = style;

    cells["C3"].PutValue(49.95);
    cells["C3"].Style = style;

    // Adjusts column width.
    cells.SetColumnWidth(0, 20);
    cells.SetColumnWidth(1, 20);
    cells.SetColumnWidth(2, 20);
  }
}
