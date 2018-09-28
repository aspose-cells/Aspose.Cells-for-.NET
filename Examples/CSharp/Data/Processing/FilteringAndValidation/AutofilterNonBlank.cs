using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Data.Processing.FilteringAndValidation
{
    public class AutofilterNonBlank
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
            Workbook workbook = new Workbook(sourceDir + "sampleNonBlank.xlsx");

            // Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            // Call MatchNonBlanks function to apply the filter
            worksheet.AutoFilter.MatchNonBlanks(0);

            // Call refresh function to update the worksheet
            worksheet.AutoFilter.Refresh();

            // Saving the modified Excel file
            workbook.Save(outputDir + "outSampleNonBlank.xlsx");
            // ExEnd:1

            Console.WriteLine("AutofilterNonBlank executed successfully.");
        }
    }
}
