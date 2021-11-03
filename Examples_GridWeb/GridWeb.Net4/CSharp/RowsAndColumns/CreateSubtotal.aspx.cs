using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Drawing;
using Aspose.Cells.GridWeb.Data;

namespace Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns
{
    public partial class CreateSubtotal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                // Load data against selected drop down value
                LoadData(ddlSort.SelectedItem.Value);
            }
        }

        private void LoadData(string sort)
        {
            // Loads data from access database.
            DataSet ds = new DataSet();

            // Create path to database file
            string path = (this.Master as Site).GetDataDir();

            // Create database connection object
            OleDbConnection conn = new OleDbConnection();

            // Create connection string to database
            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "\\RowsAndColumns\\Database\\Northwind.mdb";

            // Write select command
            string sql = "SELECT Products.ProductID, Categories.CategoryName, Suppliers.CompanyName, Products.ProductName, Products.QuantityPerUnit, Products.UnitPrice FROM Suppliers INNER JOIN (Categories INNER JOIN Products ON Categories.CategoryID = Products.CategoryID) ON Suppliers.SupplierID = Products.SupplierID";

            // Create data adapter object
            OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
            try
            {
                // Connects to database and fetches data.
                da.Fill(ds, "Products");
                // Sorting
                DataView productsView = new DataView(ds.Tables["Products"], "", sort, DataViewRowState.CurrentRows);

                // Clear gridweb worksheet
                GridWeb1.WebWorksheets.Clear();

                // Import data from dataview
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
                // Close database connection
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
            // Fill web worksheet object
            GridWorksheet sheet = GridWeb1.WorkSheets[0];

            // Removes the created subtotal first.
            //sheet.RemoveSubtotal();

            // Creates the subtotal.
            int groupByIndex;
            if (ddlSort.SelectedItem.Value == "CategoryName")
                groupByIndex = 1;
            else
                groupByIndex = 2;

            // Creates GrandTotal and Subtotal style.
            GridTableItemStyle grandStyle = new GridTableItemStyle();
            grandStyle.BackColor = Color.Gray;
            grandStyle.ForeColor = Color.Black;
            GridTableItemStyle subtotalStyle = new GridTableItemStyle();
            subtotalStyle.BackColor = Color.SkyBlue;
            subtotalStyle.ForeColor = Color.Black;

            // ExStart:CreateSubTotal
            sheet.CreateSubtotal(0, sheet.Cells.MaxRow, groupByIndex, (SubtotalFunction)System.Enum.Parse(typeof(SubtotalFunction), ddlFunction.SelectedItem.Value), new int[] { 1, 2, 3, 4, 5 }
                        , ddlFunction.SelectedItem.Text, grandStyle, subtotalStyle, NumberType.General, null);
            // ExEnd:CreateSubTotal
        }

        protected void GridWeb1_SaveCommand(object sender, System.EventArgs e)
        {
            // Generates a temporary file name.
            string filename = Session.SessionID + "_out.xls";

            string path = (this.Master as Site).GetDataDir() + "\\RowsAndColumns\\";

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

