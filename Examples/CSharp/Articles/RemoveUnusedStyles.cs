using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    class RemoveUnusedStyles
    {
        static void Main() {
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string inputPath = dataDir + "Sample.xlsx";
            string outputPath = dataDir + "Output.xlsx";

            Workbook workbook = new Workbook(inputPath);

            workbook.RemoveUnusedStyles();

            workbook.Save(outputPath);
            Console.WriteLine("File saved {0}", outputPath);
        }
    }
}
