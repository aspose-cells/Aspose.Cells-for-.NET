using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.StylingAndDataFormatting
{
    public class ApplyingSubtotalChangeSummaryDirection
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create workbook from source Excel file
            Workbook workbook = new Workbook(sourceDir + "sampleApplyingSubtotalChangeSummaryDirection.xlsx");

            // Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Get the Cells collection in the first worksheet
            Cells cells = worksheet.Cells;

            // Create a cellarea i.e.., A2:B11
            CellArea ca = CellArea.CreateCellArea("A2", "B11");

            // Apply subtotal, the consolidation function is Sum and it will applied to Second column (B) in the list
            cells.Subtotal(ca, 0, ConsolidationFunction.Sum, new int[] { 1 }, true, false, true);

            // Set the direction of outline summary
            worksheet.Outline.SummaryRowBelow = true;

            // Save the excel file
            workbook.Save(outputDir + "outputApplyingSubtotalChangeSummaryDirection.xlsx");

            Console.WriteLine("ApplyingSubtotalChangeSummaryDirection executed successfully.");
        }
    }
}
