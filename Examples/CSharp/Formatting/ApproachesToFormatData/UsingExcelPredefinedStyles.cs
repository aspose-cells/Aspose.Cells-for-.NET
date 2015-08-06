//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Formatting.ApproachesToFormatData
{
    public class UsingExcelPredefinedStyles
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            //Create a style object based on a predefined Excel 2007 style.
            Style style = workbook.Styles.CreateBuiltinStyle(BuiltinStyleType.Accent1);

            //Input a value to A1 cell.
            workbook.Worksheets[0].Cells["A1"].PutValue("Test");

            //Apply the style to the cell.
            workbook.Worksheets[0].Cells["A1"].SetStyle(style);

            //Save the Excel 2007 file.
            workbook.Save(dataDir + "book1.xlsx");
 
        }
    }
}