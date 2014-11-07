//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Rendering;
using System.Drawing.Imaging;

namespace ExportRangeofCellsExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");
            string filePath = dataDir+ "aspose-sample.xlsx";

            //Create workbook from source file.
            Workbook workbook = new Workbook(filePath);

            //Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Set the print area with your desired range
            worksheet.PageSetup.PrintArea = "E12:H16";

            //Set all margins as 0
            worksheet.PageSetup.LeftMargin = 0;
            worksheet.PageSetup.RightMargin = 0;
            worksheet.PageSetup.TopMargin = 0;
            worksheet.PageSetup.BottomMargin = 0;

            //Set OnePagePerSheet option as true
            ImageOrPrintOptions options = new ImageOrPrintOptions();
            options.OnePagePerSheet = true;
            options.ImageFormat = ImageFormat.Jpeg;

            //Take the image of your worksheet
            SheetRender sr = new SheetRender(worksheet, options);
            sr.ToImage(0, dataDir+ "output.jpg");
            
            
        }
    }
}