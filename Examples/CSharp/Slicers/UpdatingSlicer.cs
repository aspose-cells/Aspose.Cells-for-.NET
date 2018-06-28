using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Slicers
{
    class UpdatingSlicer 
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            // Load sample Excel file containing slicer.
            Workbook wb = new Workbook(sourceDir + "sampleUpdatingSlicer.xlsx");

            // Access first worksheet.
            Worksheet ws = wb.Worksheets[0];

            // Access the first slicer inside the slicer collection.
            Aspose.Cells.Slicers.Slicer slicer = ws.Slicers[0];

            // Access the slicer items.
            Aspose.Cells.Slicers.SlicerCacheItemCollection scItems = slicer.SlicerCache.SlicerCacheItems;

            // Unselect 2nd and 3rd slicer items.
            scItems[1].Selected = false;
            scItems[2].Selected = false;

            // Refresh the slicer.
            slicer.Refresh();

            // Save the workbook in output XLSX format.
            wb.Save(outputDir + "outputUpdatingSlicer.xlsx", SaveFormat.Xlsx);

            Console.WriteLine("UpdatingSlicer executed successfully.");
        }

    }
}
