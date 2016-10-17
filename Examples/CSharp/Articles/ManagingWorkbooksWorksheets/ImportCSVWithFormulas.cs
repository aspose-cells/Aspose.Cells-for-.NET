using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class ImportCSVWithFormulas
    {
        public static void Run()
        {
            // ExStart:ImportCSVWithFormulas
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            TxtLoadOptions opts = new TxtLoadOptions();
            opts.Separator = ',';
            opts.HasFormula = true;

            // Load your CSV file with formulas in a Workbook object
            Workbook workbook = new Workbook(dataDir + "sample.csv", opts);

            // You can also import your CSV file like this
            // The code below is importing CSV file starting from cell D4
            Worksheet worksheet = workbook.Worksheets[0];
            worksheet.Cells.ImportCSV(dataDir + "sample.csv", opts, 3, 3);

            // Save your workbook in Xlsx format
            workbook.Save(dataDir + "output_out_.xlsx");
            // ExEnd:ImportCSVWithFormulas
        }
    }
}
