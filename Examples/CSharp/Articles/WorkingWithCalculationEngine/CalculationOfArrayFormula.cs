using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithCalculationEngine
{
    public class CalculationOfArrayFormula
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create workbook from source excel file
            Workbook workbook = new Workbook(sourceDir + "sampleCalculationOfArrayFormula.xlsx");

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // When you will put 100 in B1, then all Data Table values formatted as Yellow will become 120
            worksheet.Cells["B1"].PutValue(100);

            // Calculate formula, now it also calculates Data Table array formula
            workbook.CalculateFormula();

            // Save the workbook in pdf format
            workbook.Save(outputDir + "outputCalculationOfArrayFormula.pdf");

            Console.WriteLine("CalculationOfArrayFormula executed successfully.");
        }
    }
}
