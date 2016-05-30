using System.IO;

using Aspose.Cells;

namespace CSharp.Worksheets.Security
{
    public class LockCell
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            Workbook workbook = new Workbook(dataDir + "Book1.xlsx");

            // Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            worksheet.Cells["A1"].GetStyle().IsLocked = true;
            // Finally, Protect the sheet now.

            worksheet.Protect(ProtectionType.All);
            workbook.Save(dataDir + "output.xlsx");

            // ExEnd:1


        }
    }
}
