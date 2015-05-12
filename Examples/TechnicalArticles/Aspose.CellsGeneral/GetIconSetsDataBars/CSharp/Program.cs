//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace GetIconSetsDataBarsExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");
            //Open a template Excel file
            Workbook workbook = new Workbook(dataDir+ "book1.xlsx");

            //Get the first worksheet in the workbook
            Worksheet sheet = workbook.Worksheets[0];

            //Get the A1 cell
            Cell cell = sheet.Cells["A1"];

            //Get the conditional formatting result object
            ConditionalFormattingResult cfr = cell.GetConditionalFormattingResult();

            //Get the icon set
            ConditionalFormattingIcon icon = cfr.ConditionalFormattingIcon;

            //Create the image file based on the icon's image data
            File.WriteAllBytes(dataDir+ "imgIcon.jpg", icon.ImageData);
            
        }
    }
}