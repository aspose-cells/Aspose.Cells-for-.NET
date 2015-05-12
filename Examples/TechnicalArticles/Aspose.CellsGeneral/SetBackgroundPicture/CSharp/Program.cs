//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using System;

namespace SetBackgroundPictureExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            //Get the first worksheet.
            Worksheet sheet = workbook.Worksheets[0];

            //Define a string variable to store the image path.
            string ImageUrl = dataDir+ "aspose-logo.jpg";

            //Get the picture into the streams.
            FileStream fs = File.OpenRead(ImageUrl);

            //Define a byte array.
            byte[] imageData = new Byte[fs.Length];

            //Obtain the picture into the array of bytes from streams.
            fs.Read(imageData, 0, imageData.Length);

            //Close the stream.
            fs.Close();

            //Set the background image for the sheet.
            sheet.SetBackground(imageData);

            //Save the Excel file
            workbook.Save(dataDir+ "BackImageSheet.xlsx");

            //Save the HTML file
            workbook.Save(dataDir+ "BackImageSheet1.html", SaveFormat.Html);
 
        }
    }
}