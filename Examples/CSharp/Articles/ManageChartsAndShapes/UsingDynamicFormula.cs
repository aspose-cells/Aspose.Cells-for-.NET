using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    public class UsingDynamicFormula
    {
        public static void Run()
        {
            // ExStart:CreateDynamicChartsUsingDynamicFormula
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create a workbook object
            var workbook = new Workbook();

            // Get the first worksheet
            var worksheet = workbook.Worksheets[0];

            // Create a range in the second worksheet
            var range = worksheet.Cells.CreateRange("C21", "C24");

            // Name the range
            range.Name = "MyRange";

            // Fill different cells with data in the range
            range[0, 0].PutValue("North");
            range[1, 0].PutValue("South");
            range[2, 0].PutValue("East");
            range[3, 0].PutValue("West");

            ComboBox comboBox = worksheet.Shapes.AddComboBox(15, 0, 2, 0, 17, 64);
            comboBox.InputRange = "=MyRange";
            comboBox.LinkedCell = "=B16";
            comboBox.SelectedIndex = 0;
            Cell cell = worksheet.Cells["B16"];
            Style style = cell.GetStyle();
            style.Font.Color = Color.White;
            cell.SetStyle(style);

            worksheet.Cells["C16"].Formula = "=INDEX(Sheet1!$C$21:$C$24,$B$16,1)";

            // Put some data for chart source
            // Data Headers
            worksheet.Cells["D15"].PutValue("Jan");
            worksheet.Cells["D20"].PutValue("Jan");

            worksheet.Cells["E15"].PutValue("Feb");
            worksheet.Cells["E20"].PutValue("Feb");

            worksheet.Cells["F15"].PutValue("Mar");
            worksheet.Cells["F20"].PutValue("Mar");

            worksheet.Cells["G15"].PutValue("Apr");
            worksheet.Cells["G20"].PutValue("Apr");

            worksheet.Cells["H15"].PutValue("May");
            worksheet.Cells["H20"].PutValue("May");

            worksheet.Cells["I15"].PutValue("Jun");
            worksheet.Cells["I20"].PutValue("Jun");

            // Data
            worksheet.Cells["D21"].PutValue(304);
            worksheet.Cells["D22"].PutValue(402);
            worksheet.Cells["D23"].PutValue(321);
            worksheet.Cells["D24"].PutValue(123);

            worksheet.Cells["E21"].PutValue(300);
            worksheet.Cells["E22"].PutValue(500);
            worksheet.Cells["E23"].PutValue(219);
            worksheet.Cells["E24"].PutValue(422);

            worksheet.Cells["F21"].PutValue(222);
            worksheet.Cells["F22"].PutValue(331);
            worksheet.Cells["F23"].PutValue(112);
            worksheet.Cells["F24"].PutValue(350);

            worksheet.Cells["G21"].PutValue(100);
            worksheet.Cells["G22"].PutValue(200);
            worksheet.Cells["G23"].PutValue(300);
            worksheet.Cells["G24"].PutValue(400);

            worksheet.Cells["H21"].PutValue(200);
            worksheet.Cells["H22"].PutValue(300);
            worksheet.Cells["H23"].PutValue(400);
            worksheet.Cells["H24"].PutValue(500);

            worksheet.Cells["I21"].PutValue(400);
            worksheet.Cells["I22"].PutValue(200);
            worksheet.Cells["I23"].PutValue(200);
            worksheet.Cells["I24"].PutValue(100);

            // Dynamically load data on selection of Dropdown value
            worksheet.Cells["D16"].Formula = "=IFERROR(VLOOKUP($C$16,$C$21:$I$24,2,FALSE),0)";
            worksheet.Cells["E16"].Formula = "=IFERROR(VLOOKUP($C$16,$C$21:$I$24,3,FALSE),0)";
            worksheet.Cells["F16"].Formula = "=IFERROR(VLOOKUP($C$16,$C$21:$I$24,4,FALSE),0)";
            worksheet.Cells["G16"].Formula = "=IFERROR(VLOOKUP($C$16,$C$21:$I$24,5,FALSE),0)";
            worksheet.Cells["H16"].Formula = "=IFERROR(VLOOKUP($C$16,$C$21:$I$24,6,FALSE),0)";
            worksheet.Cells["I16"].Formula = "=IFERROR(VLOOKUP($C$16,$C$21:$I$24,7,FALSE),0)";

            // Create Chart
            int index = worksheet.Charts.Add(ChartType.Column, 0, 3, 12, 9);
            Chart chart = worksheet.Charts[index];
            chart.NSeries.Add("='Sheet1'!$D$16:$I$16", false);
            chart.NSeries[0].Name = "=C16";
            chart.NSeries.CategoryData = "=$D$15:$I$15";

            // Save result on disc
            workbook.Save(dataDir + "output_out.xlsx");
            // ExEnd:CreateDynamicChartsUsingDynamicFormula
        }
    }
}
