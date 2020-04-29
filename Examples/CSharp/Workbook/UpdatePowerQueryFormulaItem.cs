using Aspose.Cells.DigitalSignatures;
using Aspose.Cells.QueryTables;
using System;
using System.IO;

namespace Aspose.Cells.Examples.CSharp._Workbook
{
    public class UpdatePowerQueryFormulaItem
    {
        public static void Run()
        {
            // ExStart:1
            // Working directories
            string SourceDir = RunExamples.Get_SourceDirectory();
            string outputDir = RunExamples.Get_OutputDirectory();

            Workbook workbook = new Workbook(SourceDir + "SamplePowerQueryFormula.xlsx");
            DataMashup mashupData = workbook.DataMashup;
            foreach (PowerQueryFormula formula in mashupData.PowerQueryFormulas)
            {
                foreach (PowerQueryFormulaItem item in formula.PowerQueryFormulaItems)
                {
                    if (item.Name == "Source")
                    {
                        item.Value = "Excel.Workbook(File.Contents(\"" + SourceDir + "SamplePowerQueryFormulaSource.xlsx\"), null, true)";
                    }
                }
            }

            // Save the output workbook.
            workbook.Save(outputDir + "SamplePowerQueryFormula_out.xlsx");
            // ExEnd:1

            Console.WriteLine("UpdatePowerQueryFormulaItem executed successfully.");
        }
    }
}
