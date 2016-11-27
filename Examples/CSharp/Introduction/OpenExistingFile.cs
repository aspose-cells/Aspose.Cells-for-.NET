using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Aspose.Cells.Examples.CSharp.Introduction
{
    public class OpenExistingFile
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
                license.SetLicense("Aspose.Cells.lic");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(dataDir + "Sample.xlsx", FileMode.Open);

            // Instantiate a Workbook object that represents the existing Excel file
            Workbook workbook = new Workbook(fstream);

            // Get the reference of "A1" cell from the cells collection of a worksheet
            Cell cell = workbook.Worksheets[0].Cells["A1"];

            // Put the "Hello World!" text into the "A1" cell
            cell.PutValue("Hello World!");

            // Save the Excel file
            workbook.Save(dataDir + "HelloWorld_out.xlsx");

            // Closing the file stream to free all resources
            fstream.Close();
            // ExEnd:1
        }
    }
}
