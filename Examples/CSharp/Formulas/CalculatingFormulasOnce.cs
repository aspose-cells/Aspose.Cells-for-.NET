using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.Formulas
{
    public class CalculatingFormulasOnce
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

          

            //Load the template workbook
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            //Print the time before formula calculation
            Console.WriteLine(DateTime.Now);

            //Set the CreateCalcChain as false
            workbook.Settings.CreateCalcChain = false;

            //Calculate the workbook formulas
            workbook.CalculateFormula();

            //Print the time after formula calculation
            Console.WriteLine(DateTime.Now);

        }
    }
}