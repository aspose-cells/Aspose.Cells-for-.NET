using System.IO;

using Aspose.Cells;
using System;

namespace CSharp.Files.Handling
{
    public class SavingFiletoSomeLocation
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            string filePath = dataDir + "Book1.xls";

            // Load your source workbook
            Workbook workbook = new Workbook(filePath);

            // Save in Excel 97 – 2003 format
            workbook.Save(dataDir + ".output.xls");
            // OR
            workbook.Save(dataDir + ".output..xls", new XlsSaveOptions(SaveFormat.Excel97To2003));

            // Save in Excel2007 xlsx format
            workbook.Save(dataDir + ".output.xlsx", SaveFormat.Xlsx);

            // Save in Excel2007 xlsb format
            workbook.Save(dataDir + ".output.xlsb", SaveFormat.Xlsb);

            // Save in ODS format
            workbook.Save(dataDir + ".output.ods", SaveFormat.ODS);

            // Save in Pdf format
            workbook.Save(dataDir + ".output.pdf", SaveFormat.Pdf);

            // Save in Html format
            workbook.Save(dataDir + ".output.html", SaveFormat.Html);

            // Save in SpreadsheetML format
            workbook.Save(dataDir + ".output.xml", SaveFormat.SpreadsheetML);

            // ExEnd:1


        }
    }
}