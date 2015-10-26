//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;
using System.Drawing;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles.CopyShapesBetweenWorksheets
{
    public class CopyingPicture
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Create a workbook object
            //Open the template file
            Workbook workbook = new Workbook(dataDir+ "aspose-sample.xlsx");

            //Get the Picture from the "Picture" worksheet.
            Aspose.Cells.Drawing.Picture source = workbook.Worksheets["Sheet1"].Pictures[0];

            //Save Picture to Memory Stream
            MemoryStream ms = new MemoryStream(source.Data);

            //Copy the picture to the Result Worksheet
            workbook.Worksheets["Sheet2"].Pictures.Add(source.UpperLeftRow, source.UpperLeftColumn, ms, source.WidthScale, source.HeightScale);

            //Save the Worksheet
            workbook.Save(dataDir+ "Shapes.xlsx");
            
            
        }
    }
}