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
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            Workbook workbook = new Workbook(sourceDir + "sampleCheckVbaCodeIsSigned.xlsm");

            Console.WriteLine("Is VBA Code Project Signed: " + workbook.VbaProject.IsSigned);

            Console.WriteLine("CheckVbaCodeIsSigned executed successfully.");
        }
    }
}
