using System;
using System.Data;
using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    class IgnoreHiddenColumnsDataTable
    {
        static void Main()
        {
            //ExStart:1
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string inputPath = dataDir + "Sample.xlsx";

            Workbook workbook = new Workbook(inputPath);

            Worksheet worksheet = workbook.Worksheets[0];

            ExportTableOptions opts = new ExportTableOptions();
            opts.PlotVisibleColumns = true;

            int totalRows = worksheet.Cells.MaxRow + 1;
            int totalColumns = worksheet.Cells.MaxColumn + 1;

            DataTable dt = worksheet.Cells.ExportDataTable(0, 0, totalRows, totalColumns, opts);
            //ExEnd:1
        }
    }
}
