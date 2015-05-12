//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace FormattingAColumn
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

            //Obtaining the reference of the first (default) worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[0];

            //Adding a new Style to the styles collection of the Excel object
            int i = workbook.Styles.Add();

            //Accessing the newly added Style to the Excel object
            Style style = workbook.Styles[i];

            //Setting the vertical alignment of the text in the "A1" cell
            style.VerticalAlignment = TextAlignmentType.Center;

            //Setting the horizontal alignment of the text in the "A1" cell
            style.HorizontalAlignment = TextAlignmentType.Center;

            //Setting the font color of the text in the "A1" cell
            style.Font.Color = Color.Green;

            //Shrinking the text to fit in the cell
            style.ShrinkToFit = true;

            //Setting the bottom border color of the cell to red
            style.Borders[BorderType.BottomBorder].Color = Color.Red;

            //Setting the bottom border type of the cell to medium
            style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Medium;

            //Creating StyleFlag
            StyleFlag styleFlag = new StyleFlag();
            styleFlag.HorizontalAlignment = true;
            styleFlag.VerticalAlignment = true;
            styleFlag.ShrinkToFit = true;
            styleFlag.Borders = true;
            styleFlag.FontColor = true;

            //Accessing a column from the Columns collection
            Column column = worksheet.Cells.Columns[0];

            //Applying the style to the column
            column.ApplyStyle(style, styleFlag);

            //Saving the Excel file
            workbook.Save(dataDir + "book1.xls");
        }
    }
}