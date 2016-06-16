using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class OpeningFilesThroughPath
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            
            // Opening through Path
            // Creating a Workbook object and opening an Excel file using its file path
            Workbook workbook1 = new Workbook(dataDir + "Book1.xlsx");
            Console.WriteLine("Workbook opened using path successfully!");
            // ExEnd:1
            
        }
    }
}
            
