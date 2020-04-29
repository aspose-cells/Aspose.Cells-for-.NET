using System;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class CreateUnionRange
    {
        public static void Run()
        {
            // ExStart:1
            // Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Create union range
            UnionRange unionRange = workbook.Worksheets.CreateUnionRange("sheet1!A1:A10,sheet1!C1:C10", 0);

            // Put value "ABCD" in the range
            unionRange.Value = "ABCD";

            // Save the output workbook.
            workbook.Save(outputDir + "CreateUnionRange_out.xlsx");
            // ExEnd:1

            Console.WriteLine("CreateUnionRange executed successfully.");
        }
    }
}