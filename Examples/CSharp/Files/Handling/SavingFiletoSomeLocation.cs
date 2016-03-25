using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.Files.Handling
{
    public class SavingFiletoSomeLocation
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



            string filePath = dataDir + "Book1.xls";

            //Load your source workbook
            Workbook workbook = new Workbook(filePath);


            //Save in Excel 97 – 2003 format
            workbook.Save(filePath + ".output.xls");

            //OR
            workbook.Save(filePath + ".output..xls", new XlsSaveOptions(SaveFormat.Excel97To2003));

            //Save in Excel2007 xlsx format
            workbook.Save(filePath + ".output.xlsx", SaveFormat.Xlsx);

            //Save in Excel2007 xlsb format
            workbook.Save(filePath + ".output.xlsb", SaveFormat.Xlsb);

            //Save in ODS format
            workbook.Save(filePath + ".output.ods", SaveFormat.ODS);

            //Save in Pdf format
            workbook.Save(filePath + ".output.pdf", SaveFormat.Pdf);

            //Save in Html format
            workbook.Save(filePath + ".output.html", SaveFormat.Html);

            //Save in SpreadsheetML format
            workbook.Save(filePath + ".output.xml", SaveFormat.SpreadsheetML);

            //ExEnd:1


        }
    }
}