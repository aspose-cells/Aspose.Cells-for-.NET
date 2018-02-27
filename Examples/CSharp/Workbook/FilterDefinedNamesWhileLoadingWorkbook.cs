using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp._Workbook
{
    class FilterDefinedNamesWhileLoadingWorkbook 
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            //Specify the load options
            LoadOptions opts = new LoadOptions();

            //We do not want to load defined names
            opts.LoadFilter = new LoadFilter(~LoadDataFilterOptions.DefinedNames);

            //Load the workbook
            Workbook wb = new Workbook(sourceDir + "sampleFilterDefinedNamesWhileLoadingWorkbook.xlsx", opts);

            //Save the output Excel file, it will break the formula in C1
            wb.Save(outputDir + "outputFilterDefinedNamesWhileLoadingWorkbook.xlsx");

            Console.WriteLine("FilterDefinedNamesWhileLoadingWorkbook executed successfully.");
        }
    }
}
