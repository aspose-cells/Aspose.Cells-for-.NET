using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Slicers
{
    class FormattingSlicer
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            // Load sample Excel file containing slicer.
            Workbook wb = new Workbook(sourceDir + "sampleFormattingSlicer.xlsx");

            // Access first worksheet.
            Worksheet ws = wb.Worksheets[0];

            // Access the first slicer inside the slicer collection.
            Aspose.Cells.Slicers.Slicer slicer = ws.Slicers[0];

            // Set the number of columns of the slicer.
            slicer.NumberOfColumns = 2;

            // Set the type of slicer style.
            slicer.StyleType = Aspose.Cells.Slicers.SlicerStyleType.SlicerStyleLight6;

            // Save the workbook in output XLSX format.
            wb.Save(outputDir + "outputFormattingSlicer.xlsx", SaveFormat.Xlsx);

            Console.WriteLine("FormattingSlicer executed successfully.");
        }
    }
}
