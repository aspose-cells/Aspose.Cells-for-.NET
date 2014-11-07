//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace DisableCompatibilityCheckerExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");
            //Open a template file
            Workbook workbook = new Workbook(dataDir+ "sample.xlsx");

            //Disable the compatibility checker
            workbook.Settings.CheckComptiliblity = false;

            //Saving the Excel file
            workbook.Save(dataDir+ "Output_BK_CompCheck.xlsx");
            
            
        }
    }
}