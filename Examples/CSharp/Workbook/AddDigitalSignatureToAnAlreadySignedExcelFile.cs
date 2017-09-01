using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp._Workbook
{
    public class AddDigitalSignatureToAnAlreadySignedExcelFile
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Certificate file and its password
            string certFileName = sourceDir + "AsposeDemo.pfx";
            string password = "aspose";

            //Load the workbook which is already digitally signed to add new digital signature
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(sourceDir + "sampleDigitallySignedByCells.xlsx");

            //Create the digital signature collection
            Aspose.Cells.DigitalSignatures.DigitalSignatureCollection dsCollection = new Aspose.Cells.DigitalSignatures.DigitalSignatureCollection();

            //Create new certificate
            System.Security.Cryptography.X509Certificates.X509Certificate2 certificate = new System.Security.Cryptography.X509Certificates.X509Certificate2(certFileName, password);

            //Create new digital signature and add it in digital signature collection
            Aspose.Cells.DigitalSignatures.DigitalSignature signature = new Aspose.Cells.DigitalSignatures.DigitalSignature(certificate, "Aspose.Cells added new digital signature in existing digitally signed workbook.", DateTime.Now);
            dsCollection.Add(signature);

            //Add digital signature collection inside the workbook
            workbook.AddDigitalSignature(dsCollection);

            //Save the workbook and dispose it.
            workbook.Save(outputDir + "outputDigitallySignedByCells.xlsx");
            workbook.Dispose();

            Console.WriteLine("AddDigitalSignatureToAnAlreadySignedExcelFile executed successfully.\r\n");
        }
    }
}
