using System.IO;

using Aspose.Cells;

namespace CSharp.Data.AddOn.NamedRanges
{
    public class RenameNamedRange
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Open an existing Excel file that has a (global) named range "TestRange" in it
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            // Get the first worksheet
            Worksheet sheet = workbook.Worksheets[0];

            // Get the Cells of the sheet
            Cells cells = sheet.Cells;

            // Get the named range "MyRange"
            Name name = workbook.Worksheets.Names["TestRange"];

            // Rename it
            name.Text = "NewRange";

            // Save the Excel file
            workbook.Save(dataDir + "RenamingRange.out.xlsx"); 
            // ExEnd:1
        }
    }
}
