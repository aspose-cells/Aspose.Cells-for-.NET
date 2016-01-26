using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Files.Utility
{
    public class Excel2PDFConversion
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiate the Workbook object
            //Open an Excel file
            Workbook workbook = new Workbook(dataDir + "abc.xlsx");

            //Save the document in PDF format
            workbook.Save(dataDir + "outBook2.pdf", SaveFormat.Pdf);

            // Display result, so that user knows the processing has finished.
            System.Console.WriteLine("Conversion completed.");
        }
    }
}