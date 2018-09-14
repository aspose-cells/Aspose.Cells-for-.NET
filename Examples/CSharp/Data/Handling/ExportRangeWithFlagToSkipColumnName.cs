using System.IO;

using Aspose.Cells;
using System.Data;
using System;

namespace Aspose.Cells.Examples.CSharp.Data.Handling
{
    public class ExportRangeWithFlagToSkipColumnName
    {
        public static void Main()
        {
            // For complete examples and data files, please go to https://github.com/aspose-cells/Aspose.Cells-for-.NET

            // The path to the documents directory.
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Instantiating a Workbook object
            Workbook workbook = new Workbook(sourceDir + "sampleNamesTable.xlsx");

            // Instantiating a WorkbookDesigner object
            WorkbookDesigner designer = new WorkbookDesigner(workbook);

            // Accessing the range having name "Names"
            var range = designer.Workbook.Worksheets.GetRangeByName("Names");

            // Instantiating the ExportTableOptions object
            ExportTableOptions options = new ExportTableOptions();

            // Setting the ExportColumnName flag to true shows that first line is header and not part of data
            options.ExportColumnName = true;

            // Exporting data with the selected information
            var dataTable = range.ExportDataTable(options);

            Console.WriteLine("ExportRangeWithFlagToSkipColumnName executed successfully.\r\n");

        }
    }
}
