using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.RenderingAndPrinting
{
    public class PrintCommentWhileSavingToPdf
    {
        public static void Run()
        {
            // ExStart:PrintCommentWhileSavingToPdf
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create a workbook from source Excel file
            Workbook workbook = new Workbook(dataDir + "SampleWorkbookWithComments.xlsx");

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            /*
             * For print no comments use "PrintCommentsType.PrintNoComments"
             * and for print the comments as displayed on sheet use "PrintCommentsType.PrintInPlace"
             * For Print the comments at the end of sheet we use "PrintCommentsType.PrintSheetEnd"
            */
            worksheet.PageSetup.PrintComments = PrintCommentsType.PrintSheetEnd;

            // Save workbook in pdf format
            workbook.Save(dataDir + "PrintCommentWhileSavingToPdf_out.pdf");
            // ExEnd:PrintCommentWhileSavingToPdf
        }
    }
}
