using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.CopyRowsColumns
{
    public class PastingRowsColumnsWithPasteOptions
    {
        public static void Main()
        {
            // For complete examples and data files, please go to https://github.com/aspose-cells/Aspose.Cells-for-.NET
            // The path to the documents directory.

            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Load sample excel file
            Workbook wb = new Workbook(sourceDir + "SamplePasteOptions.xlsx");

            // Access the first sheet which contains chart
            Worksheet source = wb.Worksheets[0];

            // Add another sheet named DestSheet
            Worksheet destination = wb.Worksheets.Add("DestSheet");

            // Set CopyOptions.ReferToDestinationSheet to true
            CopyOptions options = new CopyOptions();
            options.ReferToDestinationSheet = true;

            // Set PasteOptions
            PasteOptions pasteOptions = new PasteOptions();
            pasteOptions.PasteType = PasteType.Values;
            pasteOptions.OnlyVisibleCells = true;

            // Copy all the rows of source worksheet to destination worksheet which includes chart as well
            // The chart data source will now refer to DestSheet
            destination.Cells.CopyRows(source.Cells, 0, 0, source.Cells.MaxDisplayRange.RowCount, options, pasteOptions);

            // Save workbook in xlsx format
            wb.Save(outputDir + "outputSamplePasteOptions.xlsx", SaveFormat.Xlsx);

            Console.WriteLine("PastingRowsColumnsWithPasteOptions executed successfully.\r\n");

        }
    }
}
