using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingVBAModules
{
    public class CheckVbaSignatureIsValid
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();
            
            Workbook workbook = new Workbook(sourceDir + "sampleCheckVbaSignatureIsValid.xlsm");

            // Signature is valid
            Console.WriteLine("Is VBA Code Project Valid Signed: " + workbook.VbaProject.IsValidSigned);

            // Modify the VBA Code, save the workbook then reload
            // VBA Code Signature will now be invalid
            string code = workbook.VbaProject.Modules[1].Codes;
            code = code.Replace("Welcome to Aspose", "Welcome to Aspose.Cells");
            workbook.VbaProject.Modules[1].Codes = code;

            // Save
            MemoryStream ms = new MemoryStream();
            workbook.Save(ms, SaveFormat.Xlsm);

            // Reload
            ms.Position = 0;
            workbook = new Workbook(ms, new LoadOptions(LoadFormat.Xlsx));

            // Now the signature is invalid
            Console.WriteLine("Is VBA Code Project Valid Signed: " + workbook.VbaProject.IsValidSigned);

            Console.WriteLine("CheckVbaSignatureIsValid executed successfully.");
        }
    }
}
