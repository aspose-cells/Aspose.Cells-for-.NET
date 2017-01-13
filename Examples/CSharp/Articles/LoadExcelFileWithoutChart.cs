using System.IO;
using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class LoadExcelFileWithoutChart
    {
        public static void Run() 
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Specify the load options and filter the data
            // We do not want to load charts
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.LoadFilter = new LoadFilter(LoadDataFilterOptions.All & ~LoadDataFilterOptions.Chart);

            // Load the workbook with specified load options
            Workbook workbook = new Workbook(dataDir + "sample.xlsx", loadOptions);

            // Save the workbook in output format
            workbook.Save(dataDir + "LoadExcelFileWithoutChart_out.pdf", SaveFormat.Pdf);
            // ExEnd:1           
            
        }
    }
}
