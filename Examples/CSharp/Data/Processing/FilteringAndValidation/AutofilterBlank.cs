using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Data.Processing.FilteringAndValidation
{
    public class AutofilterBlank
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            // ExStart:1
            // Instantiating a Workbook object
            // Opening the Excel file through the file stream
            Workbook workbook = new Workbook(sourceDir + "sampleBlank.xlsx");

            // Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            // Call MatchBlanks function to apply the filter
            worksheet.AutoFilter.MatchBlanks(0);

            // Call refresh function to update the worksheet
            worksheet.AutoFilter.Refresh();

            // Saving the modified Excel file
            workbook.Save(outputDir + "outSampleBlank.xlsx");
            // ExEnd:1

            Console.WriteLine("AutofilterBlank executed successfully.");
        }
    }
}
