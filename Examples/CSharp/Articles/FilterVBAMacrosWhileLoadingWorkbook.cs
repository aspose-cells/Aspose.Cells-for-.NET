using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class FilterVBAMacrosWhileLoadingWorkbook
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();
        public static void Main()
        {
            // ExStart:1
            // Set the load options, we do not want to load VBA
            LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
            loadOptions.LoadFilter = new LoadFilter(LoadDataFilterOptions.All & ~LoadDataFilterOptions.VBA);

            // Create workbook object from sample excel file using load options
            Workbook book = new Workbook(sourceDir + "sampleMacroEnabledWorkbook.xlsm", loadOptions);

            // Save the output in pdf format
            book.Save(outputDir + "OutputSampleMacroEnabledWorkbook.xlsm", SaveFormat.Xlsm);
            // ExEnd:1
            Console.WriteLine("FilterVBAMacrosWhileLoadingWorkbook executed successfully.");
        }
    }
}
