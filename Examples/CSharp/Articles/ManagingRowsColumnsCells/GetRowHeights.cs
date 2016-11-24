using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingRowsColumnsCells
{
    public class GetRowHeights
    {
        public static void Run()
        {
            // ExStart:GetRowHeightsOfSourceRangeToDestinationRange
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object
            Workbook workbook = new Workbook();

            // Source worksheet
            Worksheet srcSheet = workbook.Worksheets[0];

            // Add destination worksheet
            Worksheet dstSheet = workbook.Worksheets.Add("Destination Sheet");

            // Set the row height of the 4th row. This row height will be copied to destination range
            srcSheet.Cells.SetRowHeight(3, 50);

            // Create source range to be copied
            Range srcRange = srcSheet.Cells.CreateRange("A1:D10");

            // Create destination range in destination worksheet
            Range dstRange = dstSheet.Cells.CreateRange("A1:D10");

            // PasteOptions, we want to copy row heights of source range to destination range
            PasteOptions opts = new PasteOptions();
            opts.PasteType = PasteType.RowHeights;

            // Copy source range to destination range with paste options
            dstRange.Copy(srcRange, opts);

            // Write informative message in cell D4 of destination worksheet
            dstSheet.Cells["D4"].PutValue("Row heights of source range copied to destination range");

            // Save the workbook in xlsx format
            workbook.Save(dataDir + "output_out.xlsx", SaveFormat.Xlsx);
            // ExEnd:GetRowHeightsOfSourceRangeToDestinationRange
        }
    }
}
