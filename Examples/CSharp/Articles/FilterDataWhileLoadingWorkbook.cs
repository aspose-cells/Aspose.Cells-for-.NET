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
            LoadOptions opts = new LoadOptions(LoadFormat.Xlsx);
            opts.LoadDataFilterOptions = LoadDataFilterOptions.Shape;

            // Create workbook object from sample excel file using load options
            Workbook wb = new Workbook( dataDir + "sample.xlsx", opts);

            //Save the output in pdf format
            wb.Save(dataDir + "FilterDataWhileLoadingWorkbook_out.pdf", SaveFormat.Pdf);
            // ExEnd:1         
            
        }
    }
}
