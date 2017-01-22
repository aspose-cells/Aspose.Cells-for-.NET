using System;

namespace Aspose.Cells.Examples.CSharp.CellsHelperClass
{
    public class SignificantDigits
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //By default, Aspose.Cells stores 17 significant digits unlike
            //MS-Excel which stores only 15 significant digits
            CellsHelper.SignificantDigits = 15;

            //Create workbook
            Workbook workbook = new Workbook();

            //Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Access cell A1
            Cell c = worksheet.Cells["A1"];

            //Put double value, only 15 significant digits as specified by
            //CellsHelper.SignificantDigits above will be stored in excel file just like MS-Excel does
            c.PutValue(1234567890.123451711);

            //Save the workbook
            workbook.Save(dataDir + "out_SignificantDigits.xlsx");

        }
    }
}
