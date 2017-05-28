using System;
using System.IO;

using Aspose.Cells;
using System.Data;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class ExportHTMLStringValueOfCellsToDataTable
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Load sample Excel file
            Workbook wb = new Workbook(sourceDir + "sampleExportTableAsHtmlString.xlsx");

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Specify export table options and set ExportAsHtmlString to true
            ExportTableOptions opts = new ExportTableOptions();
            opts.ExportColumnName = false;
            opts.ExportAsHtmlString = true;

            //Export the cells data to data table with the specified export table options
            DataTable dt = ws.Cells.ExportDataTable(0, 0, 3, 3, opts);

            //Print the cell html string value that is in third row and second column 
            Console.WriteLine(dt.Rows[2][1].ToString());

        }
    }
}