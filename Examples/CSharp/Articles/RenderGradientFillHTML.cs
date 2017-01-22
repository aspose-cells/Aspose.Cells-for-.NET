using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Tables;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class RenderGradientFillHTML
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Read the source excel file having text with gradient fill
            Workbook wb = new Workbook(dataDir + "sourceGradientFill.xlsx");

            //Save workbook to html format
            wb.Save(dataDir + "out_sourceGradientFill.html");
        }
    }
}
