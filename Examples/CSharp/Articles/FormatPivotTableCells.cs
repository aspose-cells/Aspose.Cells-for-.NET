using System.IO;
using System;
using Aspose.Cells;
using Aspose.Cells.Pivot;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class FormatPivotTableCells
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create workbook object from source file containing pivot table
            Workbook workbook = new Workbook(sourceDir + "sampleFormatPivotTableCells.xlsx");

            // Access the worksheet by its name
            Worksheet worksheet = workbook.Worksheets[0];

            // Access the pivot table
            PivotTable pivotTable = worksheet.PivotTables[0];

            // Create a style object with background color light blue
            Style style = workbook.CreateStyle();
            style.Pattern = BackgroundType.Solid;
            style.BackgroundColor = Color.LightBlue;

            // Format entire pivot table with light blue color
            pivotTable.FormatAll(style);

            // Create another style object with yellow color
            style = workbook.CreateStyle();
            style.Pattern = BackgroundType.Solid;
            style.BackgroundColor = Color.Yellow;

            // Format the cells of the first row of the pivot table with yellow color
            //Format the pivot table cells from H6 to M6
            string[] cells_names = new string[] { "H6", "I6", "J6", "K6", "L6", "M6" };

            for (int i =0; i < cells_names.Length; i++)
            {
                Cell cell = worksheet.Cells[cells_names[i]];
                pivotTable.Format(cell.Row, cell.Column, style);
            }
            
            // Save the workbook object
            workbook.Save(outputDir + "outputFormatPivotTableCells.xlsx");

            Console.WriteLine("FormatPivotTableCells executed successfully.\r\n");
        }
    }
}
