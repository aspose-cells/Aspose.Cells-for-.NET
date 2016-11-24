using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Tables;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class PropagateFormulaInTable
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object
            Workbook book = new Workbook();

            // Access first worksheet
            Worksheet sheet = book.Worksheets[0];

            // Add column headings in cell A1 and B1
            sheet.Cells[0, 0].PutValue("Column A");
            sheet.Cells[0, 1].PutValue("Column B");

            // Add list object, set its name and style
            ListObject listObject = sheet.ListObjects[sheet.ListObjects.Add(0, 0, 1, sheet.Cells.MaxColumn, true)];
            listObject.TableStyleType = TableStyleType.TableStyleMedium2;
            listObject.DisplayName = "Table";

            // Set the formula of second column so that it propagates to new rows automatically while entering data
            listObject.ListColumns[1].Formula = "=[Column A] + 1";

            // Save the workbook in xlsx format
            book.Save(dataDir + "output_out.xlsx");
            // ExEnd:1
        }
    }
}
