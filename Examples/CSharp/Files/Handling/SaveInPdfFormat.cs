using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Files.Handling
{
    public class SaveInPdfFormat
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Creating a Workbook object
            Workbook workbook = new Workbook();
              //Save in Pdf format
            workbook.Save(dataDir + "book1.out.pdf", SaveFormat.Pdf);

            \\ExEnd:1
        }
    }
}
