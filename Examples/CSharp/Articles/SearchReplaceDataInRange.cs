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
    public class SearchReplaceDataInRange
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string filePath = dataDir+ "input.xlsx";

            Workbook workbook = new Workbook(filePath);

            Worksheet worksheet = workbook.Worksheets[0];

            //Specify the range where you want to search
            //Here the range is E3:H6
            CellArea area = CellArea.CreateCellArea("E9", "H15");

            //Specify Find options
            FindOptions opts = new FindOptions();
            opts.LookInType = LookInType.Values;
            opts.LookAtType = LookAtType.EntireContent;
            opts.SetRange(area);

            Cell cell = null;

            do
            {
                //Search the cell with value search within range
                cell = worksheet.Cells.Find("search", cell, opts);

                //If no such cell found, then break the loop
                if (cell == null)
                    break;

                //Replace the cell with value replace
                cell.PutValue("replace");

            } while (true);

            //Save the workbook
            workbook.Save(dataDir+ "output.xlsx");

            
        }
    }
}