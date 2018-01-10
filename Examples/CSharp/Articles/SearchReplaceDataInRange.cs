using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class SearchReplaceDataInRange
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            Workbook workbook = new Workbook(sourceDir + "sampleSearchReplaceDataInRange.xlsx");

            Worksheet worksheet = workbook.Worksheets[0];

            // Specify the range where you want to search
            // Here the range is E3:H6
            CellArea area = CellArea.CreateCellArea("E9", "H15");

            // Specify Find options
            FindOptions opts = new FindOptions();
            opts.LookInType = LookInType.Values;
            opts.LookAtType = LookAtType.EntireContent;
            opts.SetRange(area);

            Cell cell = null;

            do
            {
                // Search the cell with value search within range
                cell = worksheet.Cells.Find("search", cell, opts);

                // If no such cell found, then break the loop
                if (cell == null)
                    break;

                // Replace the cell with value replace
                cell.PutValue("replace");

            } while (true);

            // Save the workbook
            workbook.Save(outputDir + "outputSearchReplaceDataInRange.xlsx");

            Console.WriteLine("SearchReplaceDataInRange executed successfully.");
        }
    }
}