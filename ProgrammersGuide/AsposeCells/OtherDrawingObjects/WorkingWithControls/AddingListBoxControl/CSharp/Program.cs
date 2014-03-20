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

namespace AddingListBoxControl
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

            //Get the first worksheet.
            Worksheet sheet = workbook.Worksheets[0];

            //Get the worksheet cells collection.
            Cells cells = sheet.Cells;

            //Input a value.
            cells["B3"].PutValue("Choose Dept:");

            //Set it bold.
            cells["B3"].GetStyle().Font.IsBold = true;

            //Input some values that denote the input range
            //for the list box.
            cells["A2"].PutValue("Sales");
            cells["A3"].PutValue("Finance");
            cells["A4"].PutValue("MIS");
            cells["A5"].PutValue("R&D");
            cells["A6"].PutValue("Marketing");
            cells["A7"].PutValue("HRA");

            //Add a new list box.
            Aspose.Cells.Drawing.ListBox listBox = sheet.Shapes.AddListBox(2, 0, 3, 0, 122, 100);

            //Set the placement type.
            listBox.Placement = PlacementType.FreeFloating;

            //Set the linked cell.
            listBox.LinkedCell = "A1";

            //Set the input range.
            listBox.InputRange = "A2:A7";

            //Set the selection tyle.
            listBox.SelectionType = SelectionType.Single;

            //Set the list box with 3-D shading.
            listBox.Shadow = true;

            //Saves the file.
            workbook.Save(dataDir + "book1.xls");

        }
    }
}