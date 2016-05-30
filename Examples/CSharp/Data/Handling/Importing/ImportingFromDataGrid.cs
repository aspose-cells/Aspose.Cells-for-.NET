using System.IO;

using Aspose.Cells;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace CSharp.Data.Handling.Importing
{
    public class ImportingFromDataGrid
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create a DataTable object and set it as DataSource of DataGrid.
            DataTable dataTable = new DataTable("Products");
            dataTable.Columns.Add("Product ID", typeof(Int32));
            dataTable.Columns.Add("Product Name", typeof(string));
            dataTable.Columns.Add("Units In Stock", typeof(Int32));
            DataRow dr = dataTable.NewRow();
            dr[0] = 1;
            dr[1] = "Aniseed Syrup";
            dr[2] = 15;
            dataTable.Rows.Add(dr);
            dr = dataTable.NewRow();
            dr[0] = 2;
            dr[1] = "Boston Crab Meat";
            dr[2] = 123;
            dataTable.Rows.Add(dr);

            // Now take care of DataGrid
            DataGrid dg = new DataGrid();
            dg.DataSource = dataTable;
            dg.DataBind();

            // We have a DataGrid object with some data in it.
            // Lets import it into our spreadsheet

            // Creat a new workbook
            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets[0];

            // Importing the contents of the data grid to the worksheet
            worksheet.Cells.ImportDataGrid(dg, 0, 0, false);

            // Save it as Excel file
            workbook.Save(dataDir + "output.xlsx");
            // ExEnd:1
        }
    }
}
