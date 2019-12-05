using System;

namespace Aspose.Cells.Examples.CSharp._CellsHelper
{
    public class GetTextWidth
    {
        public static void Run()
        {
            string sourceDir = RunExamples.Get_SourceDirectory();

            // ExStart:1
            Workbook workbook = new Workbook(sourceDir + "GetTextWidthSample.xlsx");

            Console.WriteLine("Text width: " + CellsHelper.GetTextWidth(workbook.Worksheets[0].Cells["A1"].StringValue, workbook.DefaultStyle.Font, 1));
            // ExEnd:1

            Console.WriteLine("GetTextWidth executed successfully.");
        }
    }
}
