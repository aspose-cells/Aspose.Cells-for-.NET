using System.IO;

using Aspose.Cells;

namespace CSharp.RowsColumns.InsertingAndDeleting
{
    public class DeletingMultipleRows
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(dataDir + "Book1.xlsx", FileMode.OpenOrCreate);

            // Instantiating a Workbook object
            // Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            // Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            // Deleting 10 rows from the worksheet starting from 3rd row
            worksheet.Cells.DeleteRows(2, 10);

            // Saving the modified Excel file
            workbook.Save(dataDir + "output.xlsx");

            // Closing the file stream to free all resources
            fstream.Close();
            // ExEnd:1
 
        }
    }
}
