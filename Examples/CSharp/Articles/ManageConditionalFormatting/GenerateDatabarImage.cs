using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Aspose.Cells.Rendering;
using System.Drawing.Imaging;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageConditionalFormatting
{
    public class GenerateDatabarImage
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create workbook object from source excel file
            Workbook workbook = new Workbook(sourceDir + "sampleGenerateDatabarImage.xlsx");

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access the cell which contains conditional formatting databar
            Cell cell = worksheet.Cells["C1"];

            // Create and get the conditional formatting of the worksheet
            int idx = worksheet.ConditionalFormattings.Add();
            FormatConditionCollection fcc = worksheet.ConditionalFormattings[idx];
            fcc.AddCondition(FormatConditionType.DataBar);
            fcc.AddArea(CellArea.CreateCellArea("C1", "C4"));

            // Access the conditional formatting databar
            DataBar dbar = fcc[0].DataBar;

            // Create image or print options
            ImageOrPrintOptions opts = new ImageOrPrintOptions();
            opts.ImageType = Drawing.ImageType.Png;

            // Get the image bytes of the databar
            byte[] imgBytes = dbar.ToImage(cell, opts);

            // Write image bytes on the disk
            File.WriteAllBytes(outputDir + "outputGenerateDatabarImage.png", imgBytes);

            Console.WriteLine("GenerateDatabarImage executed successfully.");
        }
    }
}
