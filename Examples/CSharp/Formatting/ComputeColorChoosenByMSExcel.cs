using System.IO;

using Aspose.Cells;
using System.Drawing;
using System;

namespace CSharp.Formatting
{
    public class ComputeColorChoosenByMSExcel
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    
            // Instantiate a workbook object
            // Open the template file
            Workbook workbook = new Workbook(dataDir + "Book1.xlsx");
            // Get the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];
            // Get the A1 cell
            Cell a1 = worksheet.Cells["A1"];

            // Get the conditional formatting resultant object
            ConditionalFormattingResult cfr1 = a1.GetConditionalFormattingResult();
            // Get the ColorScale resultant color object
            Color c = cfr1.ColorScaleResult;


            // Read the color
            Console.WriteLine(c.ToArgb().ToString());
            Console.WriteLine(c.Name);
            // ExEnd:1
        }
    }
}
