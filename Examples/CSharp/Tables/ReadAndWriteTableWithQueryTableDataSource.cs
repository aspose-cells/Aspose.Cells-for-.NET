using System;
using Aspose.Cells.Tables;

namespace Aspose.Cells.Examples.CSharp.Tables
{
    public class ReadAndWriteTableWithQueryTableDataSource
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the source directory.
            string sourceDir = RunExamples.Get_SourceDirectory();
            string outputDir = RunExamples.Get_OutputDirectory();

            // Load workbook object
            Workbook workbook = new Workbook(sourceDir + "SampleTableWithQueryTable.xls");

            Worksheet worksheet = workbook.Worksheets[0];

            ListObject table = worksheet.ListObjects[0];

            // Check the data source type if it is query table
            if (table.DataSourceType == TableDataSourceType.QueryTable)
            {
                table.ShowTotals = true;
            }

            // Save the file
            workbook.Save(outputDir + "SampleTableWithQueryTable_out.xls");
            // ExEnd:1

            Console.WriteLine("ReadAndWriteTableWithQueryTableDataSource executed successfully.");

        }
    }
}
