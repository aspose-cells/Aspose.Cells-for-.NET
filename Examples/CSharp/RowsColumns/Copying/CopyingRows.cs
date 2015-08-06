//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.RowsColumns.Copying
{
    public class CopyingRows
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Create a new Workbook.
            //Open the existing excel file.
            Workbook excelWorkbook1 = new Workbook(dataDir + "book1.xls");

            //Get the first worksheet in the workbook.
            Worksheet wsTemplate = excelWorkbook1.Worksheets[0];

            //Copy the second row with data, formattings, images and drawing objects
            //to the 16th row in the worksheet.
            wsTemplate.Cells.CopyRow(wsTemplate.Cells, 1, 15);

            //Save the excel file.
            excelWorkbook1.Save(dataDir + "output.xls");

        }
    }
}