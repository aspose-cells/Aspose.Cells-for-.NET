using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Worksheets.Security.Unprotect
{
    public class UnprotectingPasswordProtectedWorksheet
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiating a Workbook object
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];       

            //Unprotecting the worksheet with a password
            worksheet.Unprotect("aspose");
            
            //Save Workbook
            workbook.Save(dataDir + "output.out.xls");
            //ExEnd:1

        }
    }
}
