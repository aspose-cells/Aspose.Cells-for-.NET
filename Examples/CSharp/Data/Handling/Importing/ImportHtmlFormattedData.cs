using System.IO;

using Aspose.Cells;
using System.Data;
using System;

namespace Aspose.Cells.Examples.Data.Handling.Importing
{
    public class ImportHtmlFormattedData
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string output1Path = dataDir + "Output.xlsx";
            string output2Path = dataDir + "Output.ods";

            // Prepare a DataTable with some HTML formatted values
            DataTable dataTable = new DataTable("Products");
            dataTable.Columns.Add("Product ID", typeof(Int32));
            dataTable.Columns.Add("Product Name", typeof(string));
            dataTable.Columns.Add("Units In Stock", typeof(Int32));
            DataRow dr = dataTable.NewRow();
            dr[0] = 1;
            dr[1] = "<i>Aniseed</i> Syrup";
            dr[2] = 15;
            dataTable.Rows.Add(dr);
            dr = dataTable.NewRow();
            dr[0] = 2;
            dr[1] = "<b>Boston Crab Meat</b>";
            dr[2] = 123;
            dataTable.Rows.Add(dr);

            // Create import options
            ImportTableOptions importOptions = new ImportTableOptions();
            importOptions.IsFieldNameShown = true;
            importOptions.IsHtmlString = true;

            // Create workbook
            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets[0];
            worksheet.Cells.ImportData(dataTable, 0, 0, importOptions);
            worksheet.AutoFitRows();
            worksheet.AutoFitColumns();

            workbook.Save(output1Path);
            workbook.Save(output2Path);
        }
    }
}
