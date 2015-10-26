//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;
using System.Drawing;

namespace Aspose.Cells.Examples.DrawingObjects.Controls
{
    public class AddingButtonControl
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Create a new Workbook.
            Workbook workbook = new Workbook();

            //Get the first worksheet in the workbook.
            Worksheet sheet = workbook.Worksheets[0];

            //Add a new button to the worksheet.
            Aspose.Cells.Drawing.Button button = sheet.Shapes.AddButton(2, 0, 2, 0, 28, 80);

            //Set the caption of the button.
            button.Text = "Aspose";

            //Set the Placement Type, the way the
            //button is attached to the cells.
            button.Placement = PlacementType.FreeFloating;

            //Set the font name.
            button.Font.Name = "Tahoma";

            //Set the caption string bold.
            button.Font.IsBold = true;

            //Set the color to blue.
            button.Font.Color = Color.Blue;

            //Set the hyperlink for the button.
            button.AddHyperlink("http://www.aspose.com/");

            //Saves the file.
            workbook.Save(dataDir + "book1.xls");

        }
    }
}