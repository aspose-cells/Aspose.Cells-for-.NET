using System.IO;

using Aspose.Cells;

namespace CSharp.Files.Handling
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
            workbook.Save(dataDir + "book1.out.xls", new XlsSaveOptions(SaveFormat.Excel97To2003));

            // Save in Excel2007 xlsx format
            workbook.Save(dataDir + "book1.out.xlsx", SaveFormat.Xlsx);

            // Save in Excel2007 xlsb format
            workbook.Save(dataDir + "book1.out.xlsb", SaveFormat.Xlsb);

            // Save in ODS format
            workbook.Save(dataDir + "book1.out.ods", SaveFormat.ODS);

            // Save in Pdf format
            workbook.Save(dataDir + "book1.out.pdf", SaveFormat.Pdf);

            // Save in Html format
            workbook.Save(dataDir + "book1.out.html", SaveFormat.Html);

            // Save in SpreadsheetML format
            workbook.Save(dataDir + "book1.out.xml", SaveFormat.SpreadsheetML); 
            // ExEnd:1
        }
    }
}
