using System;
using System.IO;
using System.Drawing;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.CopyShapesBetweenWorksheets
{
    public class CopyingPicture
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create a workbook object
            // Open the template file
            Workbook workbook = new Workbook(sourceDir + "sampleCopyingPicture.xlsx");

            // Get the Picture from the "Picture" worksheet.
            Aspose.Cells.Drawing.Picture source = workbook.Worksheets["Sheet1"].Pictures[0];

            // Save Picture to Memory Stream
            MemoryStream ms = new MemoryStream(source.Data);

            // Copy the picture to the Result Worksheet
            workbook.Worksheets["Sheet2"].Pictures.Add(source.UpperLeftRow, source.UpperLeftColumn, ms, source.WidthScale, source.HeightScale);

            // Save the Worksheet
            workbook.Save(outputDir + "outputCopyingPicture.xlsx");

            Console.WriteLine("CopyingPicture executed successfully.");
        }
    }
}
