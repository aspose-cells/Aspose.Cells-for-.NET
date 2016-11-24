using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageConditionalFormatting
{
    public class AddColorScales
    {
        public static void Run()
        {
            // ExStart:AddColorScales
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook
            Workbook workbook = new Workbook();

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Add some data in cells
            worksheet.Cells["A1"].PutValue("2-Color Scale");
            worksheet.Cells["D1"].PutValue("3-Color Scale");

            for (int i = 2; i <= 15; i++)
            {
                worksheet.Cells["A" + i].PutValue(i);
                worksheet.Cells["D" + i].PutValue(i);
            }

            // Adding 2-Color Scale Conditional Formatting
            CellArea ca = CellArea.CreateCellArea("A2", "A15");

            int idx = worksheet.ConditionalFormattings.Add();
            FormatConditionCollection fcc = worksheet.ConditionalFormattings[idx];
            fcc.AddCondition(FormatConditionType.ColorScale);
            fcc.AddArea(ca);

            FormatCondition fc = worksheet.ConditionalFormattings[idx][0];
            fc.ColorScale.Is3ColorScale = false;
            fc.ColorScale.MaxColor = Color.LightBlue;
            fc.ColorScale.MinColor = Color.LightGreen;

            // Adding 3-Color Scale Conditional Formatting
            ca = CellArea.CreateCellArea("D2", "D15");

            idx = worksheet.ConditionalFormattings.Add();
            fcc = worksheet.ConditionalFormattings[idx];
            fcc.AddCondition(FormatConditionType.ColorScale);
            fcc.AddArea(ca);

            fc = worksheet.ConditionalFormattings[idx][0];
            fc.ColorScale.Is3ColorScale = true;
            fc.ColorScale.MaxColor = Color.LightBlue;
            fc.ColorScale.MidColor = Color.Yellow;
            fc.ColorScale.MinColor = Color.LightGreen;

            // Save the workbook
            workbook.Save(dataDir + "output_out.xlsx");
            // ExEnd:AddColorScales
        }
    }
}
