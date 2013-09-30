//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace UnMergingtheMergedCells
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Create a Workbook.
            //Open the excel file.
            Workbook wbk = new Aspose.Cells.Workbook(dataDir + "mergingcells.xls");

            //Create a Worksheet and get the first sheet.
            Worksheet worksheet = wbk.Worksheets[0];

            //Create a Cells object ot fetch all the cells.
            Cells cells = worksheet.Cells;

            //Unmerge the cells.
            cells.UnMerge(5, 2, 2, 3);

            //Save the file.
            wbk.Save(dataDir + "unmergingcells.xls");


        }
    }
}