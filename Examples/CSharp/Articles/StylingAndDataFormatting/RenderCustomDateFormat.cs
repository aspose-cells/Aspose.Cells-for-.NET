using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.StylingAndDataFormatting
{
    public class RenderCustomDateFormat
    {
        public static void Run()
        {
            // ExStart:RenderCustomDateFormatPatterngandgemmdd
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Workbook workbook = new Workbook(dataDir + "SourceFile.xlsx");
            workbook.Save(dataDir + "CustomDateFormat_out.pdf");
            // ExEnd:RenderCustomDateFormatPatterngandgemmdd
        }
    }
}
