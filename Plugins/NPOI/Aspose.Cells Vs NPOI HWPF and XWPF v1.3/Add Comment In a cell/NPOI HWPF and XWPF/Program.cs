using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace AddCommentInCell_NPOI_
{
    class Program
    {
        static HSSFWorkbook hssfworkbook;

        static void Main(string[] args)
        {

            hssfworkbook = new HSSFWorkbook();

            ISheet sheet = hssfworkbook.CreateSheet("Cell comments in POI HSSF");

            // Create the drawing patriarch. This is the top level container for all shapes including cell comments.
            HSSFPatriarch patr = (HSSFPatriarch)sheet.CreateDrawingPatriarch();

            //Create a cell in row 3
            ICell cell1 = sheet.CreateRow(3).CreateCell(1);
            cell1.SetCellValue(new HSSFRichTextString("Hello, World"));

            //anchor defines size and position of the comment in worksheet
            IComment comment1 = patr.CreateCellComment(new HSSFClientAnchor(0, 0, 0, 0, 4, 2, 6, 5));

            // set text in the comment
            comment1.String = (new HSSFRichTextString("We can set comments in POI"));

            //set comment author.
            //you can see it in the status bar when moving mouse over the commented cell
            comment1.Author = ("Apache Software Foundation");

            // The first way to assign comment to a cell is via HSSFCell.SetCellComment method
            cell1.CellComment = (comment1);

            //Write the stream data of workbook to the root directory
            FileStream file = new FileStream(@"OutputAddedCommentInCell.xls", FileMode.Create);

            hssfworkbook.Write(file);

            file.Close();





            //hssfworkbook = new HSSFWorkbook();

            //Sheet sheet = hssfworkbook.CreateSheet("Cell comments in POI HSSF");

            //// Create the drawing patriarch. This is the top level container for all shapes including cell comments.
            //HSSFPatriarch patr = (HSSFPatriarch)sheet.CreateDrawingPatriarch();

            ////Create a cell in row 3
            //Cell cell1 = sheet.CreateRow(3).CreateCell(1);
            //cell1.SetCellValue(new HSSFRichTextString("Hello, World"));

            ////anchor defines size and position of the comment in worksheet
            //Comment comment1 = patr.CreateCellComment(new HSSFClientAnchor(0, 0, 0, 0, 4, 2, 6, 5));

            //// set text in the comment
            //comment1.String = (new HSSFRichTextString("We can set comments in POI"));

            ////set comment author.
            ////you can see it in the status bar when moving mouse over the commented cell
            //comment1.Author = ("Apache Software Foundation");

            //// The first way to assign comment to a cell is via HSSFCell.SetCellComment method
            //cell1.CellComment = (comment1);

            ////Write the stream data of workbook to the root directory
            //FileStream file = new FileStream(@"OutputAddedCommentInCell.xls", FileMode.Create);

            //hssfworkbook.Write(file);

            //file.Close();
        }
    }
}
