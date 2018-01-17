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
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create workbook from source file
            Workbook workbook = new Workbook(sourceDir + "sampleRefreshValueOfLinkedShapes.xlsx");

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Change the value of cell B4
            Cell cell = worksheet.Cells["B4"];
            cell.PutValue(100);

            // Update the value of the Linked Picture which is linked to cell B4
            worksheet.Shapes.UpdateSelectedValue();

            // Save the workbook in pdf format
            workbook.Save(outputDir + "outputRefreshValueOfLinkedShapes.pdf", SaveFormat.Pdf);

            Console.WriteLine("RefreshValueOfLinkedShapes executed successfully.");
        }
    }
}
