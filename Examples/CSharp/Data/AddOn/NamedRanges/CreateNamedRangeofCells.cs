using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Data.AddOn.NamedRanges
{
    public class CreateNamedRangeofCells
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiating a Workbook object
            // Opening the Excel file through the file stream
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            // Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            // Creating a named range
            Range range = worksheet.Cells.CreateRange("B4", "G14");

            // Setting the name of the named range
            range.Name = "TestRange";

            // Saving the modified Excel file
            workbook.Save(dataDir + "output.out.xls");
            // ExEnd:1

        }
    }
}
