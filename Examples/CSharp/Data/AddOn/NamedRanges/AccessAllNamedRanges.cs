using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Data.AddOn.NamedRanges
{
    public class AccessAllNamedRanges
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Opening the Excel file through the file stream
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            // Getting all named ranges
            Range[] range = workbook.Worksheets.GetNamedRanges();

            if(range != null)
            Console.WriteLine("Total Number of Named Ranges: " + range.Length);
            // ExEnd:1

        }
    }
}
