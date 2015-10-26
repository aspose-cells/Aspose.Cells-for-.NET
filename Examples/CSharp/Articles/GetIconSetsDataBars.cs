//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class GetIconSetsDataBars
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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