using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Files.Handling
{
    public class SaveFileInExcel97-2003format
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Creating a Workbook object
            Workbook workbook = new Workbook();

            //Your Code goes here for any workbook related operations

            //Save in Excel 97 – 2003 format
            workbook.Save(dataDir + "book1.out.xls");

            //OR
            workbook.Save(dataDir + "book1.out.xls", new XlsSaveOptions(SaveFormat.Excel97To2003));
            //ExEnd:1
           }
         }
      }
