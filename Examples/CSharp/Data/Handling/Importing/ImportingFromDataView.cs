using System.IO;

using Aspose.Cells;
using System;
using System.Data;

namespace Aspose.Cells.Examples.Data.Handling.Importing
{
    public class ImportingFromDataView
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiating a Workbook object            
            Workbook workbook = new Workbook();

            //Obtaining the reference of the worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Instantiating a "Products" DataTable object
            DataTable dataTable = new DataTable("Products");

            //Adding columns to the DataTable object
            dataTable.Columns.Add("Product ID", typeof(Int32));
            dataTable.Columns.Add("Product Name", typeof(string));
            dataTable.Columns.Add("Units In Stock", typeof(Int32));

            //Creating an empty row in the DataTable object
            DataRow dr = dataTable.NewRow();

            //Adding data to the row
            dr[0] = 1;
            dr[1] = "Aniseed Syrup";
            dr[2] = 15;

            //Adding filled row to the DataTable object
            dataTable.Rows.Add(dr);

            //Creating another empty row in the DataTable object
            dr = dataTable.NewRow();

            //Adding data to the row
            dr[0] = 2;
            dr[1] = "Boston Crab Meat";
            dr[2] = 123;

            //Adding filled row to the DataTable object
            dataTable.Rows.Add(dr);

            //Importing the contents of the data view to the worksheet
            worksheet.Cells.ImportDataView(dataTable.DefaultView, true, 0, 0, false);

            //Saving the Excel file
            workbook.Save(dataDir + "output.xls");
            //ExEnd:1
        }
    }
}
