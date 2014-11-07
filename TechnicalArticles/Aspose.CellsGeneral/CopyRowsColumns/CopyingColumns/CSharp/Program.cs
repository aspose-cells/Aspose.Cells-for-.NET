//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace CopyingColumns
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Instantiate a new Workbook
            //Open an existing excel file
            Workbook workbook = new Workbook(dataDir+ "aspose-sample.xlsx");

            //Get the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];
            //Get the Cells collection
            Cells cells = worksheet.Cells;
            //Copy the first column to the third column
            cells.CopyColumn(cells, 0, 2);
            //Save the excel file
            workbook.Save(dataDir+ "outaspose-sample.xlsx");
            
            
        }
    }
}