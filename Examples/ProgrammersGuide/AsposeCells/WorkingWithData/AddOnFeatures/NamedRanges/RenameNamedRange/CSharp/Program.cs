//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace RenameNamedRange
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Open an existing Excel file that has a (global) named range "TestRange" in it
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            //Get the first worksheet
            Worksheet sheet = workbook.Worksheets[0];

            //Get the Cells of the sheet
            Cells cells = sheet.Cells;

            //Get the named range "MyRange"
            Name name = workbook.Worksheets.Names["TestRange"];

            //Rename it
            name.Text = "NewRange";

            //Save the Excel file
            workbook.Save(dataDir + "RenamingRange.xlsx"); 
        }
    }
}