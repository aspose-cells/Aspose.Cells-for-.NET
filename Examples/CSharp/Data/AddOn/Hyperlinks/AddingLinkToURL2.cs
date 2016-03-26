using System.IO;
using System.Drawing;
using Aspose.Cells;

namespace Aspose.Cells.Examples.Data.AddOn.Hyperlinks
{
    public class AddingLinkToURL2
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Adding a new worksheet to the Workbook object
            int i = workbook.Worksheets.Add();

            //Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[i];

            //Putting a value to the "A1" cell
            worksheet.Cells["A1"].PutValue("Visit Aspose");

            //Setting the font color of the cell to Blue
            worksheet.Cells["A1"].GetStyle().Font.Color = Color.Blue;

            //Setting the font of the cell to Single Underline
            worksheet.Cells["A1"].GetStyle().Font.Underline = FontUnderlineType.Single;

            //Adding a hyperlink to a URL at "A1" cell
            worksheet.Hyperlinks.Add("A1", 1, 1, "http://www.aspose.com");

            //Saving the Excel file
            workbook.Save(dataDir + "book1.xls");
            //ExEnd:1


        }
    }
}
