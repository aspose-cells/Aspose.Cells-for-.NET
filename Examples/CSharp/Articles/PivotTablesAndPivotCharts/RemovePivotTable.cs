using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Pivot;

namespace Aspose.Cells.Examples.CSharp.Articles.PivotTablesAndPivotCharts
{
    public class RemovePivotTable
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create workbook object from source Excel file
            Workbook workbook = new Workbook(sourceDir + "sampleRemovePivotTable.xlsx");

            // Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access the first pivot table object
            PivotTable pivotTable = worksheet.PivotTables[0];

            // Remove pivot table using pivot table object
            worksheet.PivotTables.Remove(pivotTable);

            // OR you can remove pivot table using pivot table position by uncommenting below line
            //worksheet.PivotTables.RemoveAt(0);

            // Save the workbook
            workbook.Save(outputDir + "outputRemovePivotTable.xlsx");

            Console.WriteLine("RemovePivotTable executed successfully.");
        }
    }
}
