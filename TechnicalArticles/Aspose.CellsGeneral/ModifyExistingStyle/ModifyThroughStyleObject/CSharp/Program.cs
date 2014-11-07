//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace ModifyThroughStyleObjectExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");
            //Create a workbook.
            Workbook workbook = new Workbook();

            //Create a new style object.
            Style style = workbook.Styles[workbook.Styles.Add()];

            //Set the number format.
            style.Number = 14;

            //Set the font color to red color.
            style.Font.Color = System.Drawing.Color.Red;

            //Name the style.
            style.Name = "Date1";

            //Get the first worksheet cells.
            Cells cells = workbook.Worksheets[0].Cells;

            //Specify the style (described above) to A1 cell.
            cells["A1"].SetStyle(style);

            //Create a range (B1:D1).
            Range range = cells.CreateRange("B1", "D1");

            //Initialize styleflag object.
            StyleFlag flag = new StyleFlag();

            //Set all formatting attributes on.
            flag.All = true;

            //Apply the style (described above)to the range.
            range.ApplyStyle(style, flag);

            //Modify the style (described above) and change the font color from red to black.
            style.Font.Color = System.Drawing.Color.Black;

            //Done! Since the named style (described above) has been set to a cell and range, 
            //the change would be Reflected(new modification is implemented) to cell(A1) and //range (B1:D1).
            style.Update();

            //Save the excel file. 
            workbook.Save(dataDir+ "book_styles.xls");
            
            
        }
    }
}