using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageDatabaseConnection
{
    public class ReadingAndWritingQueryTable
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create workbook from source excel file
            Workbook workbook = new Workbook(sourceDir + "sampleReadingAndWritingQueryTable.xlsx");

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access first Query Table
            QueryTable qt = worksheet.QueryTables[0];

            // Print Query Table Data
            Console.WriteLine("Adjust Column Width: " + qt.AdjustColumnWidth);
            Console.WriteLine("Preserve Formatting: " + qt.PreserveFormatting);

            // Now set Preserve Formatting to true
            qt.PreserveFormatting = true;

            // Save the workbook
            workbook.Save(outputDir + "outputReadingAndWritingQueryTable.xlsx");

            Console.WriteLine("ReadingAndWritingQueryTable executed successfully.");
        }
    }
}
