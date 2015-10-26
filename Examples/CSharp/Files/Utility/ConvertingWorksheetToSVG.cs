//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Rendering;

namespace Aspose.Cells.Examples.Files.Utility
{
    public class ConvertingWorksheetToSVG
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            string filePath = dataDir + "Template.xlsx";

            //Create a workbook object from the template file
            Workbook book = new Workbook(filePath);

            //Convert each worksheet into svg format in a single page.
            ImageOrPrintOptions imgOptions = new ImageOrPrintOptions();
            imgOptions.SaveFormat = SaveFormat.SVG;
            imgOptions.OnePagePerSheet = true;

            //Convert each worksheet into svg format
            foreach (Worksheet sheet in book.Worksheets)
            {
                SheetRender sr = new SheetRender(sheet, imgOptions);

                for (int i = 0; i < sr.PageCount; i++)
                {
                    //Output the worksheet into Svg image format
                    sr.ToImage(i, filePath + sheet.Name + i + ".out.svg");
                }
            }
        }
    }
}