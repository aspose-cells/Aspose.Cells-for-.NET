using System.IO;

using Aspose.Cells;
using System;

namespace CSharp.Data.Handling.AccessingCells
{
    public class UsingCellIndexInCellsCollection
    {
        public static void Run()
        {
        // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Open an existing worksheet
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            // Using the Sheet 1 in Workbook
            Worksheet worksheet = workbook.Worksheets[0];

            // Accessing a cell using its name
            Cell cell = worksheet.Cells[0];

            string value = cell.Value.ToString();

            Console.WriteLine(value);
            // ExEnd:1
        }
    }
}
