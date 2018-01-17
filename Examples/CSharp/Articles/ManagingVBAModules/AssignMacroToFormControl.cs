using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingVBAModules
{
    class AssignMacroToFormControl
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();
            
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
            Aspose.Cells.Worksheet sheet = workbook.Worksheets[0];

            int moduleIdx = workbook.VbaProject.Modules.Add(sheet);
            Aspose.Cells.Vba.VbaModule module = workbook.VbaProject.Modules[moduleIdx];
            module.Codes =
                "Sub ShowMessage()" + "\r\n" +
                "    MsgBox \"Welcome to Aspose!\"" + "\r\n" +
                "End Sub";

            Aspose.Cells.Drawing.Button button = sheet.Shapes.AddButton(2, 0, 2, 0, 28, 80);
            button.Placement = Aspose.Cells.Drawing.PlacementType.FreeFloating;
            button.Font.Name = "Tahoma";
            button.Font.IsBold = true;
            button.Font.Color = System.Drawing.Color.Blue;
            button.Text = "Aspose";

            button.MacroName = sheet.Name + ".ShowMessage";

            workbook.Save(outputDir + "outputAssignMacroToFormControl.xlsm");

            Console.WriteLine("AssignMacroToFormControl executed successfully.");
        }
    }
}
