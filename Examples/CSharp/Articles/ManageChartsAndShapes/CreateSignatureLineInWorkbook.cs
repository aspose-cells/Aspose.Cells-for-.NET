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
            // ExStart:CreateSignatureLineInWorkbook
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object
            Workbook workbook = new Workbook();

            // Insert picture of your choice
            int index = workbook.Worksheets[0].Pictures.Add(0, 0, dataDir + "signature.jpg");

            // Access picture and add signature line inside it
            Picture pic = workbook.Worksheets[0].Pictures[index];

            // Create signature line object
            SignatureLine s = new SignatureLine();
            s.Signer = "Simon Zhao";
            s.Title = "Development Lead";
            s.Email = "Simon.Zhao@aspose.com";

            // Assign the signature line object to Picture.SignatureLine property
            pic.SignatureLine = s;

            // Save the workbook
            workbook.Save(dataDir + "output_out_.xlsx");
            // ExEnd:CreateSignatureLineInWorkbook
        }
    }
}
