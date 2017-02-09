using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithHTMLFormat
{
    class RenderGradientFillToHTML
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Read the source excel file having text with gradient fill
            Workbook book = new Workbook(dataDir + "sourceGradientFill.xlsx");

            // Save workbook to html format
            book.Save(dataDir + "out_sourceGradientFill.html");
            // ExEnd:1
        }
    }
}
