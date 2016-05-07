using System;
using System.IO;
using Aspose.Cells;

namespace Hiding_Rows_and_Columns
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

            worksheet.Cells["A1"].PutValue("1");
            worksheet.Cells["A2"].PutValue("2");
            worksheet.Cells["B1"].PutValue(11);
            //Hiding the 1st row of the worksheet
            worksheet.Cells.HideRow(0);
            //Hiding the 1st column of the worksheet
            worksheet.Cells.HideColumn(0);
            //Saving the modified Excel file
            workbook.Save("Output-HideRowsandColumns.xls");

        }
    }
}
