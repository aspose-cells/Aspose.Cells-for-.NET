using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class FilterVBAMacrosWhileLoadingWorkbook
    {
        public static void Main()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Set the load options, we do not want to load VBA
            LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
            loadOptions.LoadFilter = new LoadFilter(LoadDataFilterOptions.All & ~LoadDataFilterOptions.VBA);

            // Create workbook object from sample excel file using load options
            Workbook book = new Workbook(sourceDir + "sampleMacroEnabledWorkbook.xlsm", loadOptions);

            // Save the output in pdf format
            book.Save(outputDir + "OutputSampleMacroEnabledWorkbook.xlsm", SaveFormat.Xlsm);

            Console.WriteLine("FilterVBAMacrosWhileLoadingWorkbook executed successfully.");
        }
    }
}
