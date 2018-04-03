using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Pivot;
using System.Collections;

namespace Aspose.Cells.Examples.CSharp.PivotTables
{
    class GroupPivotFieldsInPivotTable
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            //Load sample workbook
            Workbook wb = new Workbook(sourceDir + "sampleGroupPivotFieldsInPivotTable.xlsx");

            //Access the second worksheet
            Worksheet ws = wb.Worksheets[1];

            //Access the pivot table
            PivotTable pt = ws.PivotTables[0];

            //Specify the start and end date time
            DateTime dtStart = new DateTime(2008, 1, 1);//1-Jan-2018
            DateTime dtEnd = new DateTime(2008, 9, 5); //5-Sep-2018

            //Specify the group type list, we want to group by months and quarters
            ArrayList groupTypeList = new ArrayList();
            groupTypeList.Add(PivotGroupByType.Months);
            groupTypeList.Add(PivotGroupByType.Quarters);

            //Apply the grouping on first pivot field
            pt.SetManualGroupField(0, dtStart, dtEnd, groupTypeList, 1);

            //Refresh and calculate pivot table
            pt.RefreshDataFlag = true;
            pt.RefreshData();
            pt.CalculateData();
            pt.RefreshDataFlag = false;

            //Save the output Excel file
            wb.Save(outputDir + "outputGroupPivotFieldsInPivotTable.xlsx");

            Console.WriteLine("GroupPivotFieldsInPivotTable executed successfully.");
        }
    }

}
