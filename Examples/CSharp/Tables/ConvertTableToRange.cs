//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Tables
{
    public class ConvertTableToRange
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Open an existing file that contains a table/list object in it
            Workbook wb = new Workbook(dataDir + "book1.xlsx");

            //Convert the first table/list object (from the first worksheet) to normal range
            wb.Worksheets[0].ListObjects[0].ConvertToRange();

            //Save the file
            wb.Save(dataDir + "output.xlsx");

        }
    }
}