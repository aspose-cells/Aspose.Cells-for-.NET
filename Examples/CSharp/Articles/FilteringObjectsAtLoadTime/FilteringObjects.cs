namespace Aspose.Cells.Examples.CSharp.Articles.FilteringObjectsAtLoadTime
{
    class FilteringObjects
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

            // Filter charts from the workbook
            LoadOptions lOptions = new LoadOptions();
            lOptions.LoadFilter = new LoadFilter(LoadDataFilterOptions.All & ~LoadDataFilterOptions.Chart);

            // Load the workbook with above filter
            Workbook workbook = new Workbook(dataDir + "sampleFilterCharts.xlsx", lOptions);

            // Save worksheet to a single PDF page
            PdfSaveOptions pOptions = new PdfSaveOptions();
            pOptions.OnePagePerSheet = true;

            // Save the workbook in pdf format
            workbook.Save(dataDir + "sampleFilterCharts.pdf", pOptions);
            // ExEnd:1

        }
    }
}
