using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Data.AddOn.Merging
{
    public class MergingCellsInWorksheet
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Create a Workbook.
            Workbook wbk = new Workbook();

            //Create a Worksheet and get the first sheet.
            Worksheet worksheet = wbk.Worksheets[0];

            //Create a Cells object ot fetch all the cells.
            Cells cells = worksheet.Cells;

            //Merge some Cells (C6:E7) into a single C6 Cell.
            cells.Merge(5, 2, 2, 3);

            //Input data into C6 Cell.
            worksheet.Cells[5, 2].PutValue("This is my value");

            //Create a Style object to fetch the Style of C6 Cell.
            Style style = worksheet.Cells[5, 2].GetStyle();

            //Create a Font object
            Font font = style.Font;

            //Set the name.
            font.Name = "Times New Roman";

            //Set the font size.
            font.Size = 18;

            //Set the font color
            font.Color = System.Drawing.Color.Blue;

            //Bold the text
            font.IsBold = true;

            //Make it italic
            font.IsItalic = true;

            //Set the backgrond color of C6 Cell to Red
            style.ForegroundColor = System.Drawing.Color.Red;
            style.Pattern = BackgroundType.Solid;

            //Apply the Style to C6 Cell.
            cells[5, 2].SetStyle(style);

            //Save the Workbook.
            wbk.Save(dataDir + "mergingcells.out.xls");

        }
    }
}