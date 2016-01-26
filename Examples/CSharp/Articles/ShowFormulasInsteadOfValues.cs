using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class ShowFormulasInsteadOfValues
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            string filePath = dataDir+ "source.xlsx";

            //Load the source workbook
            Workbook workbook = new Workbook(filePath);

            //Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Show formulas of the worksheet
            worksheet.ShowFormulas = true;

            //Save the workbook
            workbook.Save(dataDir+ ".out.xlsx");
            
        }
    }
}