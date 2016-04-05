using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Files.Utility
{
    public class XlstoPDFDirectConversation
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiate the Workbook object
            //Open an Excel file
            Workbook workbook = new Workbook(dataDir + "Book1.xls");


            //Save the document in PDF format
            workbook.Save(dataDir + "output.pdf", SaveFormat.Pdf);

            //ExEnd:1
        }
    }
}
