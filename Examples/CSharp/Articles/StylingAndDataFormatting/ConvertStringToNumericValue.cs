using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.StylingAndDataFormatting
{
    public class ConvertStringToNumericValue
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiate workbook object with an Excel file
            Workbook workbook = new Workbook(sourceDir + "sampleConvertStringToNumericValue.xlsx");

            for (int i = 0; i < workbook.Worksheets.Count; i++)
            {
                workbook.Worksheets[i].Cells.ConvertStringToNumericValue();
            }

            workbook.Save(outputDir + "outputConvertStringToNumericValue.xlsx");

            Console.WriteLine("ConvertStringToNumericValue executed successfully.");
        }
    }
}
