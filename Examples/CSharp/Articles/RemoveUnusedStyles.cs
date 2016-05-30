using System;
using Aspose.Cells;

namespace CSharp.Articles
{
    class RemoveUnusedStyles
    {
       public static void Run() {
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string inputPath = dataDir + "Sample.xlsx";
            string outputPath = dataDir + "Output.out.xlsx";

            Workbook workbook = new Workbook(inputPath);

            workbook.RemoveUnusedStyles();

            workbook.Save(outputPath);
            Console.WriteLine("File saved {0}", outputPath);
        }
    }
}
