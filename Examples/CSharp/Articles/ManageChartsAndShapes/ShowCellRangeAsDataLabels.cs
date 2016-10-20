using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    public class ShowCellRangeAsDataLabels
    {
        public static void Run()
        {
            // ExStart:ShowCellRangeAsDataLabels
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook from the source Excel file
            Workbook workbook = new Workbook(dataDir + "source.xlsx");

            // Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access the chart inside the worksheet
            Chart chart = worksheet.Charts[0];

            // Check the "Label Contains - Value From Cells"
            DataLabels dataLabels = chart.NSeries[0].DataLabels;
            dataLabels.ShowCellRange = true;

            // Save the workbook
            workbook.Save(dataDir + "output_out_.xlsx");
            // ExEnd:ShowCellRangeAsDataLabels
        }
    }
}
