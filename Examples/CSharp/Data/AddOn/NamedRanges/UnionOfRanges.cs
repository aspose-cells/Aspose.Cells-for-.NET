using System;
using System.IO;

using Aspose.Cells;
using System.Drawing;
using System.Collections;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class UnionOfRanges
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // Instantiate a workbook object.
            // Open an existing excel file.
            Workbook workbook = new Workbook(sourceDir + "sampleUnionOfRanges.xlsx");

            // Get the named ranges.
            Range[] ranges = workbook.Worksheets.GetNamedRanges();
            
            // Create a style object.
            Style style = workbook.CreateStyle();
            
            // Set the shading color with solid pattern type.
            style.ForegroundColor = Color.Red;
            style.Pattern = BackgroundType.Solid;
            
            // Create a styleflag object.
            StyleFlag flag = new StyleFlag();
            
            // Apply the cellshading.
            flag.CellShading = true;
            
            // Creates an arraylist.
            ArrayList al = new ArrayList();
            
            // Get the arraylist collection apply the union operation.
            al = ranges[0].Union(ranges[1]);
            
            // Define a range object.
            Range rng;
            int frow, fcol, erow, ecol;

            for (int i = 0; i < al.Count; i++)
            {
                // Get a range.
                rng = (Range)al[i];
                frow = rng.FirstRow;
                fcol = rng.FirstColumn;
                erow = rng.RowCount;
                ecol = rng.ColumnCount;
            
                // Apply the style to the range.
                rng.ApplyStyle(style, flag);

            }

            // Save the excel file.
            workbook.Save(outputDir + "outputUnionOfRanges.xlsx");

            Console.WriteLine("UnionOfRanges executed successfully.");
        }
    }
}
