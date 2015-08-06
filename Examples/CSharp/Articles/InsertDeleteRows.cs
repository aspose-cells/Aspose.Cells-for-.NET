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
    public class InsertDeleteRows
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Instantiate a Workbook object.
            //Load a template file.
            Workbook workbook = new Workbook(dataDir+ "book1.xlsx");

            //Get the first worksheet in the book.
            Worksheet sheet = workbook.Worksheets[0];

            //Insert 10 rows at row index 2 (insertion starts at 3rd row)
            sheet.Cells.InsertRows(2, 10);

            //Delete 5 rows now. (8th row - 12th row)
            sheet.Cells.DeleteRows(7, 5);

            //Save the excel file.
            workbook.Save(dataDir+ "out_book1.xlsx");
 
            
            
        }
    }
}