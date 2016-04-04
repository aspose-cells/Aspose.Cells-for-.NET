using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Files.Utility
{
    public class ConvertingToHTMLFiles
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Specify the file path
            string filePath = dataDir + "Book1.xlsx";

            //Specify the HTML Saving Options
            HtmlSaveOptions save = new HtmlSaveOptions(SaveFormat.Html);

            //Instantiate a workbook and open the template XLSX file
            Workbook wb = new Workbook(filePath);

            //Save the MHT file
            wb.Save(dataDir + "output.html", save);
            //ExEnd:1
        }
    }
}