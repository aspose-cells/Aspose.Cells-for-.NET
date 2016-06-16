using System.IO;

using Aspose.Cells;
using System.Data;

namespace Aspose.Cells.Examples.CSharp.Data.Handling
{
    public class ExportingDataFromWorksheets
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(dataDir + "book1.xls", FileMode.Open);

            // Instantiating a Workbook object
            // Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            // Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            // Exporting the contents of 7 rows and 2 columns starting from 1st cell to DataTable
            DataTable dataTable = worksheet.Cells.ExportDataTable(0, 0, 7, 2, true);

            System.Console.WriteLine("Number of Rows in Data Table: " + dataTable.Rows.Count);
                       
            // Closing the file stream to free all resources
            fstream.Close();
            // ExEnd:1
            
        }
    }
}
