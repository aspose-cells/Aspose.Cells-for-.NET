using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class DisableCompatibilityChecker
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Open a template file
            Workbook workbook = new Workbook(dataDir+ "sample.xlsx");

            //Disable the compatibility checker
            workbook.Settings.CheckComptiliblity = false;

            //Saving the Excel file
            workbook.Save(dataDir+ "Output_BK_CompCheck.out.xlsx");
            
            
        }
    }
}