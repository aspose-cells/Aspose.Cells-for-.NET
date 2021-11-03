using System;
using System.Data;
using Aspose.Cells.GridWeb.Data;
using System.Data.OleDb;

namespace Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns
{
    public partial class GroupRows : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            GridWeb1.WorkSheets.Clear();

            // Connect database
            System.Data.OleDb.OleDbConnection oleDbConnection1 = new OleDbConnection();
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1 = new OleDbDataAdapter();
            System.Data.OleDb.OleDbCommand oleDbSelectCommand1 = new OleDbCommand();
            string path = (this.Master as Site).GetDataDir();
            oleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "\\Worksheets\\Database\\Northwind.mdb";
            oleDbSelectCommand1.Connection = oleDbConnection1;
            oleDbDataAdapter1.SelectCommand = oleDbSelectCommand1;

            DataTable dataTable1 = new DataTable();
            dataTable1.Reset();

            try
            {
                oleDbSelectCommand1.CommandText = "SELECT * FROM Products";
                oleDbDataAdapter1.Fill(dataTable1);
                
                // Import data from database to grid web
                GridWeb1.WorkSheets.ImportDataView(dataTable1.DefaultView, null, null);
            }
            finally
            {
                // Close connection
                oleDbConnection1.Close();
            }
        }

        protected void GridWeb1_CustomCommand(object sender, string command)
        {
            // Groups Rows or Ungroup Rows.
            if (GridWeb1.ActiveSheetIndex == 0)
            {
                switch (command)
                {
                    case "GROUP":
                        if (GridWeb1.SelectCells != null && GridWeb1.SelectCells.Count > 0)
                        {
                            // Get Cell Selected CellArea
                            GridCellArea SelectedCells = (GridCellArea)GridWeb1.SelectCells[0];

                            // Group rows from starting cell to ending cell
                            //GridWeb1.WebWorksheets[GridWeb1.ActiveSheetIndex].GroupRows(SelectedCells.StartRow, SelectedCells.EndRow);

                            // Accessing the reference of the worksheet that is currently active
                            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

                            // Group the rows
                            sheet.Cells.GroupRows(1, 9);
                        }
                        break;

                    case "UNGROUP":
                        if (GridWeb1.SelectCells != null && GridWeb1.SelectCells.Count > 0)
                        {
                            // Get Cell Selected CellArea
                            GridCellArea SelectedCells = (GridCellArea)GridWeb1.SelectCells[0];

                            // Group rows from starting cell to ending cell
                            GridWeb1.WebWorksheets[GridWeb1.ActiveSheetIndex].UngroupRows(SelectedCells.StartRow, SelectedCells.EndRow); ;
                        }
                        break;
                }
            }
        }
    }
}

