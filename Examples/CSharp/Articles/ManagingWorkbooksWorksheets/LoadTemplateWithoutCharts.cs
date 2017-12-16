using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    class LoadTemplateWithoutCharts
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();
           
            // Specify the load options and filter the data
            LoadOptions options = new LoadOptions();

            // Include everything except charts
            options.LoadFilter = new LoadFilter(LoadDataFilterOptions.All & ~LoadDataFilterOptions.Chart);

            // Load the workbook with specified load options
            Workbook workbook = new Workbook(sourceDir + "sampleLoadTemplateWithoutCharts.xlsx", options);

            // Save the workbook in PDF format
            workbook.Save(outputDir + "outputLoadTemplateWithoutCharts.pdf", SaveFormat.Pdf);

            Console.WriteLine("LoadTemplateWithoutCharts executed successfully.\r\n");
        }
    }
}
