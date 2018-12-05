using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ReplaceTextInSmartArt
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            // ExStart:1
            Workbook wb = new Workbook(sourceDir + "SmartArt.xlsx");
            foreach (Worksheet worksheet in wb.Worksheets)
            {
                foreach (Shape shape in worksheet.Shapes)
                {
                    shape.AlternativeText = "ReplacedAlternativeText"; // This works fine just as the normal Shape objects do.
                    if (shape.IsSmartArt)
                    {
                        foreach (Shape smartart in shape.GetResultOfSmartArt().GetGroupedShapes())
                        {
                            smartart.Text = "ReplacedText"; // This doesn't update the text in Workbook which I save to the another file.
                        }
                    }
                }
            }
            Aspose.Cells.OoxmlSaveOptions options = new Aspose.Cells.OoxmlSaveOptions();
            options.UpdateSmartArt = true;
            wb.Save(outputDir + "outputSmartArt.xlsx", options);
            // ExEnd:1

            Console.WriteLine("\r\nReplaceTextInSmartArt executed successfully.\r\n");
        }
    }
}
