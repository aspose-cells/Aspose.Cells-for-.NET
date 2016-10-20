using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Charts;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    public class RichTextCustomDataLabel
    {
        public static void Run()
        {
            // ExStart:RichTextCustomDataLabelOfChartPoint
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create a workbook from source Excel file
            Workbook workbook = new Workbook(dataDir + "sample.xlsx");

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access the first chart inside the sheet
            Chart chart = worksheet.Charts[0];

            // Access the data label of first series first point
            DataLabels dlbls = chart.NSeries[0].Points[0].DataLabels;

            // Set data label text
            dlbls.Text = "Rich Text Label";

            // Set the font setting of the first 10 characters
            FontSetting fntSetting = dlbls.Characters(0, 10);
            fntSetting.Font.Color = Color.Red;
            fntSetting.Font.IsBold = true;

            // Save the workbook
            workbook.Save(dataDir + "output_out_.xlsx");
            // ExEnd:RichTextCustomDataLabelOfChartPoint
        }
    }
}
