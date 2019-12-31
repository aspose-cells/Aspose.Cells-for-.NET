using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class FilterDataWhileLoadingWorkbook
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Set the load options, we only want to load shapes and do not want to load data
            LoadOptions loadOptions = new LoadOptions(LoadFormat.Xlsx);
            loadOptions.LoadFilter = new LoadFilter(LoadDataFilterOptions.All & ~LoadDataFilterOptions.Chart);

            // Create workbook object from sample excel file using load options
            Workbook workbook = new Workbook(sourceDir + "sampleFilterChars.xlsx", loadOptions);

            // Save the output in pdf format
            workbook.Save(outputDir + "sampleFilterChars_out.pdf", SaveFormat.Pdf);
            // ExEnd:1

            Console.WriteLine("FilterDataWhileLoadingWorkbook executed successfully.");
        }
    }
}
