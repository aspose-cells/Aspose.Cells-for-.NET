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
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            try
            {
                // Create a License object
                License license = new License();

                // Set the license of Aspose.Cells to avoid the evaluation limitations
                license.SetLicense(dataDir + "Aspose.Cells.lic");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Instantiate a Workbook object that represents Excel file.
            Workbook wb = new Workbook();

            // When you create a new workbook, a default "Sheet1" is added to the workbook.
            Worksheet sheet = wb.Worksheets[0];

            // Access the "A1" cell in the sheet.
            Cell cell = sheet.Cells["A1"];

            // Input the "Hello World!" text into the "A1" cell
            cell.PutValue("Hello World!");

            // Save the Excel file.
            wb.Save(dataDir + "MyBook_out.xlsx", SaveFormat.Excel97To2003);
            // ExEnd:1
        }
    }
}
