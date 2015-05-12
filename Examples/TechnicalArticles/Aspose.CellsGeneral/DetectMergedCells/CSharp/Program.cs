//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using System.Collections;

namespace DetectMergedCells
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Instantiate a new Workbook
            //Open an existing excel file
            Workbook wkBook = new Workbook(dataDir+ "SampleInput.xlsx");
            //Get a worksheet in the workbook
            Worksheet wkSheet = wkBook.Worksheets["Sheet2"];
            //Clear its contents
            wkSheet.Cells.Clear();

            //Create an arraylist object
            ArrayList al = new ArrayList();
            //Get the merged cells list to put it into the arraylist object
            al = wkSheet.Cells.MergedCells;
            //Define cellarea
            CellArea ca;
            //Define some variables
            int frow, fcol, erow, ecol, trows, tcols;
            //Loop through the arraylist and get each cellarea
            //to unmerge it
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

            //Save the excel file
            wkBook.Save(dataDir+ "MergeTrial.xlsx");
 
            
        }
    }
}