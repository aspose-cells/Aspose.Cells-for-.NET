using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithCalculationEngine
{
    public class SetExternalLinksInFormulas
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            Workbook _workbook = new Workbook();
            Worksheet _worksheet = _workbook.Worksheets[0];

            _worksheet.Cells["A2"].PutValue(31);
            _worksheet.Cells["A3"].PutValue(32);
            _worksheet.Cells["A4"].PutValue(33);
            _worksheet.Cells["A8"].PutValue(530);

            _workbook.Save(outputDir + "ExternalData.xlsx");

            // Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            // Get first Worksheet
            Worksheet sheet =  workbook.Worksheets[0];

            // Get Cells collection
            Cells cells = sheet.Cells;

            // Set formula with external links
            cells["A1"].Formula = "=SUM('[" + outputDir + "ExternalData.xlsx]Sheet1'!A2, '[" + outputDir + "ExternalData.xlsx]Sheet1'!A4)";

            // Set formula with external links
            cells["A2"].Formula = "='[" + outputDir + "ExternalData.xlsx]Sheet1'!A8";

            // Save the workbook
            workbook.Save(outputDir + "outputSetExternalLinksInFormulas.xlsx");

            Console.WriteLine("SetExternalLinksInFormulas executed successfully.");
        }
    }
}