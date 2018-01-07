using System;
using System.Data;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    class IgnoreHiddenColumnsDataTable
    {
        public static void Run()
        {
            string sourceDir = RunExamples.Get_SourceDirectory();

            Workbook workbook = new Workbook(sourceDir + "sampleIgnoreHiddenColumnsDataTable.xlsx");

            Worksheet worksheet = workbook.Worksheets[0];

            ExportTableOptions opts = new ExportTableOptions();
            opts.ExportColumnName = true;
            opts.PlotVisibleColumns = true;

            int totalRows = worksheet.Cells.MaxRow + 1;
            int totalColumns = worksheet.Cells.MaxColumn + 1;

            DataTable dt = worksheet.Cells.ExportDataTable(0, 0, totalRows, totalColumns, opts);

            Console.WriteLine("IgnoreHiddenColumnsDataTable executed successfully.");
        }
    }
}
