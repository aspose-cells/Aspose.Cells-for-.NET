using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingVBAModules
{
    public class ExportVBACertificateToFile
    {
        public static void Run()
        {
            // ExStart:ExportVBACertificateToFile
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load your source excel file into workbook object
            Workbook workbook = new Workbook(dataDir + "sampleVBAProjectSigned.xlsm");

            // Retrieve bytes data of Digital Certificate of VBA Project
            byte[] certBytes = workbook.VbaProject.CertRawData;

            // Save Certificate Data into FileStream
            File.WriteAllBytes(dataDir + "Cert_out_", certBytes);
            // ExEnd:ExportVBACertificateToFile
        }
    }
}
