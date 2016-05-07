using System;
using System.IO;
using Aspose.Cells;


namespace SplitCellsInExcel
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
            //Set the active cell
            workbook.Worksheets[0].ActiveCell = "A10";
            //Split the worksheet window
            workbook.Worksheets[0].Split();
            workbook.Save("output-Split.xls");

        }
    }
}
