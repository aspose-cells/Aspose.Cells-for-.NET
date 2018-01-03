using System;
using System.IO;

using Aspose.Cells;
using System.Data;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ExportVisibleRowsData
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Load the source workbook
            Workbook workbook = new Workbook(sourceDir + "sampleExportVisibleRowsData.xlsx");

            // Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Specify export table options
            ExportTableOptions exportOptions = new ExportTableOptions();
            exportOptions.PlotVisibleRows = true;
            exportOptions.ExportColumnName = true;

            // Export the data from worksheet with export options
            DataTable dataTable = worksheet.Cells.ExportDataTable(0, 0, 10, 4, exportOptions);

            Console.WriteLine("ExportVisibleRowsData executed successfully.\r\n");
        }
    }
}
