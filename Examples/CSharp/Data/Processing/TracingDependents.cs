using System.IO;

using Aspose.Cells;
using System;

namespace CSharp.Data.Processing
{
    public class TracingDependents
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            
            Workbook workbook = new Workbook(dataDir + "Book1.xlsx");
            Cells cells = workbook.Worksheets[0].Cells;
            Cell cell = cells["B2"];

           Cell[] ret = cell.GetDependents(true);

            foreach (Cell c in cell.GetDependents(true))
            {
                Console.WriteLine(c.Name);
            }
            // ExEnd:1
            Console.ReadKey();
        }
    }
}
