using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aspose.Cells;
using Aspose.Cells.Pivot;

namespace Aspose.Cells.Examples.CSharp.PivotTables
{
    class FindAndRefreshNestedOrChildrenPivotTables 
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Load sample Excel file
            Workbook wb = new Workbook(sourceDir + "sampleFindAndRefreshNestedOrChildrenPivotTables.xlsx");

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Access third pivot table
            PivotTable ptParent = ws.PivotTables[2];

            //Access the children of the parent pivot table
            PivotTable[] ptChildren = ptParent.GetChildren();

            //Refresh all the children pivot table
            int count = ptChildren.Length;
            for (int idx = 0; idx < count; idx++)
            {
                //Access the child pivot table
                PivotTable ptChild = ptChildren[idx];

                //Refresh the child pivot table
                ptChild.RefreshData();
                ptChild.CalculateData();
            }

            Console.WriteLine("FindAndRefreshNestedOrChildrenPivotTables executed successfully.");
        }
    }
}
