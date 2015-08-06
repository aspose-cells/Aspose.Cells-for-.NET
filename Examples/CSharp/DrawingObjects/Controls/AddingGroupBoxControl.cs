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
    public class AddingGroupBoxControl
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiate a new Workbook.
            Workbook excelbook = new Workbook();

            //Add a group box to the first worksheet.
            Aspose.Cells.Drawing.GroupBox box = excelbook.Worksheets[0].Shapes.AddGroupBox(1, 0, 1, 0, 300, 250);

            //Set the caption of the group box.
            box.Text = "Age Groups";
            box.Placement = PlacementType.FreeFloating;

            //Make it 2-D box.
            box.Shadow = false;

            //Add a radio button.
            Aspose.Cells.Drawing.RadioButton radio1 = excelbook.Worksheets[0].Shapes.AddRadioButton(3, 0, 2, 0, 30, 110);

            //Set its text string.
            radio1.Text = "20-29";

            //Set A1 cell as a linked cell for the radio button.
            radio1.LinkedCell = "A1";

            //Make the radio button 3-D.
            radio1.Shadow = true;

            //Set the foreground color of the radio button.
            radio1.FillFormat.ForeColor = Color.LightGreen;

            //Set the line style of the radio button.
            radio1.LineFormat.Style = MsoLineStyle.ThickThin;

            //Set the weight of the radio button.
            radio1.LineFormat.Weight = 4;

            //Set the line color of the radio button.
            radio1.LineFormat.ForeColor = Color.Blue;

            //Set the dash style of the radio button.
            radio1.LineFormat.DashStyle = MsoLineDashStyle.Solid;

            //Make the line format visible.
            radio1.LineFormat.IsVisible = true;

            //Make the fill format visible.
            radio1.FillFormat.IsVisible = true;

            //Add another radio button.
            Aspose.Cells.Drawing.RadioButton radio2 = excelbook.Worksheets[0].Shapes.AddRadioButton(6, 0, 2, 0, 30, 110);

            //Set its text string.
            radio2.Text = "30-39";

            //Set A1 cell as a linked cell for the radio button.
            radio2.LinkedCell = "A1";

            //Make the radio button 3-D.
            radio2.Shadow = true;

            //Set the foreground color of the radio button.
            radio2.FillFormat.ForeColor = Color.LightGreen;

            //Set the line style of the radio button.
            radio2.LineFormat.Style = MsoLineStyle.ThickThin;

            //Set the weight of the radio button.
            radio2.LineFormat.Weight = 4;

            //Set the line color of the radio button.
            radio2.LineFormat.ForeColor = Color.Blue;

            //Set the dash style of the radio button.
            radio2.LineFormat.DashStyle = MsoLineDashStyle.Solid;

            //Make the line format visible.
            radio2.LineFormat.IsVisible = true;

            //Make the fill format visible.
            radio2.FillFormat.IsVisible = true;

            //Add another radio button.
            Aspose.Cells.Drawing.RadioButton radio3 = excelbook.Worksheets[0].Shapes.AddRadioButton(9, 0, 2, 0, 30, 110);

            //Set its text string.
            radio3.Text = "40-49";

            //Set A1 cell as a linked cell for the radio button.
            radio3.LinkedCell = "A1";

            //Make the radio button 3-D.
            radio3.Shadow = true;

            //Set the foreground color of the radio button.
            radio3.FillFormat.ForeColor = Color.LightGreen;

            //Set the line style of the radio button.
            radio3.LineFormat.Style = MsoLineStyle.ThickThin;

            //Set the weight of the radio button.
            radio3.LineFormat.Weight = 4;

            //Set the line color of the radio button.
            radio3.LineFormat.ForeColor = Color.Blue;

            //Set the dash style of the radio button.
            radio3.LineFormat.DashStyle = MsoLineDashStyle.Solid;

            //Make the line format visible.
            radio3.LineFormat.IsVisible = true;

            //Make the fill format visible.
            radio3.FillFormat.IsVisible = true;

            //Get the shapes.
            Aspose.Cells.Drawing.Shape[] shapeobjects = new Aspose.Cells.Drawing.Shape[] { box, radio1, radio2, radio3 };

            //Group the shapes.
            Aspose.Cells.Drawing.GroupShape group = excelbook.Worksheets[0].Shapes.Group(shapeobjects);

            //Save the excel file.
            excelbook.Save(dataDir + "book1.xls");

        }
    }
}