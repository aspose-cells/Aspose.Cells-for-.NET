using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingVBAModules
{
    public class CheckVbaCodeIsSigned
    {
        public static void Run()
        {
            // ExStart:CheckVbaCodeIsSigned
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Workbook workbook = new Workbook(dataDir + "sampleVBAProjectSigned.xlsm");

            Console.WriteLine("Is VBA Code Project Signed: " + workbook.VbaProject.IsSigned);
            // ExEnd:CheckVbaCodeIsSigned
        }
    }
}
