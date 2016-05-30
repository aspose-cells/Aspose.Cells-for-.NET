using System.IO;

using Aspose.Cells;
using System;
using System.Diagnostics;

namespace CSharp.Data.Handling.AccessingCells
{
    public class AccessingMaximumDisplayRangeofWorksheet
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

           

            // Path to source file
            string filePath = dataDir + "Book1.xlsx";
            // Instantiating a Workbook object
            Workbook workbook = new Workbook(filePath);

            // Instantiate a workbook from source file
            Workbook wb = new Workbook(filePath);

            // Access the first workbook
            Worksheet worksheet = wb.Worksheets[0];

            // Access the Maximum Display Range
            Range range = worksheet.Cells.MaxDisplayRange;

            // Print the Maximum Display Range RefersTo property
            Console.WriteLine("Maximum Display Range: " + range.RefersTo);
            // ExEnd:1
        }
    }
}