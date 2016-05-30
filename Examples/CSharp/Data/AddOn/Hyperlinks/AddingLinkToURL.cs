using System.IO;

using Aspose.Cells;

namespace CSharp.Data.AddOn.Hyperlinks
{
    public class AddingLinkToURL
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

            // Obtaining the reference of the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Adding a hyperlink to a URL at "A1" cell
            worksheet.Hyperlinks.Add("A1", 1, 1, "http:// Www.aspose.com");

            // Saving the Excel file
            workbook.Save(dataDir + "output.out.xls");
            // ExEnd:1

        }
    }
}
