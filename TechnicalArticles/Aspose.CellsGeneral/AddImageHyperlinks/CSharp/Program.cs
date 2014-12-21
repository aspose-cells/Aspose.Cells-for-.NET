//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;

namespace AddImageHyperlinks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiate a new workbook
            Workbook workbook = new Workbook();

            //Get the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Insert a string value to a cell
            worksheet.Cells["C2"].PutValue("Image Hyperlink");

            //Set the 4th row height
            worksheet.Cells.SetRowHeight(3, 100);

            //Set the C column width
            worksheet.Cells.SetColumnWidth(2, 21);

            //Add a picture to the C4 cell
            int index = worksheet.Pictures.Add(3, 2, 4, 3, dataDir+ "aspose-logo.jpg");

            //Get the picture object
            Aspose.Cells.Drawing.Picture pic = worksheet.Pictures[index];

            //Set the placement type
            pic.Placement = PlacementType.FreeFloating;

            //Add an image hyperlink
            Aspose.Cells.Hyperlink hlink = pic.AddHyperlink("http://www.aspose.com/");

            //Specify the screen tip
            hlink.ScreenTip = "Click to go to Aspose site";

            //Save the Excel file
            workbook.Save(dataDir+ "ImageHyperlink.xls");
            
            
        }
    }
}