using Aspose.Cells.Rendering;
using System.Drawing.Imaging;

namespace Aspose.Cells.Examples.CSharp.Articles.FilteringObjectsAtLoadTime
{
    // ExStart:CustomLoadFilter
    public class CustomLoadFilter : LoadFilter
    {
        public override void StartSheet(Worksheet sheet)
        {
            if (sheet.Name == "NoCharts")
            {
                //Load everything and filter charts
                this.m_LoadDataFilterOptions = LoadDataFilterOptions.All & ~LoadDataFilterOptions.Chart;
            }

            if (sheet.Name == "NoShapes")
            {
                //Load everything and filter shapes
                this.m_LoadDataFilterOptions = LoadDataFilterOptions.All & ~LoadDataFilterOptions.Shape;
            }

            if (sheet.Name == "NoConditionalFormatting)")
            {
                //Load everything and filter conditional formatting
                this.m_LoadDataFilterOptions = LoadDataFilterOptions.All & ~LoadDataFilterOptions.ConditionalFormatting;
            }
        }
    }
    // ExEnd:CustomLoadFilter

    class CustomFilteringPerWorksheet
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            // Filter worksheets using CustomLoadFilter class
            LoadOptions loadOpts = new LoadOptions();
            loadOpts.LoadFilter = new CustomLoadFilter();

            // Load the workbook with filter defined in CustomLoadFilter class
            Workbook workbook = new Workbook(dataDir + "sampleCustomFilter.xlsx", loadOpts);

            // Take the image of all worksheets one by one
            for (int i = 0; i < workbook.Worksheets.Count; i++)
            {
                // Access worksheet at index i
                Worksheet worksheet = workbook.Worksheets[i];

                // Create an instance of ImageOrPrintOptions
                // Render entire worksheet to image
                ImageOrPrintOptions imageOpts = new ImageOrPrintOptions();
                imageOpts.OnePagePerSheet = true;
                imageOpts.ImageFormat = ImageFormat.Png;

                // Convert worksheet to image
                SheetRender render = new SheetRender(worksheet, imageOpts);
                render.ToImage(0, dataDir + worksheet.Name + ".png");
            }

            // ExEnd:1


        }
    }
}
