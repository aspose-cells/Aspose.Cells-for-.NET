using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace CSharp.RowsColumns
{
    public class AutofitColumninSpecificRange
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            string InputPath = dataDir + "Book1.xlsx";

            // Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(InputPath, FileMode.Open);

            // Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            // Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            // Auto-fitting the Column of the worksheet
            worksheet.AutoFitColumn(4, 4, 6);

            // Saving the modified Excel file
            workbook.Save(dataDir + "output.xlsx");

            // Closing the file stream to free all resources
            fstream.Close();
            // ExEnd:1

        }
    }
}