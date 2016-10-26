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
            // ExStart:ReadingAndWritingQueryTable
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook from source excel file
            Workbook workbook = new Workbook(dataDir + "Sample.xlsx");

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
            workbook.Save(dataDir + "Output_out_.xlsx");
            // ExEnd:ReadingAndWritingQueryTable
        }
    }
}
