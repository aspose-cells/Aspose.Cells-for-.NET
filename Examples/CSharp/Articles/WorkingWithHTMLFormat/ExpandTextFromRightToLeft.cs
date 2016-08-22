using System.IO;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithHTMLFormat
{
    public class ExpandTextFromRightToLeft
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            
            // Load source excel file inside the workbook object
            Workbook wb = new Workbook(dataDir + "sample.xlsx");

            // Save workbook in html format
            wb.Save(dataDir + "ExpandTextFromRightToLeft_out_" + CellsHelper.GetVersion() + ".html", SaveFormat.Html);
            // ExEnd:1           
            
        }
    }
}
