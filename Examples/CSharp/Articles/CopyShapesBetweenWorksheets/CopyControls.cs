//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles.CopyShapesBetweenWorksheets
{
    public class CopyControls
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Create a workbook object
            //Open the template file
            Workbook workbook = new Workbook(dataDir+ "aspose-sample.xlsx");

            //Get the Shapes from the "Control" worksheet.
            Aspose.Cells.Drawing.ShapeCollection shape = workbook.Worksheets["Sheet3"].Shapes;

            //Copy the Textbox to the Result Worksheet
            workbook.Worksheets["Sheet1"].Shapes.AddCopy(shape[0], 5, 0, 2, 0);

            //Copy the Oval Shape to the Result Worksheet
            workbook.Worksheets["Sheet1"].Shapes.AddCopy(shape[1], 10, 0, 2, 0);

            //Save the Worksheet
            workbook.Save(dataDir+ "Controls.xlsx");
            
        }
    }
}