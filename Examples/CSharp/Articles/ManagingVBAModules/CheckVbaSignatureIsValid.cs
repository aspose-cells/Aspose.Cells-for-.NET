using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingVBAModules
{
    public class CheckVbaSignatureIsValid
    {
        public static void Run()
        {
            // ExStart:CheckVbaSignatureIsValid
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Workbook workbook = new Workbook(dataDir + "sampleVBAProjectSigned.xlsm");

            // Signature is valid
            Console.WriteLine("Is VBA Code Project Valid Signed: " + workbook.VbaProject.IsValidSigned);

            // Modify the VBA Code, save the workbook then reload
            // VBA Code Signature will now be invalid
            string code = workbook.VbaProject.Modules[1].Codes;
            code = code.Replace("Welcome to Aspose", "Welcome to Aspose.Cells");
            workbook.VbaProject.Modules[1].Codes = code;

            // Save
            workbook.Save(dataDir + "output_out_.xlsm");

            // Reload
            workbook = new Workbook(dataDir + "output_out_.xlsm");

            // Now the signature is invalid
            Console.WriteLine("Is VBA Code Project Valid Signed: " + workbook.VbaProject.IsValidSigned);
            // ExEnd:CheckVbaSignatureIsValid
        }
    }
}
