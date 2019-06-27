using System.IO;

using Aspose.Cells;
using System.Data;
using System;

namespace Aspose.Cells.Examples.CSharp.Data.Handling.Importing
{
    public class ImportingFromDataColumn
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            // Instantiating a "Products" DataTable object
            DataTable dataTable = new DataTable("Products");

            // Adding columns to the DataTable object
            dataTable.Columns.Add("Product ID", typeof(Int32));
            dataTable.Columns.Add("Product Name", typeof(string));
            dataTable.Columns.Add("Units In Stock", typeof(Int32));

            // Creating an empty row in the DataTable object
            DataRow dr = dataTable.NewRow();

            // Adding data to the row
            dr[0] = 1;
            dr[1] = "Aniseed Syrup";
            dr[2] = 15;

            // Adding filled row to the DataTable object
            dataTable.Rows.Add(dr);

            // Creating another empty row in the DataTable object
            dr = dataTable.NewRow();

            // Adding data to the row
            dr[0] = 2;
            dr[1] = "Boston Crab Meat";
            dr[2] = 123;

            // Adding filled row to the DataTable object
            dataTable.Rows.Add(dr);

            // Instantiate a new Workbook
            Workbook book = new Workbook();

            Worksheet sheet = book.Worksheets[0];

            // Create import options
            ImportTableOptions importOptions = new ImportTableOptions();
            importOptions.IsFieldNameShown = true;
            importOptions.IsHtmlString = true;

            // Importing the values of 2nd column of the data table
            int[] columns = { 0, 1 };
            importOptions.ColumnIndexes = columns;

            // Inserting data to 2nd row and column
            sheet.Cells.ImportData(dataTable, 1, 1, importOptions);

            // Save workbook
            book.Save(dataDir + "DataImport.out.xls");
            // ExEnd:1
        }
    }
}
