//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace ProportionalPositioning
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

            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Adding a new worksheet to the Workbook object
            int sheetIndex = workbook.Worksheets.Add();

            //Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[sheetIndex];

            //Adding a picture at the location of a cell whose row and column indices
            //are 5 in the worksheet. It is "F6" cell
            int pictureIndex = worksheet.Pictures.Add(5, 5, dataDir + "logo.jpg");

            //Accessing the newly added picture
            Aspose.Cells.Drawing.Picture picture = worksheet.Pictures[pictureIndex];

            //Positioning the picture proportional to row height and colum width
            picture.UpperDeltaX = 200;
            picture.UpperDeltaY = 200;

            //Saving the Excel file
            workbook.Save(dataDir + "book1.xls");

        }
    }
}