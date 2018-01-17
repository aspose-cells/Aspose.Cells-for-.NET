using System;
using Aspose.Cells;
namespace Aspose.Cells.Examples.CSharp.Articles.ManagingVBAModules
{
    class CheckVbaProjectSigned
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            Workbook workbook = new Workbook(sourceDir + "sampleCheckVbaProjectSigned.xlsm");
            Console.WriteLine("VBA Project is Signed: " + workbook.VbaProject.IsSigned);

            Console.WriteLine("CheckVbaProjectSigned executed successfully.");
        }
    }
}
