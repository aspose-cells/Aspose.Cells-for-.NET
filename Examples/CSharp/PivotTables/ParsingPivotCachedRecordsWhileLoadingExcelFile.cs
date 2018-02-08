using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aspose.Cells;
using Aspose.Cells.Pivot;

namespace Aspose.Cells.Examples.CSharp.PivotTables
{
    class ParsingPivotCachedRecordsWhileLoadingExcelFile 
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Create load options
            LoadOptions options = new LoadOptions();

            //Set ParsingPivotCachedRecords true, default value is false
            options.ParsingPivotCachedRecords = true;

            //Load the sample Excel file containing pivot table cached records
            Workbook wb = new Workbook(sourceDir + "sampleParsingPivotCachedRecordsWhileLoadingExcelFile.xlsx", options);

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Access first pivot table
            PivotTable pt = ws.PivotTables[0];

            //Set refresh data flag true
            pt.RefreshDataFlag = true;

            //Refresh and calculate pivot table
            pt.RefreshData();
            pt.CalculateData();

            //Set refresh data flag false
            pt.RefreshDataFlag = false;

            //Save the output Excel file
            wb.Save(outputDir + "outputParsingPivotCachedRecordsWhileLoadingExcelFile.xlsx");

            Console.WriteLine("ParsingPivotCachedRecordsWhileLoadingExcelFile executed successfully.");
        }       
    }
}
