using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Worksheets.Security
{
    public class LockCell
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            Workbook workbook = new Workbook(dataDir + "Book1.xlsx");

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            worksheet.Cells["A1"].GetStyle().IsLocked = true;
            // Finally, Protect the sheet now.

            worksheet.Protect(ProtectionType.All);
            workbook.Save(dataDir + "output.xlsx");

            //ExEnd:1


        }
    }
}
