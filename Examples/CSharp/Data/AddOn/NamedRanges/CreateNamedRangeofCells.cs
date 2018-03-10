using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class CreateNamedRangeofCells
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // Opening the Excel file through the file stream
            Workbook workbook = new Workbook();

            // Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            // Creating a named range
            Range range = worksheet.Cells.CreateRange("B4", "G14");

            // Setting the name of the named range
            range.Name = "TestRange";

            Style st = workbook.CreateStyle();
            st.Pattern = BackgroundType.Solid;
            st.ForegroundColor = System.Drawing.Color.Yellow;
            range.SetStyle(st);

            // Saving the modified Excel file
            workbook.Save(outputDir + "outputCreateNamedRangeofCells.xlsx");

            Console.WriteLine("CreateNamedRangeofCells executed successfully.");
        }
    }
}
