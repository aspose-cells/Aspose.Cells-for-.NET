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
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            
            // Specify the load options and filter the data
            LoadOptions options = new LoadOptions();

            // Include everything except charts
            options.LoadFilter = new LoadFilter(LoadDataFilterOptions.All & ~LoadDataFilterOptions.Chart);

            // Load the workbook with specified load options
            Workbook workbook = new Workbook(dataDir + "chart.xlsx", options);

            // Save the workbook in PDF format
            workbook.Save(dataDir + "ResultWithoutChart.pdf", SaveFormat.Pdf);
            // ExEnd:1
        }
    }
}
