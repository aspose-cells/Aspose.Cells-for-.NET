using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class ReadingCSVMultipleEncodings
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            string filePath = dataDir + "MultiEncoded.csv";

            //Set Multi Encoded Property to True
            TxtLoadOptions options = new TxtLoadOptions();
            options.IsMultiEncoded = true;

            //Load the CSV file into Workbook
            Workbook workbook = new Workbook(filePath, options);

            //Save it in XLSX format
            workbook.Save( filePath + ".out.xlsx", SaveFormat.Xlsx);
        }
    }
}