using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingVBAModules
{
    public class AddVBAModuleOrCode
    {
        public static void Run()
        {
            // ExStart:AddVBAModuleOrCode
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create new workbook
            Workbook workbook = new Workbook();

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Add VBA Module
            int idx = workbook.VbaProject.Modules.Add(worksheet);

            // Access the VBA Module, set its name and codes
            Aspose.Cells.Vba.VbaModule module = workbook.VbaProject.Modules[idx];
            module.Name = "TestModule";

            module.Codes = "Sub ShowMessage()" + "\r\n" +
            "    MsgBox \"Welcome to Aspose!\"" + "\r\n" +
            "End Sub";

            // Save the workbook
            workbook.Save(dataDir + "output_out_.xlsm", SaveFormat.Xlsm);
            // ExEnd:AddVBAModuleOrCode
        }
    }
}
