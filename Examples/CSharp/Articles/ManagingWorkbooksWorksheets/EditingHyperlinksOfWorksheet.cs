using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class EditingHyperlinksOfWorksheet
    {
        public static void Run()
        {
            // ExStart:EditingHyperlinksOfWorksheet
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Workbook workbook = new Workbook(dataDir + "Sample.xlsx");

            Worksheet worksheet = workbook.Worksheets[0];

            for (int i = 0; i < worksheet.Hyperlinks.Count; i++)
            {
                Hyperlink hl = worksheet.Hyperlinks[i];
                hl.Address = "http://www.aspose.com";
            }

            workbook.Save(dataDir + "output_out_.xlsx");
            // ExEnd:EditingHyperlinksOfWorksheet
        }
    }
}
