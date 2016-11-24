using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingRowsColumnsCells
{
    public class AddingHTMLRichTextInCell
    {
        public static void Run()
        {
            // ExStart:AddingHTMLRichTextInCell
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Workbook workbook = new Workbook();

            Worksheet worksheet = workbook.Worksheets[0];

            Cell cell = worksheet.Cells["A1"];
            cell.HtmlString = "<Font Style=\"FONT-WEIGHT: bold;FONT-STYLE: italic;TEXT-DECORATION: underline;FONT-FAMILY: Arial;FONT-SIZE: 11pt;COLOR: #ff0000;\">This is simple HTML formatted text.</Font>";

            workbook.Save(dataDir + "output_out.xlsx");
            // ExEnd:AddingHTMLRichTextInCell
        }
    }
}
