//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace SettingFormulaCalculationModeWorkbookExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");
            //Create a workbook
            Workbook workbook = new Workbook();

            //Set the Formula Calculation Mode to Manual
            workbook.Settings.CalcMode = CalcModeType.Manual;

            //Save the workbook
            workbook.Save(dataDir+ "output.xlsx", SaveFormat.Xlsx);
            
        }
    }
}