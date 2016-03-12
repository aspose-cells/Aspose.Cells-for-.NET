using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Files.Handling
{
    public class SaveInHtmlFormat
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Creating a Workbook object
            Workbook workbook = new Workbook();
          //Save in Html format
            workbook.Save(dataDir + "book1.out.html", SaveFormat.Html);
            
          //ExEnd:1
          }
     }
 }
