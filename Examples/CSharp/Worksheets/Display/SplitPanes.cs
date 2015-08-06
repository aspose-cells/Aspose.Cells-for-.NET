//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Worksheets.Display
{
    public class SplitPanes
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiate a new workbook and Open a template file
            Workbook book = new Workbook(dataDir + "Book1.xls");

            //Set the active cell
            book.Worksheets[0].ActiveCell = "A20";

            //Split the worksheet window
            book.Worksheets[0].Split();

            //Save the excel file
            book.Save(dataDir + "Splitted_out1.xls");
        }
    }
}