using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class SettingStrongEncryptionType
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open an excel file.
            Workbook workbook = new Workbook(sourceDir + "sampleSettingStrongEncryptionType.xlsx");

            // Specify Strong Encryption type (RC4,Microsoft Strong Cryptographic Provider).
            workbook.SetEncryptionOptions(EncryptionType.StrongCryptographicProvider, 128);

            // Password protect the file.
            workbook.Settings.Password = "1234";

            // Save the Excel file.
            workbook.Save(outputDir + "outputSettingStrongEncryptionType.xlsx");

            Console.WriteLine("SettingStrongEncryptionType executed successfully.");
        }
    }
}