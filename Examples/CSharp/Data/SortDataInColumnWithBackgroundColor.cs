using System;
using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class SortDataInColumnWithBackgroundColor
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();
        public static void Main()
        {
            // ExStart:1
            // Create a workbook object and load template file
            Workbook workbook = new Workbook(sourceDir + "sampleBackGroundFile.xlsx");

            // Instantiate data sorter object
            DataSorter sorter = workbook.DataSorter;

            // Add key for second column for red color
            sorter.AddKey(1, SortOnType.CellColor, SortOrder.Descending, Color.Red);

            // Sort the data based on the key
            sorter.Sort(workbook.Worksheets[0].Cells, CellArea.CreateCellArea("A2", "C6"));

            // Save the output file
            workbook.Save(outputDir + "outputsampleBackGroundFile.xlsx");
            // ExEnd:1

            //Display the message
            Console.WriteLine("SortDataInColumnWithBackgroundColor executed successfully.\r\n");
        }
    }
}