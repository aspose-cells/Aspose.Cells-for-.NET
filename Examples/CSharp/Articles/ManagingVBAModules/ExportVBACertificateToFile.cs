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
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Load your source excel file into workbook object
            Workbook workbook = new Workbook(sourceDir + "sampleExportVBACertificateToFile.xlsm");

            // Retrieve bytes data of Digital Certificate of VBA Project
            byte[] certBytes = workbook.VbaProject.CertRawData;

            // Save Certificate Data into FileStream
            File.WriteAllBytes(outputDir + "outputExportVBACertificateToFile_Certificate", certBytes);

            Console.WriteLine("ExportVBACertificateToFile executed successfully.");
        }
    }
}
