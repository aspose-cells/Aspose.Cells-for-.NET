using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    public class DisableTextWrappingForDataLabels
    {
        public static void Run()
        {
            // ExStart:DisableTextWrappingForDataLabels
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load the sample Excel file inside the workbook object
            Workbook workbook = new Workbook(dataDir + "sample.xlsx");

            // Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access the first chart inside the worksheet
            Chart chart = worksheet.Charts[0];

            // Disable the Text Wrapping of Data Labels in all Series
            chart.NSeries[0].DataLabels.IsTextWrapped = false;
            chart.NSeries[1].DataLabels.IsTextWrapped = false;
            chart.NSeries[2].DataLabels.IsTextWrapped = false;

            // Save the workbook
            workbook.Save(dataDir + "Output_out_.xlsx");
            // ExEnd:DisableTextWrappingForDataLabels
        }
    }
}
