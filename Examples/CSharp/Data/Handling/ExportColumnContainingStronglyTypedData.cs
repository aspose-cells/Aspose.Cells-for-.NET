using System.IO;

using Aspose.Cells;
using System.Data;

namespace Aspose.Cells.Examples.Data.Handling
{
    public class ExportColumnContainingStronglyTypedData
    {
        public static void Main(string[] args)
        {
           /* // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            string filePath = dataDir + "Book1.xlsx";

            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(filePath, FileMode.Open);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            //Exporting the contents of 7 rows and 2 columns starting from 1st cell to DataTable
            DataTable dataTable = worksheet.Cells.ExportDataTable(0, 0, 7, 2, true);

            //Binding the DataTable with DataGrid
            //dataGrid1.DataSource = dataTable;

            //Closing the file stream to free all resources
            fstream.Close();
            */
        }
    }
}