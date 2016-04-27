using System;
using Aspose.Cells;
using System.IO;

namespace AddCommentInCell_Aspose.Cells_
{
    class Program
    {
        static void Main(string[] args)
        { 
            // Check for license and apply if exists
            string licenseFile = AppDomain.CurrentDomain.BaseDirectory + "Aspose.Cells.lic";
            if (File.Exists(licenseFile))
            {
                // Apply Aspose.Words API License
                Aspose.Cells.License license = new Aspose.Cells.License();
                // Place license file in Bin/Debug/ Folder
                license.SetLicense("Aspose.Cells.lic");
            }

            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Adding a new worksheet to the Workbook object
            int sheetIndex = workbook.Worksheets.Add();

            //Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[sheetIndex];

            //Setting the name of the newly added worksheet
            worksheet.Name = "Adding Comment in Execl Cell";

            //Adding a comment to "F5" cell
            int commentIndex = worksheet.Comments.Add("F5");

            //Adding a string value to the cell
            worksheet.Cells["F5"].PutValue("Hello World");

            //Accessing the newly added comment
            Comment comment = worksheet.Comments[commentIndex];

            //Setting the comment note
            comment.Note = "Hello Aspose!";

            //Saving the Excel file
            workbook.Save("AddingCommentInCell.xls");
        }
    }
}
