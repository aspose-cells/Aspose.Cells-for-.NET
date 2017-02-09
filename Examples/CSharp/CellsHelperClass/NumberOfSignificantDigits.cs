using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.CellsHelperClass
{
    class NumberOfSignificantDigits
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Set the number of significant digits
            CellsHelper.SignificantDigits = 15;

            // Create an instance of Workbook class
            Workbook workbook = new Workbook();

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access cell A1
            Cell cell = worksheet.Cells["A1"];

            // Put double value, only 15 significant digits as specified by
            // CellsHelper.SignificantDigits above will be stored in excel file just like MS-Excel does
            cell.PutValue(1234567890.123451711);

            // Save the workbook
            workbook.Save(dataDir + "out_SignificantDigits.xlsx");
            // ExEnd:1


        }
    }
}
