//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace FindCellsWithSpecificStyleExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            string filePath = dataDir+ "TestBook.xlsx";

            Workbook workbook = new Workbook(filePath);

            Worksheet worksheet = workbook.Worksheets[0];

            //Access the style of cell A1
            Style style = worksheet.Cells["A1"].GetStyle();

            //Specify the style for searching
            FindOptions options = new FindOptions();
            options.Style = style;

            Cell nextCell = null;

            do
            {
                //Find the cell that has a style of cell A1
                nextCell = worksheet.Cells.Find(null, nextCell, options);

                if (nextCell == null)
                    break;

                //Change the text of the cell
                nextCell.PutValue("Found");

            } while (true);

            workbook.Save(dataDir+ "output.xlsx");

            
        }
    }
}