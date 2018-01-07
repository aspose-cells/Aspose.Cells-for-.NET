using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class InsertLinkedPicture
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            Workbook workbook = new Workbook();

            // Insert a linked picture (from Web Address) to B2 Cell.
            Aspose.Cells.Drawing.Picture pic = workbook.Worksheets[0].Shapes.AddLinkedPicture(1, 1, 100, 100, "http://www.aspose.com/Images/aspose-logo.jpg");
            
            // Set the height and width of the inserted image.
            pic.HeightInch = 1.04;
            pic.WidthInch = 2.6;
            
            // Save the Excel file.
            workbook.Save(outputDir + "outputInsertLinkedPicture.xlsx");

            Console.WriteLine("InsertLinkedPicture executed successfully.");
        }
    }
}
