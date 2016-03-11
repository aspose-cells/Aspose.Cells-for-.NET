using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Data.AddOn.Hyperlinks
{
    public class AddingLinkToExternalFile
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Adding a new worksheet to the Excel object
            int i = workbook.Worksheets.Add();

            //Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[i];

            //Adding an internal hyperlink to the "B9" cell of the other worksheet "Sheet2" in
            //the same Excel file
            worksheet.Hyperlinks.Add("A5", 1, 1, dataDir + "book1.xls");

            //Saving the Excel file
            workbook.Save(dataDir + "output.out.xls");
            //ExEnd:1

        }
    }
}
