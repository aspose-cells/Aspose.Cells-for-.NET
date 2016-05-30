using System.IO;

using Aspose.Cells;
using System.Drawing;
using Aspose.Cells.Pivot;

namespace CSharp.PivotTableExamples
{
    public class ConsolidationFunctions
    {
               public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                   
            // Create workbook from source excel file
            Workbook workbook = new Workbook(dataDir + "Book.xlsx");

            // Access the first worksheet of the workbook
            Worksheet worksheet = workbook.Worksheets[0];

            // Access the first pivot table of the worksheet
            PivotTable pivotTable = worksheet.PivotTables[0];

            // Apply Average consolidation function to first data field
            pivotTable.DataFields[0].Function = ConsolidationFunction.Average;

            // Apply DistinctCount consolidation function to second data field
            pivotTable.DataFields[1].Function = ConsolidationFunction.DistinctCount;

            // Calculate the data to make changes affect
            pivotTable.CalculateData();
                  
            // Saving the Excel file
            workbook.Save(dataDir + "output.xlsx");

            // ExEnd:1

        }
    }
}