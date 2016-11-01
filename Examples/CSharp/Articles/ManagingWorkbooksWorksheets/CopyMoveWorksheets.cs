using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class CopyMoveWorksheets
    {
        public static void Run()
        {
            // ExStart:CopyWorksheets
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Open a file into the first book.
            Workbook excelWorkbook1 = new Workbook(dataDir + @"FirstWorkbook.xlsx");

            // Copy the first sheet of the first book with in the workbook
            excelWorkbook1.Worksheets[2].Copy(excelWorkbook1.Worksheets["Copy"]);

            // Save the file.
            excelWorkbook1.Save(dataDir + @"FirstWorkbookCopied_out_.xlsx");
            // ExEnd:CopyWorksheets

            // ExStart:MoveWorksheets
            // Open a file into the first book.
            Workbook excelWorkbook2 = new Workbook(dataDir + @"FirstWorkbook.xlsx");

            // Move the sheet
            excelWorkbook2.Worksheets["Move"].MoveTo(2);

            // Save the file.
            excelWorkbook2.Save(dataDir + @"FirstWorkbookMoved_out_.xlsx");
            // ExEnd:MoveWorksheets

            // ExStart:CopyWorksheetsBetweenWorkbooks
            // Open a file into the first book.
            Workbook excelWorkbook3 = new Workbook(dataDir + @"FirstWorkbook.xlsx");

            // Open a file into the second book.
            Workbook excelWorkbook4 = new Workbook(dataDir + @"SecondWorkbook.xlsx");

            // Add new worksheet into second Workbook
            excelWorkbook4.Worksheets.Add();

            // Copy the first sheet of the first book into second book.
            excelWorkbook4.Worksheets[1].Copy(excelWorkbook3.Worksheets["Copy"]);

            // Save the file.
            excelWorkbook4.Save(dataDir + @"CopyWorksheetsBetweenWorkbooks_out_.xlsx");
            // ExEnd:CopyWorksheetsBetweenWorkbooks

            // ExStart:MoveWorksheetsBetweenWorkbooks
            //Open a file into the first book.
            Workbook excelWorkbook5 = new Workbook(dataDir + @"FirstWorkbook.xlsx");

            //Create another Workbook. Open a file into the Second book.
            Workbook excelWorkbook6 = new Workbook(dataDir + @"SecondWorkbook.xlsx");

            //Add New Worksheet
            excelWorkbook6.Worksheets.Add();

            //Copy the sheet from first book into second book.
            excelWorkbook6.Worksheets[2].Copy(excelWorkbook5.Worksheets[2]);

            //Remove the copied worksheet from first workbook
            excelWorkbook5.Worksheets.RemoveAt(2);

            //Save the file.
            excelWorkbook5.Save(dataDir + @"FirstWorkbookWithMove_out_.xlsx");

            //Save the file.
            excelWorkbook6.Save(dataDir + @"SecondWorkbookWithMove_out_.xlsx");
            // ExEnd:MoveWorksheetsBetweenWorkbooks
        }
    }
}
