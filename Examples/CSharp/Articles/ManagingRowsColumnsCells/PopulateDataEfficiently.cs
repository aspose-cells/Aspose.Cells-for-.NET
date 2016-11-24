using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingRowsColumnsCells
{
    public class PopulateDataEfficiently
    {
        public static void Run()
        {
            // ExStart:PopulateDataFirstByRowThenColumns
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create a workbook
            Workbook workbook = new Workbook();

            // Populate Data into Cells
            Cells cells = workbook.Worksheets[0].Cells;
            cells["A1"].PutValue("data1");
            cells["B1"].PutValue("data2");
            cells["A2"].PutValue("data3");
            cells["B2"].PutValue("data4");

            // Save workbook
            workbook.Save(dataDir + "output_out.xlsx");
            // ExEnd:PopulateDataFirstByRowThenColumns
        }
    }
}
