using System;
using System.IO;
using Aspose.Cells;

namespace AutoFitColumns
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

            Workbook workbook = new Workbook();
            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];
            //Auto-fitting the 1st column of the worksheet

            //Adding a string value to the cell
            worksheet.Cells["A1"].PutValue("This is a test input");
            //Adding a double value to the cell
            worksheet.Cells["B1"].PutValue(20.5);
            //Adding an integer  value to the cell
            worksheet.Cells["C1"].PutValue(15);
            //Adding a boolean value to the cell
            worksheet.Cells["D1"].PutValue(true);
            worksheet.AutoFitColumn(0);
            worksheet.AutoFitColumn(1);
            worksheet.AutoFitColumn(2);
            worksheet.AutoFitColumn(3);
            //Saving the modified Excel file in bin/debug folder
            workbook.Save("AutoFiltRowsandColumns.xls");
            //Closing the file stream to free all resources
        }
    }
}
