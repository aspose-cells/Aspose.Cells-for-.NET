using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using Aspose.Cells.DigitalSignatures;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingVBAModules
{
    public class DigitallySignVbaProjectWithCertificate
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object from excel file
            Workbook wb = new Workbook(dataDir + "Book1.xlsm");

            // Please use System.Security.Cryptography.X509Certificates namespace for X509Certificate2 class
            X509Certificate2 cert = new X509Certificate2(dataDir + "SampleCert.pfx", "1234");

            // Create a Digital Signature
            DigitalSignature ds = new DigitalSignature(cert, "Signing Digital Signature using Aspose.Cells", DateTime.Now);

            // Sign VBA Code Project with Digital Signature
            wb.VbaProject.Sign(ds);

            // Save the workbook
            wb.Save(dataDir + "DigitallySigned_out.xlsm");
            // ExEnd:1
        }
    }
}
