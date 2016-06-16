using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Data.AddOn.NamedRanges
{
    public class AccessSpecificNamedRange
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiating a Workbook object
            // Opening the Excel file through the file stream
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            // Getting the specified named range
            Range range = workbook.Worksheets.GetRangeByName("TestRange");

            if (range != null)
                Console.WriteLine("Named Range : " + range.RefersTo);
                // ExEnd:1
            
        }
    }
}
