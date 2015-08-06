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
    public class InsertLinkedPicture
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Instantiate a new Workbook.
            Workbook workbook = new Workbook();
            //Insert a linked picture (from Web Address) to B2 Cell.
            Aspose.Cells.Drawing.Picture pic = workbook.Worksheets[0].Shapes.AddLinkedPicture(1, 1, 100, 100, "http://www.aspose.com/Images/aspose-logo.jpg");
            //Set the height and width of the inserted image.
            pic.HeightInch = 1.04;
            pic.WidthInch = 2.6;
            //Save the Excel file.
            workbook.Save(dataDir+ "outLinkedPicture.xlsx");
            
            
        }
    }
}