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
using System.Drawing;

namespace AddingLabelControl
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

            //Create a new Workbook.
            Workbook workbook = new Workbook();

            //Get the first worksheet in the workbook.
            Worksheet sheet = workbook.Worksheets[0];

            //Add a new label to the worksheet.
            Aspose.Cells.Drawing.Label label = sheet.Shapes.AddLabel(2, 0, 2, 0, 60, 120);

            //Set the caption of the label.
            label.Text = "This is a Label";

            //Set the Placement Type, the way the
            //label is attached to the cells.
            label.Placement = PlacementType.FreeFloating;

            //Set the fill color of the label.
            label.FillFormat.ForeColor = Color.Yellow;

            //Saves the file.
            workbook.Save(dataDir + "book1.xls");

        }
    }
}