using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class SavingFiles
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
            workbook.Save(dataDir + "book1.out.xls");

            // OR
            workbook.Save(dataDir + "book1.out.xls", SaveFormat.Excel97To2003);

            // Save in Excel2007 xlsx format
            workbook.Save(dataDir + "book1.out.xlsx");

            // Save in Excel2007 xlsb format
            workbook.Save(dataDir + "book1.out.xlsb");

            // Save in ODS format
            workbook.Save(dataDir + "book1.out.ods");

            // Save in Pdf format
            workbook.Save(dataDir + "book1.out.pdf");

            // Save in Html format
            workbook.Save(dataDir + "book1.out.html");

            // Save in SpreadsheetML format
            workbook.Save(dataDir + "book1.out.xml"); 
            // ExEnd:1
        }
    }
}
