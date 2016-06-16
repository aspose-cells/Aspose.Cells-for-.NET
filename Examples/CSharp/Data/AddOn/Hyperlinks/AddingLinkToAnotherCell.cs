using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Data.AddOn.Hyperlinks
{
    public class AddingLinkToAnotherCell
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Adding a new worksheet to the Workbook object
            workbook.Worksheets.Add();

            // Obtaining the reference of the first (default) worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Adding an internal hyperlink to the "B9" cell of the other worksheet "Sheet2" in
            // The same Excel file
            worksheet.Hyperlinks.Add("B3", 1, 1, "Sheet2!B9");

            // Saving the Excel file
            workbook.Save(dataDir + "output.out.xls");
            // ExEnd:1

        }
    }
}
