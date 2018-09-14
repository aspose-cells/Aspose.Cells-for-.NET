using Aspose.Cells.Rendering;
using System.Drawing.Imaging;
using System;

namespace Aspose.Cells.Examples.CSharp.Articles.FilteringObjectsAtLoadTime
{
    public class CustomLoadFilter : LoadFilter
    {
        public override void StartSheet(Worksheet sheet)
        {
            if (sheet.Name == "NoCharts")
            {
                //Load everything and filter charts
                this.LoadDataFilterOptions = LoadDataFilterOptions.All & ~LoadDataFilterOptions.Chart;
            }

            if (sheet.Name == "NoShapes")
            {
                //Load everything and filter shapes
                this.LoadDataFilterOptions = LoadDataFilterOptions.All & ~LoadDataFilterOptions.Shape;
            }

            if (sheet.Name == "NoConditionalFormatting)")
            {
                //Load everything and filter conditional formatting
                this.LoadDataFilterOptions = LoadDataFilterOptions.All & ~LoadDataFilterOptions.ConditionalFormatting;
            }
        }
    }

    class CustomFilteringPerWorksheet
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Filter worksheets using CustomLoadFilter class
            LoadOptions loadOpts = new LoadOptions();
            loadOpts.LoadFilter = new CustomLoadFilter();

            // Load the workbook with filter defined in CustomLoadFilter class
            Workbook workbook = new Workbook(sourceDir + "sampleCustomFilteringPerWorksheet.xlsx", loadOpts);

            // Take the image of all worksheets one by one
            for (int i = 0; i < workbook.Worksheets.Count; i++)
            {
                // Access worksheet at index i
                Worksheet worksheet = workbook.Worksheets[i];

                // Create an instance of ImageOrPrintOptions
                // Render entire worksheet to image
                ImageOrPrintOptions imageOpts = new ImageOrPrintOptions();
                imageOpts.OnePagePerSheet = true;
                imageOpts.ImageType = Drawing.ImageType.Png;

                // Convert worksheet to image
                SheetRender render = new SheetRender(worksheet, imageOpts);
                render.ToImage(0, outputDir + "outputCustomFilteringPerWorksheet_" + worksheet.Name + ".png");
            }

            Console.WriteLine("CustomFilteringPerWorksheet executed successfully.");
        }
    }
}
