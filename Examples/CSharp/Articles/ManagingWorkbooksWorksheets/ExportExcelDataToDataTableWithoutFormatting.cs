using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    class ExportExcelDataToDataTableWithoutFormatting
    {
        public static void Run()
        {
            // ExStart:ExportExcelDataToDataTableWithoutFormatting
            // Create workbook
            Workbook workbook = new Workbook();

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access cell A1
            Cell cell = worksheet.Cells["A1"];

            // Put value inside the cell
            cell.PutValue(0.012345);

            // Format the cell that it should display 0.01 instead of 0.012345
            Style style = cell.GetStyle();
            style.Number = 2;
            cell.SetStyle(style);

            // Display the cell values as it displays in excel
            Console.WriteLine("Cell String Value: " + cell.StringValue);

            // Display the cell value without any format
            Console.WriteLine("Cell String Value without Format: " + cell.StringValueWithoutFormat);

            // Export Data Table Options with FormatStrategy as CellStyle
            ExportTableOptions opts = new ExportTableOptions();
            opts.ExportAsString = true;
            opts.FormatStrategy = CellValueFormatStrategy.CellStyle;

            // Export Data Table
            DataTable dt = worksheet.Cells.ExportDataTable(0, 0, 1, 1, opts);

            // Display the value of very first cell
            Console.WriteLine("Export Data Table with Format Strategy as Cell Style: " + dt.Rows[0][0].ToString());

            // Export Data Table Options with FormatStrategy as None
            opts.FormatStrategy = CellValueFormatStrategy.None;
            dt = worksheet.Cells.ExportDataTable(0, 0, 1, 1, opts);

            // Display the value of very first cell
            Console.WriteLine("Export Data Table with Format Strategy as None: " + dt.Rows[0][0].ToString());
            // ExEnd:ExportExcelDataToDataTableWithoutFormatting
        }
    }
}
