using System.IO;
using System;
using Aspose.Cells;
using System.Collections;

namespace CSharp.Articles
{
    public class DetectMergedCells
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiate a new Workbook
            // Open an existing excel file
            Workbook wkBook = new Workbook(dataDir+ "SampleInput.xlsx");
            // Get a worksheet in the workbook
            Worksheet wkSheet = wkBook.Worksheets["Sheet2"];
            // Clear its contents
            wkSheet.Cells.Clear();

            // Create an arraylist object
            ArrayList al = new ArrayList();
            // Get the merged cells list to put it into the arraylist object
            al = wkSheet.Cells.MergedCells;
            // Define cellarea
            CellArea ca;
            // Define some variables
            int frow, fcol, erow, ecol, trows, tcols;
            // Loop through the arraylist and get each cellarea
            // To unmerge it
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
            dataDir = dataDir+ "MergeTrial.out.xlsx";
            // Save the excel file
            wkBook.Save(dataDir);
            // ExEnd:1
            Console.WriteLine("\nProcess completed successfully.\nFile saved at " + dataDir); 
            
        }
    }
}
