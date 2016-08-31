using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class ChangeChartDataSource
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load sample excel file
            Workbook wb = new Workbook(dataDir + "sample.xlsx");

            // Access the first sheet which contains chart
            Worksheet source = wb.Worksheets[0];

            // Add another sheet named DestSheet
            Worksheet destination = wb.Worksheets.Add("DestSheet");

            // Set CopyOptions.ReferToDestinationSheet to true
            CopyOptions options = new CopyOptions();
            options.ReferToDestinationSheet = true;

            // Copy all the rows of source worksheet to destination worksheet which includes chart as well
            // The chart data source will now refer to DestSheet
            destination.Cells.CopyRows(source.Cells, 0, 0, source.Cells.MaxDisplayRange.RowCount, options);

            // Save workbook in xlsx format
            wb.Save(dataDir + "output_out_.xlsx", SaveFormat.Xlsx);
            // ExEnd:1           
            
        }
    }
}
