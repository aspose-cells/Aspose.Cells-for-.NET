using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.LineBreakTextWrapping
{
    public class UseExplicitLineBreaks
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create Workbook Object
            Workbook wb = new Workbook();

            // Open first Worksheet in the workbook
            Worksheet ws = wb.Worksheets[0];

            Cell c5 = ws.Cells["C5"];

            // Get Worksheet Cells Collection
            Aspose.Cells.Cells cell = ws.Cells;

            // Increase the width of the column C
            cell.SetColumnWidth(c5.Column, 30);

            // Add Text to the Firts Cell with Explicit Line Breaks
            c5.PutValue("I am using\nthe latest version of \nAspose.Cells to \ntest this functionality");

            // Make Cell's Text wrap
            Style style = c5.GetStyle();
            style.IsTextWrapped = true;
            c5.SetStyle(style);

            // Save Excel File
            wb.Save(outputDir + "outputUseExplicitLineBreaks.xlsx");

            Console.WriteLine("UseExplicitLineBreaks executed successfully.");
        }
    }
}
