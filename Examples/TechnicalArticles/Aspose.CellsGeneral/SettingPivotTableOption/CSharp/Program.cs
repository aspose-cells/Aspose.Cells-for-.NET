//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Pivot;

namespace SettingPivotTableOptionExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            Workbook wb = new Workbook(dataDir + "input.xlsx");

            PivotTable pt = wb.Worksheets[0].PivotTables[0];

            //Indicating if or not display the empty cell value
            pt.DisplayNullString = true;

            //Indicating the null string
            pt.NullString = "null";

            pt.CalculateData();

            pt.RefreshDataOnOpeningFile = false;

            wb.Save(dataDir+ "output.xlsx");
            
        }
    }
}