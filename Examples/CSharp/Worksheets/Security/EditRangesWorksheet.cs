using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Worksheets.Security
{
    public class EditRangesWorksheet
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiate a new Workbook
            Workbook book = new Workbook();

            //Get the first (default) worksheet
            Worksheet sheet = book.Worksheets[0];

            //Get the Allow Edit Ranges
            ProtectedRangeCollection allowRanges = sheet.AllowEditRanges;

            //Define ProtectedRange
            ProtectedRange proteced_range;

            //Create the range
            int idx = allowRanges.Add("r2", 1, 1, 3, 3);
            proteced_range = allowRanges[idx];

            //Specify the passoword
            proteced_range.Password = "123";

            //Protect the sheet
            sheet.Protect(ProtectionType.All);

            //Save the Excel file
            book.Save(dataDir + "protectedrange.out.xls");
            //ExEnd:1

        }
    }
}
