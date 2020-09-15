using Aspose.Cells.Drawing;
using Aspose.Cells.Slicers;
using Aspose.Cells.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Slicers
{
    class ChangeSlicerProperties
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // ExStart:1
            // Load sample Excel file containing a table.
            Workbook workbook = new Workbook(sourceDir + "sampleCreateSlicerToExcelTable.xlsx");

            // Access first worksheet.
            Worksheet worksheet = workbook.Worksheets[0];

            // Access first table inside the worksheet.
            ListObject table = worksheet.ListObjects[0];

            // Add slicer
            int idx = worksheet.Slicers.Add(table, 0, "H5");

            Slicer slicer = worksheet.Slicers[idx];
            slicer.Placement = PlacementType.FreeFloating;
            slicer.RowHeightPixel = 50;
            slicer.WidthPixel = 500;
            slicer.Title = "Aspose";
            slicer.AlternativeText = "Alternate Text";
            slicer.IsPrintable = false;
            slicer.IsLocked = false;

            // Refresh the slicer.
            slicer.Refresh();


            // Save the workbook in output XLSX format.
            workbook.Save(outputDir + "outputChangeSlicerProperties.xlsx", SaveFormat.Xlsx);
            // ExEnd:1

            Console.WriteLine("ChangeSlicerProperties executed successfully.");
        }

    }
}

