using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.DigitalSignatures;
using System.Security.Cryptography.X509Certificates;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class AssignAndValidateDigitalSignatures
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // dsc is signature collection contains one or more signature needed to sign
            DigitalSignatureCollection dsc = new DigitalSignatureCollection();

            // Cert must contain private key, it can be contructed from cert file or windows certificate collection. aa is password of cert
            X509Certificate2 cert = new X509Certificate2(sourceDir + "sampleAssignAndValidateDigitalSignatures.pfx", "aa");
            DigitalSignature ds = new DigitalSignature(cert, "test for sign", DateTime.Now);
            dsc.Add(ds);
            Workbook wb = new Workbook();

            // wb.SetDigitalSignature signs all signatures in dsc
            wb.SetDigitalSignature(dsc);
            wb.Save(outputDir + @"outputAssignAndValidateDigitalSignatures.xlsx");

            // open the file
            wb = new Workbook(outputDir + @"outputAssignAndValidateDigitalSignatures.xlsx");
            System.Console.WriteLine(wb.IsDigitallySigned);

            // Get digitalSignature collection from workbook
            dsc = wb.GetDigitalSignature();
            foreach (DigitalSignature dst in dsc)
            {
                System.Console.WriteLine(dst.Comments); //test for sign -OK
                System.Console.WriteLine(dst.SignTime); //11/25/2010 1:22:01 PM -OK
                System.Console.WriteLine(dst.IsValid); //True -OK
            }

            Console.WriteLine("AssignAndValidateDigitalSignatures executed successfully.");
        }
    }
}
