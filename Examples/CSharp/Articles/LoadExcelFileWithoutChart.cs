using System.IO;
using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class LoadExcelFileWithoutChart
    {
        public static void Run() 
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Specify the load options and filter the data
            // We do not want to load charts
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.LoadFilter = new LoadFilter(LoadDataFilterOptions.All & ~LoadDataFilterOptions.Chart);

            // Load the workbook with specified load options
            Workbook workbook = new Workbook(sourceDir + "sampleLoadExcelFileWithoutChart.xlsx", loadOptions);

            // Save the workbook in output format
            workbook.Save(outputDir + "outputLoadExcelFileWithoutChart.pdf", SaveFormat.Pdf);

            Console.WriteLine("LoadExcelFileWithoutChart executed successfully.");
        }
    }
}
