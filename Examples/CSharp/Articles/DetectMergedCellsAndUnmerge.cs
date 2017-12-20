using System.IO;
using System;
using Aspose.Cells;
using System.Collections;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class DetectMergedCellsAndUnmerge
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiate a new Workbook - Open an existing excel file
            Workbook wkBook = new Workbook(sourceDir + "sampleDetectMergedCellsAndUnmerge.xlsx");

            // Get a worksheet in the workbook
            Worksheet wkSheet = wkBook.Worksheets["Sheet1"];

            // Create an arraylist object
            ArrayList al = new ArrayList();

            // Get the merged cells list to put it into the arraylist object
            al = wkSheet.Cells.MergedCells;
            
            // Define cellarea
            CellArea ca;
            
            // Define some variables
            int frow, fcol, erow, ecol, trows, tcols;
            
            // Loop through the arraylist and get each cellarea to unmerge it
            for (int i = 0; i < al.Count; i++)
            {
                ca = new CellArea();
                ca = (CellArea)al[i];
                frow = ca.StartRow;
                fcol = ca.StartColumn;
                erow = ca.EndRow;
                ecol = ca.EndColumn;

                trows = erow - frow + 1;
                tcols = ecol - fcol + 1;
                wkSheet.Cells.UnMerge(frow, fcol, trows, tcols);
            }

            // Save the excel file
            wkBook.Save(outputDir + "outputDetectMergedCellsAndUnmerge.xlsx");

            Console.WriteLine("DetectMergedCellsAndUnmerge executed successfully.\r\n");
        }
    }
}
