using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Introduction
{
    public class FirstApplication
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiate a Workbook object that represents Excel file.
            Workbook wb = new Workbook();

            // When you create a new workbook, a default "Sheet1" is added to the workbook.
            Worksheet sheet = wb.Worksheets[0];

            // Access the "A1" cell in the sheet.
            Cell cell = sheet.Cells["A1"];

            // Input the "Hello World!" text into the "A1" cell
            cell.PutValue("Hello World!");

            // Save the Excel file.
            wb.Save(outputDir + "outputFirstApplication.xlsx", SaveFormat.Xlsx);

            Console.WriteLine("FirstApplication executed successfully.\r\n");
        }
    }
}
