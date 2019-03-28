using System;
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Tables;

namespace Aspose.Cells.Examples.CSharp.Tables
{
    public class ConvertTableToRangeWithOptions
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Open an existing file that contains a table/list object in it
            Workbook workbook = new Workbook(dataDir + "book1.xlsx");

            TableToRangeOptions options = new TableToRangeOptions();
            options.LastRow = 5;

            // Convert the first table/list object (from the first worksheet) to normal range
            workbook.Worksheets[0].ListObjects[0].ConvertToRange(options);

            // Save the file
            workbook.Save(dataDir + "output.xlsx");
            // ExEnd:1

            Console.WriteLine("ConvertTableToRangeWithOptions executed successfully.\r\n");
        }
    }
}
