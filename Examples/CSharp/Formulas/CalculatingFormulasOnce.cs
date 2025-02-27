using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Formulas
{
    public class CalculatingFormulasOnce
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

          

            // Load the template workbook
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            // Print the time before formula calculation
            Console.WriteLine(DateTime.Now);

            // Set the CreateCalcChain as false
            workbook.Settings.FormulaSettings.EnableCalculationChain = false;

            // Calculate the workbook formulas
            workbook.CalculateFormula();

            // Print the time after formula calculation
            Console.WriteLine(DateTime.Now);
            // ExEnd:1

        }
    }
}
