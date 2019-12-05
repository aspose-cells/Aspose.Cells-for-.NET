using Aspose.Cells.QueryTables;
using System;

namespace Aspose.Cells.Examples.CSharp._Workbook
{
    public class GetOdataDetails
    {
        public static void Run()
        {
            // ExStart:1
            // source directory
            string SourceDir = RunExamples.Get_SourceDirectory();

            Workbook workbook = new Workbook(SourceDir + "ODataSample.xlsx");
            PowerQueryFormulaCollction PQFcoll = workbook.DataMashup.PowerQueryFormulas;
            foreach (PowerQueryFormula PQF in PQFcoll)
            {
                Console.WriteLine("Connection Name: " + PQF.Name);
                PowerQueryFormulaItemCollection PQFIcoll = PQF.PowerQueryFormulaItems;
                foreach (PowerQueryFormulaItem PQFI in PQFIcoll)
                {
                    Console.WriteLine("Name: " + PQFI.Name);
                    Console.WriteLine("Value: " + PQFI.Value);
                }
            }
            // ExEnd:1

            Console.WriteLine("GetOdataDetails executed successfully.");
        }
    }
}
