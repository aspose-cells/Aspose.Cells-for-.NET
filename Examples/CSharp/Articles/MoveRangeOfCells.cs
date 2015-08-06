//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class MoveRangeOfCells
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Instantiate the workbook object
            //Open the Excel file
            Workbook workbook = new Workbook(dataDir+ "book1.xls");

            Cells cells = workbook.Worksheets[0].Cells;

            //Create Cell's area
            CellArea ca = new CellArea();
            ca.StartColumn = 0;
            ca.EndColumn = 1;
            ca.StartRow = 0;
            ca.EndRow = 4;

            //Move Range
            cells.MoveRange(ca, 0, 2);

            //Save the resultant file
            workbook.Save(dataDir+ "book2.xls");
            
            
        }
    }
}