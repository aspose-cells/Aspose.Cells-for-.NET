using Aspose.Cells.DigitalSignatures;
using System;
using System.IO;

namespace Aspose.Cells.Examples.CSharp._Workbook
{
    public class XAdESSignatureSupport
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            Workbook workbook = new Workbook(sourceDir + "sourceFile.xlsx");
            string password = "pfxPassword";
            string pfx = "pfxFile";

            DigitalSignature signature = new DigitalSignature(File.ReadAllBytes(pfx), password, "testXAdES", DateTime.Now);

            signature.XAdESType = XAdESType.XAdES;
            DigitalSignatureCollection dsCollection = new DigitalSignatureCollection();
            dsCollection.Add(signature);

            workbook.SetDigitalSignature(dsCollection);

            workbook.Save(outputDir + "XAdESSignatureSupport_out.xlsx");
            // ExEnd:1

            Console.WriteLine("XAdESSignatureSupport executed successfully.");
        }
    }
}
