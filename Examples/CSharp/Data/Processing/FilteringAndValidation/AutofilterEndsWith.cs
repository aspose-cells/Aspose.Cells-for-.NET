using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Data.Processing.FilteringAndValidation
{
    public class AutofilterEndsWith
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            // ExStart:1
            // Instantiating a Workbook object containing sample data
            Workbook workbook = new Workbook(sourceDir + "sourseSampleCountryNames.xlsx");

            // Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            // Creating AutoFilter by giving the cells range
            worksheet.AutoFilter.Range = "A1:A18";

            // Initialize filter for rows end with string "ia"
            worksheet.AutoFilter.Custom(0, FilterOperatorType.BeginsWith, "ia");

            //Refresh the filter to show/hide filtered rows
            worksheet.AutoFilter.Refresh();

            // Saving the modified Excel file
            workbook.Save(outputDir +  "outSourseSampleCountryNames.xlsx");
            // ExEnd:1

            Console.WriteLine("AutofilterEndsWith executed successfully.\r\n");
        }
    }
}
