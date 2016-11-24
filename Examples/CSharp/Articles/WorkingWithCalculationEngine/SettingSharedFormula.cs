using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithCalculationEngine
{
    public class SettingSharedFormula
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiate a Workbook from existing file
            Workbook workbook = new Workbook(dataDir + "source.xlsx");

            // Get the cells collection in the first worksheet
            Cells cells = workbook.Worksheets[0].Cells;

            // Apply the shared formula in the range i.e.., B2:B14
            cells["B2"].SetSharedFormula("=A2*0.09", 13, 1);

            // Save the excel file
            workbook.Save(dataDir + "Output_out.xlsx", SaveFormat.Xlsx);
            // ExEnd:1
        }
    }
}
