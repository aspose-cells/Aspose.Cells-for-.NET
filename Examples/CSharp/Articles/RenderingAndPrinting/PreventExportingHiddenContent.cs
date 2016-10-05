using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.RenderingAndPrinting
{
    public class PreventExportingHiddenContent
    {
        public static void Run()
        {
            // ExStart:PreventExportingHiddenContentWhileSavingAsHTML
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object
            Workbook workbook = new Workbook(dataDir + "WorkbookWithHiddenContent.xlsx");

            // Do not export hidden worksheet contents
            HtmlSaveOptions options = new HtmlSaveOptions();
            options.ExportHiddenWorksheet = false;

            // Save the workbook
            workbook.Save(dataDir + "HtmlWithoutHiddenContent_out_.html", options);
            // ExEnd:PreventExportingHiddenContentWhileSavingAsHTML
        }
    }
}
