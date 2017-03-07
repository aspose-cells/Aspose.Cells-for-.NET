using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Aspose.Cells.Examples.CSharp.LoadingSavingConvertingAndManaging
{
    public class AutoFitColumnsandRowsWhileLoadingHTMLInWorkbook
    {
        public static void Run()
        {
            // ExStart:AutoFitColumnsandRowsWhileLoadingHTMLInWorkbook
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Sample HTML.
            string sampleHtml = "<html><body><table><tr><td>This is sample text.</td><td>Some text.</td></tr><tr><td>This is another sample text.</td><td>Some text.</td></tr></table></body></html>";

            //Load html string into memory stream.
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(sampleHtml));

            //Load memory stream into workbook.
            Workbook wb = new Workbook(ms);

            //Save the workbook in xlsx format.
            wb.Save(dataDir + "outputWithout_AutoFitColsAndRows.xlsx");

            //Specify the HTMLLoadOptions and set AutoFitColsAndRows = true.
            HTMLLoadOptions opts = new HTMLLoadOptions();
            opts.AutoFitColsAndRows = true;

            //Load memory stream into workbook with the above HTMLLoadOptions.
            wb = new Workbook(ms, opts);

            //Save the workbook in xlsx format.
            wb.Save(dataDir + "outputWith_AutoFitColsAndRows.xlsx");
            // ExEnd:AutoFitColumnsandRowsWhileLoadingHTMLInWorkbook
        }
    }
}
