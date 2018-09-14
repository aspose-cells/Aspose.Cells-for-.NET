using System.IO;

using Aspose.Cells;
using System.Drawing;
using Aspose.Cells.Pivot;
using System;

namespace Aspose.Cells.Examples.CSharp.PivotTableExamples
{
    public class DisablePivotTableRibbon
    {
        public static void Main()
        {
            // For complete examples and data files, please go to https://github.com/aspose-cells/Aspose.Cells-for-.NET

            // Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open the template file containing the pivot table
            Workbook wb = new Workbook(sourceDir + "samplePivotTableTest.xlsx");
            
            // Access the pivot table in the first sheet
            PivotTable pt = wb.Worksheets[0].PivotTables[0];
            
            // Disable ribbon for this pivot table
            pt.EnableWizard = false;
            
            // Save output file
            wb.Save(outputDir + "outputSamplePivotTableTest.xlsx");

            Console.WriteLine("DisablePivotTableRibbon executed successfully.\r\n");

        }
    }
}