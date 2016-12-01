using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Formatting
{
    public class UsingCopyMethod
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(dataDir + "Book1.xlsx", FileMode.Open);

            // Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            // Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            // Copying conditional format settings from cell "A1" to cell "B1"
            //worksheet.CopyConditionalFormatting(0, 0, 0, 1);

            int TotalRowCount = 0;

            for (int i = 0; i < workbook.Worksheets.Count; i++)
            {
                Worksheet sourceSheet = workbook.Worksheets[i];

                Range sourceRange = sourceSheet.Cells.MaxDisplayRange;

                Range destRange = worksheet.Cells.CreateRange(sourceRange.FirstRow + TotalRowCount, sourceRange.FirstColumn,
                      sourceRange.RowCount, sourceRange.ColumnCount);

                destRange.Copy(sourceRange);

                TotalRowCount = sourceRange.RowCount + TotalRowCount;
            }
            

            // Saving the modified Excel file
            workbook.Save(dataDir + "output.xls");

            // Closing the file stream to free all resources
            fstream.Close();

            // ExEnd:1
        }
    }
}