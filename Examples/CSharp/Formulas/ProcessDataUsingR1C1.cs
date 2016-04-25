using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Formulas
{
    public class ProcessDataUsingR1C1
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiating a Workbook object
            Workbook workbook = new Workbook(dataDir + "Book1.xls");

            Worksheet worksheet = workbook.Worksheets[0];

            //Setting an R1C1 formula on the "A1" cell
            worksheet.Cells["A11"].R1C1Formula = "=SUM(R[1]C[1]:R[3]C[1])";

            //Saving the Excel file
            workbook.Save(dataDir + "output.xls");
            //ExEnd:1

        }
    }
}
