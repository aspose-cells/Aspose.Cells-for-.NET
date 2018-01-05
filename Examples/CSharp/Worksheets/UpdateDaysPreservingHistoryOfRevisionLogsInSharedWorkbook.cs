using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Worksheets
{
    class UpdateDaysPreservingHistoryOfRevisionLogsInSharedWorkbook
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Create empty workbook
            Workbook wb = new Workbook();

            //Share the workbook
            wb.Settings.Shared = true;

            //Update DaysPreservingHistory of RevisionLogs
            wb.Worksheets.RevisionLogs.DaysPreservingHistory = 7;

            //Save the workbook
            wb.Save(outputDir + "outputShared_DaysPreservingHistory.xlsx");

            Console.WriteLine("UpdateDaysPreservingHistoryOfRevisionLogsInSharedWorkbook executed successfully.\r\n");
        }
    }
}
