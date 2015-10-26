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
    public class CopyingColumns
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                       

            //Create another Workbook.
            Workbook excelWorkbook1 = new Workbook(dataDir + "book1.xls");

            //Get the first worksheet in the book.
            Worksheet ws1 = excelWorkbook1.Worksheets[0];

            //Copy the first column from the first worksheet of the first workbook into
            //the first worksheet of the second workbook.
            ws1.Cells.CopyColumn(ws1.Cells, ws1.Cells.Columns[0].Index, ws1.Cells.Columns[2].Index);

            //Autofit the column.
            ws1.AutoFitColumn(2);

            //Save the excel file.
            excelWorkbook1.Save(dataDir + "output.xls");

        }
    }
}