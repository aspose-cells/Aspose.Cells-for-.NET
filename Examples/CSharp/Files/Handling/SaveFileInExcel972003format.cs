using System.IO;

using Aspose.Cells;

namespace CSharp.Files.Handling
{
    public class SaveFileInExcel972003format
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Creating a Workbook object
            Workbook workbook = new Workbook();

            // Your Code goes here for any workbook related operations

            // Save in Excel 97 – 2003 format
            workbook.Save(dataDir + "output.xls");

            // OR
            workbook.Save(dataDir + "output.xls", new XlsSaveOptions(SaveFormat.Excel97To2003));
            // ExEnd:1
           }
         }
      }
