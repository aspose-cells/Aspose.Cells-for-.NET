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
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open a file into the first book.
            Workbook excelWorkbook1 = new Workbook(sourceDir + @"sampleCopyMoveWorksheets_FirstWorkbook.xlsx");

            // Copy the first sheet of the first book with in the workbook
            excelWorkbook1.Worksheets[2].Copy(excelWorkbook1.Worksheets["Copy"]);

            // Save the file.
            excelWorkbook1.Save(outputDir + @"outputCopyMoveWorksheets_CopyWorksheeets.xlsx");
            // ExEnd:CopyWorksheets

            // ExStart:MoveWorksheets
            // Open a file into the first book.
            Workbook excelWorkbook2 = new Workbook(sourceDir + @"sampleCopyMoveWorksheets_FirstWorkbook.xlsx");

            // Move the sheet
            excelWorkbook2.Worksheets["Move"].MoveTo(2);

            // Save the file.
            excelWorkbook2.Save(outputDir + @"outputCopyMoveWorksheets_MoveWorksheeets.xlsx");
            // ExEnd:MoveWorksheets

            // ExStart:CopyWorksheetsBetweenWorkbooks
            // Open a file into the first book.
            Workbook excelWorkbook3 = new Workbook(sourceDir + @"sampleCopyMoveWorksheets_FirstWorkbook.xlsx");

            // Open a file into the second book.
            Workbook excelWorkbook4 = new Workbook(sourceDir + @"sampleCopyMoveWorksheets_SecondWorkbook.xlsx");

            // Add new worksheet into second Workbook
            excelWorkbook4.Worksheets.Add();

            // Copy the first sheet of the first book into second book.
            excelWorkbook4.Worksheets[1].Copy(excelWorkbook3.Worksheets["Copy"]);

            // Save the file.
            excelWorkbook4.Save(outputDir + @"outputCopyMoveWorksheets_CopyWorksheetsBetweenWorkbooks.xlsx");
            // ExEnd:CopyWorksheetsBetweenWorkbooks

            // ExStart:MoveWorksheetsBetweenWorkbooks
            //Open a file into the first book.
            Workbook excelWorkbook5 = new Workbook(sourceDir + @"sampleCopyMoveWorksheets_FirstWorkbook.xlsx");

            //Create another Workbook. Open a file into the Second book.
            Workbook excelWorkbook6 = new Workbook(sourceDir + @"sampleCopyMoveWorksheets_SecondWorkbook.xlsx");

            //Add New Worksheet
            excelWorkbook6.Worksheets.Add();

            //Copy the sheet from first book into second book.
            excelWorkbook6.Worksheets[1].Copy(excelWorkbook5.Worksheets[1]);

            //Save the file.
            excelWorkbook6.Save(outputDir + @"outputCopyMoveWorksheets_MoveWorksheetsBetweenWorkbooks.xlsx");

            Console.WriteLine("CopyMoveWorksheets executed successfully.");
        }
    }
}
