using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class InsertLinkedPicture
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Instantiate a new Workbook.
            Workbook workbook = new Workbook();
            // Insert a linked picture (from Web Address) to B2 Cell.
            Aspose.Cells.Drawing.Picture pic = workbook.Worksheets[0].Shapes.AddLinkedPicture(1, 1, 100, 100, "http:// Www.aspose.com/Images/aspose-logo.jpg");
            // Set the height and width of the inserted image.
            pic.HeightInch = 1.04;
            pic.WidthInch = 2.6;
            // Save the Excel file.
            workbook.Save(dataDir+ "outLinkedPicture.out.xlsx");
            // ExEnd:1
            
        }
    }
}
