using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Worksheets
{
    class UtilizeSheet_SheetId_PropertyOfOpenXml 
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Load source Excel file
            Workbook wb = new Workbook(sourceDir + "sampleSheetId.xlsx");

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Print its Sheet or Tab Id on console
            Console.WriteLine("Sheet or Tab Id: " + ws.TabId);

            //Change Sheet or Tab Id
            ws.TabId = 358;

            //Save the workbook
            wb.Save(outputDir + "outputSheetId.xlsx");

            Console.WriteLine("UtilizeSheet_SheetId_PropertyOfOpenXml executed successfully.\r\n");
        }
    }
}
