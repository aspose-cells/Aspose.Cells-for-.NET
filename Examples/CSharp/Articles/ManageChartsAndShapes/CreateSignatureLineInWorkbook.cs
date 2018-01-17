using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    public class CreateSignatureLineInWorkbook
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create workbook object
            Workbook workbook = new Workbook();

            // Insert picture of your choice
            int index = workbook.Worksheets[0].Pictures.Add(0, 0, sourceDir + "sampleCreateSignatureLineInWorkbook_Signature.jpg");

            // Access picture and add signature line inside it
            Picture pic = workbook.Worksheets[0].Pictures[index];

            // Create signature line object
            SignatureLine s = new SignatureLine();
            s.Signer = "John Doe";
            s.Title = "Development Lead";
            s.Email = "John.Doe@suppose.com";

            // Assign the signature line object to Picture.SignatureLine property
            pic.SignatureLine = s;

            // Save the workbook
            workbook.Save(outputDir + "outputCreateSignatureLineInWorkbook.xlsx");

            Console.WriteLine("CreateSignatureLineInWorkbook executed successfully.");
        }
    }
}
