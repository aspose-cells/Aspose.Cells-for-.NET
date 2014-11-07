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

namespace ExtractImagesFromWorksheetsExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Open a template Excel file
            Workbook workbook = new Workbook(dataDir+ "book1.xls");
            //Get the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];
            //Get the first Picture in the first worksheet
            Aspose.Cells.Drawing.Picture pic = worksheet.Pictures[0];
            //Set the output image file path
            string fileName = dataDir+ "aspose-logo.Jpg";
            string picformat = pic.ImageFormat.ToString();
            //Note: you may evaluate the image format before specifying the image path

            //Define ImageOrPrintOptions
            ImageOrPrintOptions printoption = new ImageOrPrintOptions();
            //Specify the image format
            printoption.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
            //Save the image
            pic.ToImage(fileName, printoption);
 
            
        }
    }
}