using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Slicers
{
    class CreateSlicerToPivotTable
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            // Load sample Excel file containing pivot table.
            Workbook wb = new Workbook(sourceDir + "sampleCreateSlicerToPivotTable.xlsx");

            // Access first worksheet.
            Worksheet ws = wb.Worksheets[0];

            // Access first pivot table inside the worksheet.
            Aspose.Cells.Pivot.PivotTable pt = ws.PivotTables[0];

            // Add slicer relating to pivot table with first base field at cell B22.
            int idx = ws.Slicers.Add(pt, "B22", pt.BaseFields[0]);

            // Access the newly added slicer from slicer collection.
            Aspose.Cells.Slicers.Slicer slicer = ws.Slicers[idx];

            // Save the workbook in output XLSX format.
            wb.Save(outputDir + "outputCreateSlicerToPivotTable.xlsx", SaveFormat.Xlsx);

            // Save the workbook in output XLSB format.
            wb.Save(outputDir + "outputCreateSlicerToPivotTable.xlsb", SaveFormat.Xlsb);

            Console.WriteLine("CreateSlicerToPivotTable executed successfully.");
        }

    }
}

