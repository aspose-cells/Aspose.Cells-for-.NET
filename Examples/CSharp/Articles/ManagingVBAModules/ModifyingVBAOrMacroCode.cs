using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Vba;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingVBAModules
{
    public class ModifyingVBAOrMacroCode
    {
        public static void Run()
        {
            // ExStart:ModifyingVBAOrMacroCode
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object from source Excel file
            Workbook workbook = new Workbook(dataDir + "sample.xlsm");

            // Change the VBA Module Code
            foreach (VbaModule module in workbook.VbaProject.Modules)
            {
                string code = module.Codes;

                // Replace the original message with the modified message
                if (code.Contains("This is test message."))
                {
                    code = code.Replace("This is test message.", "This is Aspose.Cells message.");
                    module.Codes = code;
                }
            }

            // Save the output Excel file
            workbook.Save(dataDir + "output_out_.xlsm");
            // ExEnd:ModifyingVBAOrMacroCode
        }
    }
}
