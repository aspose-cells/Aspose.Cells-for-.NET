using System.IO;

using Aspose.Cells;

namespace CSharp.Articles
{
    public class HidingDisplayOfZeroValues
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Create a new Workbook object
            Workbook workbook = new Workbook(dataDir+ "book1.xlsx");

            // Get First worksheet of the workbook
            Worksheet sheet = workbook.Worksheets[0];

            // Hide the zero values in the sheet
            sheet.DisplayZeros = false;

            // Save the workbook
            workbook.Save(dataDir+ "outputfile.out.xlsx");
                // ExEnd:1
            
            
        }
    }
}
