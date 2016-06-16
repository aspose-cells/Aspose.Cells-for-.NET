using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    class AssignMacroToFormControl
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            if (!System.IO.Directory.Exists(dataDir))
            {
                System.IO.Directory.CreateDirectory(dataDir); 
            }

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

            dataDir = dataDir + "Output.out.xlsm";
            workbook.Save(dataDir);            
            // ExEnd:1
            Console.WriteLine("\nProcess completed successfully.\nFile saved at " + dataDir);
        }
    }
}
