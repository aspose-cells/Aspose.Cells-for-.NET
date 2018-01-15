using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.CopyShapesBetweenWorksheets
{
    public class CopyControls
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create a workbook object
            // Open the template file
            Workbook workbook = new Workbook(sourceDir + "sampleCopyControls.xlsx");

            // Get the Shapes from the "Control" worksheet.
            Aspose.Cells.Drawing.ShapeCollection shape = workbook.Worksheets["Sheet1"].Shapes;

            // Copy the Textbox to the Result Worksheet
            workbook.Worksheets["Result"].Shapes.AddCopy(shape[0], 5, 0, 2, 0);

            // Copy the Oval Shape to the Result Worksheet
            workbook.Worksheets["Result"].Shapes.AddCopy(shape[1], 10, 0, 2, 0);

            // Save the Worksheet
            workbook.Save(outputDir + "outputCopyControls.xlsx");

            Console.WriteLine("CopyControls executed successfully.");
        }
    }
}
