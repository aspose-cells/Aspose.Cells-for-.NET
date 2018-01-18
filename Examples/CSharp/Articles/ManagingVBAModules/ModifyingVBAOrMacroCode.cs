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
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create workbook object from source Excel file
            Workbook workbook = new Workbook(sourceDir + "sampleModifyingVBAOrMacroCode.xlsm");

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
            workbook.Save(outputDir + "outputModifyingVBAOrMacroCode.xlsm");

            Console.WriteLine("ModifyingVBAOrMacroCode executed successfully.");
        }
    }
}
