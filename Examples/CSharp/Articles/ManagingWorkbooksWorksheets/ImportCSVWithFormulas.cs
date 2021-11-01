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
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            TxtLoadOptions opts = new TxtLoadOptions();
            opts.Separator = ',';
            opts.HasFormula = true;

            // Load your csv file with formulas in a Workbook object
            Workbook workbook = new Workbook(sourceDir + "sampleImportCSVWithFormulas.csv", opts);

            // You can also import your csv file like this
            // The code below is importing csv file starting from cell D4
            Worksheet worksheet = workbook.Worksheets[0];
            worksheet.Cells.ImportCSV(sourceDir + "sampleImportCSVWithFormulas.csv", opts, 3, 3);

            // Save your workbook in Xlsx format
            workbook.Save(outputDir + "outputImportCSVWithFormulas.xlsx");

            Console.WriteLine("ImportCSVWithFormulas executed successfully.");
        }
    }
}
