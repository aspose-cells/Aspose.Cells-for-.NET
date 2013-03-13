//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;
using System.Drawing;

using Aspose.Cells;
using Aspose.Cells.Rendering;

namespace WorksheetToImage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Create a new Workbook object and
            //open a template Excel file.
            Workbook book = new Workbook(dataDir + "MyTestBook1.xls");
            //Get the first worksheet.
            Worksheet sheet = book.Worksheets[0];

            //Define ImageOrPrintOptions
            ImageOrPrintOptions imgOptions = new ImageOrPrintOptions();
            //Specify the image format
            imgOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
            //Only one page for the whole sheet would be rendered
            imgOptions.OnePagePerSheet = true;

            //Render the sheet with respect to specified image/print options
            SheetRender sr = new SheetRender(sheet, imgOptions);
            //Render the image for the sheet
            Bitmap bitmap = sr.ToImage(0);

            //Save the image file specifying its image format.
            bitmap.Save(dataDir + "SheetImage.jpg");

            // Display result, so that user knows the processing has finished.
            System.Console.WriteLine("Conversion to Image(s) completed.");
        }
    }
}