using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class SetExternalLinksInFormulas
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            

  
            //Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            //Get first Worksheet
            Worksheet sheet =  workbook.Worksheets[0];

            //Get Cells collection
            Cells cells = sheet.Cells;

            //Set formula with external links
            cells["A1"].Formula = "=SUM('[" + dataDir + "book1.xlsx]Sheet1'!A2, '[" + dataDir + "book1.xlsx]Sheet1'!A4)";

            //Set formula with external links
            cells["A2"].Formula = "='[" + dataDir + "book1.xlsx]Sheet1'!A8";

            //Save the workbook
            workbook.Save(dataDir+ "output.out.xlsx");


            
            
        }
    }
}