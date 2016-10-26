using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithCalculationEngine
{
    public class SetExternalLinksInFormulas
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            
            // Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            // Get first Worksheet
            Worksheet sheet =  workbook.Worksheets[0];

            // Get Cells collection
            Cells cells = sheet.Cells;

            // Set formula with external links
            cells["A1"].Formula = "=SUM('[" + dataDir + "book1.xlsx]Sheet1'!A2, '[" + dataDir + "book1.xlsx]Sheet1'!A4)";

            // Set formula with external links
            cells["A2"].Formula = "='[" + dataDir + "book1.xlsx]Sheet1'!A8";

            // Save the workbook
            workbook.Save(dataDir + "output_out_.xlsx");
            // ExEnd:1
        }
    }
}