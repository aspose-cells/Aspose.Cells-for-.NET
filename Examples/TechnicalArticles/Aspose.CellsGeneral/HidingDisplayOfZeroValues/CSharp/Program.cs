//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace HidingDisplayOfZeroValuesExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");
            //Create a new Workbook object
            Workbook workbook = new Workbook(dataDir+ "book1.xlsx");

            //Get First worksheet of the workbook
            Worksheet sheet = workbook.Worksheets[0];

            //Hide the zero values in the sheet
            sheet.DisplayZeros = false;

            //Save the workbook
            workbook.Save(dataDir+ "outputfile.xlsx");
            
            
        }
    }
}