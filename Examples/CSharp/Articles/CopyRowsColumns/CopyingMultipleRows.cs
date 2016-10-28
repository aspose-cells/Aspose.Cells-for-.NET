using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.CopyRowsColumns
{
    public class CopyingMultipleRows
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create an instance of Workbook class by loading the existing spreadsheet
            Workbook workbook = new Workbook(dataDir + "aspose-sample.xlsx");

            // Get the cells collection of worksheet by name Rows
            Cells cells = workbook.Worksheets["Rows"].Cells;

            // Copy the first 3 rows to 7th row
            cells.CopyRows(cells, 0, 6, 3);

            // Save the result on disc
            workbook.Save(dataDir + "output_out_.xlsx");
            // ExEnd:1
        }
    }
}
