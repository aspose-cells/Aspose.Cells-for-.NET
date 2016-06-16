using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Formulas
{
    public class ProcessDataUsingR1C1
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiating a Workbook object
            Workbook workbook = new Workbook(dataDir + "Book1.xls");

            Worksheet worksheet = workbook.Worksheets[0];

            // Setting an R1C1 formula on the "A11" cell, 
            // Row and Column indeces are relative to destination index
            worksheet.Cells["A11"].R1C1Formula = "=SUM(R[-10]C[0]:R[-7]C[0])";

            // Saving the Excel file
            workbook.Save(dataDir + "output.xls");
            // ExEnd:1

        }
    }
}
