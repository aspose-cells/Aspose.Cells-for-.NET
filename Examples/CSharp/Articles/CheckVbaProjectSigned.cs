using System;
using Aspose.Cells;
namespace Aspose.Cells.Examples.CSharp.Articles
{
    class CheckVbaProjectSigned
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Workbook workbook = new Workbook(dataDir + "Sample1.xlsx");
            Console.WriteLine("VBA Project is Signed: " + workbook.VbaProject.IsSigned);
            // ExEnd:1
        }
    }
}
