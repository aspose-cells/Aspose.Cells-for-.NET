using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.DrawingObjects
{
    class SetMarginsOfCommentOrShapeInsideTheWorksheet 
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            //Load the sample Excel file
            Workbook wb = new Workbook(sourceDir + "sampleSetMarginsOfCommentOrShapeInsideTheWorksheet.xlsx");

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            foreach (Shape sh in ws.Shapes)
            {
                //Access the text alignment
                Aspose.Cells.Drawing.Texts.ShapeTextAlignment txtAlign = sh.TextBody.TextAlignment;

                //Set auto margin false
                txtAlign.IsAutoMargin = false;

                //Set the top, left, bottom and right margins
                txtAlign.TopMarginPt = 10;
                txtAlign.LeftMarginPt = 10;
                txtAlign.BottomMarginPt = 10;
                txtAlign.RightMarginPt = 10;
            }

            //Save the output Excel file
            wb.Save(outputDir + "outputSetMarginsOfCommentOrShapeInsideTheWorksheet.xlsx");

            Console.WriteLine("SetMarginsOfCommentOrShapeInsideTheWorksheet executed successfully.");
        }
    }
}
