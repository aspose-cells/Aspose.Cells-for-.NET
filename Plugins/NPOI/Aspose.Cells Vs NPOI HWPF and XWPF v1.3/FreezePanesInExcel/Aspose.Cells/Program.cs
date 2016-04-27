using System;
using System.IO;
using Aspose.Cells;

namespace FreezePanesInAspose.Cells
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

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            //Applying freeze panes settings The FreezePanes method takes the following parameters
            //Row, the row index of the cell that the freeze will start from.
            //Column, the column index of the cell that the freeze will start from.
            //Frozen rows, the number of visible rows in the top pane.
            //Frozen columns, the number of visible columns in the left pane

            worksheet.FreezePanes(2, 2, 2, 0);

            workbook.Save("output-FreezeFile-Aspose.Cells.xls");
          
        }
    }
}
