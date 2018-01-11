using System;

namespace Aspose.Cells.Examples.CSharp.Articles.FilteringObjectsAtLoadTime
{
    class FilteringObjects
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Filter charts from the workbook
            LoadOptions lOptions = new LoadOptions();
            lOptions.LoadFilter = new LoadFilter(LoadDataFilterOptions.All & ~LoadDataFilterOptions.Chart);

            // Load the workbook with above filter
            Workbook workbook = new Workbook(sourceDir + "sampleFilteringObjects.xlsx", lOptions);

            // Save worksheet to a single PDF page
            PdfSaveOptions pOptions = new PdfSaveOptions();
            pOptions.OnePagePerSheet = true;

            // Save the workbook in pdf format
            workbook.Save(outputDir + "outputFilteringObjects.pdf", pOptions);

            Console.WriteLine("FilteringObjects executed successfully.");
        }
    }
}
