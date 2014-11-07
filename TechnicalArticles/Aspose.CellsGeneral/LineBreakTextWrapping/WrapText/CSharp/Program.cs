//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace WrapTextExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");
            //Create Workbook Object
            Workbook wb = new Workbook();

            //Open first Worksheet in the workbook
            Worksheet ws = wb.Worksheets[0];

            //Get Worksheet Cells Collection
            Aspose.Cells.Cells cell = ws.Cells;

            //Increase the width of First Column Width
            cell.SetColumnWidth(0, 35);

            //Increase the height of first row
            cell.SetRowHeight(0, 36);

            //Add Text to the Firts Cell
            cell[0, 0].PutValue("I am using the latest version of Aspose.Cells to test this functionality");

            //Make Cell's Text wrap
            Style style = cell[0, 0].GetStyle();
            style.IsTextWrapped = true;
            cell[0, 0].SetStyle(style);

            // Save Excel File
            wb.Save(dataDir+ "WrappingText.xlsx");
            
            
        }
    }
}