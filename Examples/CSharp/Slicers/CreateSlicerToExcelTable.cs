using Aspose.Cells.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Slicers
{
    class CreateSlicerToExcelTable
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
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

            // Save the workbook in output XLSX format.
            workbook.Save(outputDir + "outputCreateSlicerToExcelTable.xlsx", SaveFormat.Xlsx);
            // ExEnd:1

            Console.WriteLine("CreateSlicerToExcelTable executed successfully.");
        }

    }
}

