//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace CopyingRows
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Instantiate a new workbook
            //Open an existing excel file
            Workbook workbook = new Workbook(dataDir+ "aspose-sample.xlsx");

            //Get the first worksheet cells
            Cells cells = workbook.Worksheets[0].Cells;
            //Apply formulas to the cells
            for (int i = 0; i < 5; i++)
            {
                cells[0, i].Formula = "=Input!" + cells[0, i].Name;
            }
            //Copy the first row to next 10 rows
            cells.CopyRows(cells, 0, 1, 10);
            //Save the excel file
            workbook.Save(dataDir + "outaspose-sample.xlsx");
 
        }
    }
}