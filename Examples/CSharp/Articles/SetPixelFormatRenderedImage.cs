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
using System.Drawing.Imaging;

namespace Aspose.Cells.Examples.Articles
{
    public class SetPixelFormatRenderedImage
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiate a new Workbook
            //Load an Excel file
            Workbook wb = new Workbook(dataDir+ "Book1.xlsx");
            //Instantiate SheetRender object based on the first worksheet
            //Set the ImageOrPrintOptions with desired pixel format (24 bits per pixel) and image format type
            SheetRender sr = new SheetRender(wb.Worksheets[0], new ImageOrPrintOptions { PixelFormat = PixelFormat.Format24bppRgb, ImageFormat = ImageFormat.Tiff });
            //Save the image (first page of the sheet) with the specified options
            sr.ToImage(0, dataDir+ "outImage1.tiff");
 
        }
    }
}