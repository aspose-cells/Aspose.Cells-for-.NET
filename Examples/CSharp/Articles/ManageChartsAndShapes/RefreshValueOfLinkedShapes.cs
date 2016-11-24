using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    public class RefreshValueOfLinkedShapes
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook from source file
            Workbook workbook = new Workbook(dataDir + "LinkedShape.xlsx");

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Change the value of cell A1
            Cell cell = worksheet.Cells["A1"];
            cell.PutValue(100);

            // Update the value of the Linked Picture which is linked to cell A1
            worksheet.Shapes.UpdateSelectedValue();

            // Save the workbook in pdf format
            workbook.Save(dataDir + "output_out.pdf", SaveFormat.Pdf);
            // ExEnd:1
        }
    }
}
