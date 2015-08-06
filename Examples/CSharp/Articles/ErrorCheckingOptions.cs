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
    public class ErrorCheckingOptions
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Create a workbook and opening a template spreadsheet
            Workbook workbook = new Workbook(dataDir+ "Book1.xlsx");

            //Get the first worksheet
            Worksheet sheet = workbook.Worksheets[0];
            //Instantiate the error checking options
            ErrorCheckOptionCollection opts = sheet.ErrorCheckOptions;

            int index = opts.Add();
            ErrorCheckOption opt = opts[index];
            //Disable the numbers stored as text option
            opt.SetErrorCheck(ErrorCheckType.TextNumber, false);
            //Set the range
            opt.AddRange(CellArea.CreateCellArea(0, 0, 1000, 50));

            //Save the Excel file
            workbook.Save(dataDir+ "out_test.xlsx");
            
        }
    }
}