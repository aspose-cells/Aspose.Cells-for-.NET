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
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Set the load options, we only want to load shapes and do not want to load data
            LoadOptions loadOptions = new LoadOptions(LoadFormat.Xlsx);
            loadOptions.LoadFilter = new LoadFilter(LoadDataFilterOptions.Shape);

            // Create workbook object from sample excel file using load options
            Workbook book = new Workbook( dataDir + "sample.xlsx", loadOptions);

            // Save the output in pdf format
            book.Save(dataDir + "FilterDataWhileLoadingWorkbook_out.pdf", SaveFormat.Pdf);
            // ExEnd:1         
            
        }
    }
}
