//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace SetWorksheetTabColorExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Instantiate a new Workbook
            //Open an Excel file
            Workbook workbook = new Workbook(dataDir+ "Book1.xlsx");

            //Get the first worksheet in the book
            Worksheet worksheet = workbook.Worksheets[0];

            //Set the tab color
            worksheet.TabColor = Color.Red;

            //Save the Excel file
            workbook.Save(dataDir+ "worksheettabcolor.xls");
            
        }
    }
}