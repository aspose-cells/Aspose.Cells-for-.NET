using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles.WorkbookScopedNamedRanges
{
    public class WorksheetNamedRange
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Create a new Workbook object
            Workbook workbook = new Workbook();

            //get first worksheet of the workbook
            Worksheet sheet = workbook.Worksheets[0];

            //Get worksheet's cells collection
            Cells cells = sheet.Cells;
            //Create a range of Cells
            Range localRange = cells.CreateRange("A1", "C10");

            //Assign name to range with sheet raference
            localRange.Name = "Sheet1!local";

            //save the workbook
            workbook.Save(dataDir+ "ouput.xls");
            
            
        }
    }
}