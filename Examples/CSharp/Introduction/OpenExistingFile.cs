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
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(sourceDir + "sampleOpenExistingFile.xlsx", FileMode.Open);

            // Instantiate a Workbook object that represents the existing Excel file
            Workbook workbook = new Workbook(fstream);

            // Get the reference of "A1" cell from the cells collection of a worksheet
            Cell cell = workbook.Worksheets[0].Cells["A1"];

            // Put the "Hello World!" text into the "A1" cell
            cell.PutValue("Hello World!");

            // Save the Excel file
            workbook.Save(outputDir + "outputOpenExistingFile.xlsx");

            // Closing the file stream to free all resources
            fstream.Close();

            Console.WriteLine("OpenExistingFile executed successfully.\r\n");
        }
    }
}
