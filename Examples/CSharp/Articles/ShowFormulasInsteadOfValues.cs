using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ShowFormulasInsteadOfValues
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            string filePath = dataDir+ "source.xlsx";

            // Load the source workbook
            Workbook workbook = new Workbook(filePath);

            // Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Show formulas of the worksheet
            worksheet.ShowFormulas = true;

            // Save the workbook
            workbook.Save(dataDir+ ".out.xlsx");
            
        }
    }
}