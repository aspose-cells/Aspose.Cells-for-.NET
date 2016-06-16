using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Files.Utility
{
    public class EncryptingFiles
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiate a Workbook object.
            // Open an excel file.
            Workbook workbook = new Workbook(dataDir + "Book1.xls");

            // Specify XOR encryption type.
            workbook.SetEncryptionOptions(EncryptionType.XOR, 40);

            // Specify Strong Encryption type (RC4,Microsoft Strong Cryptographic Provider).
            workbook.SetEncryptionOptions(EncryptionType.StrongCryptographicProvider, 128);

            // Password protect the file.
            workbook.Settings.Password = "1234";

            // Save the excel file.
            workbook.Save(dataDir + "encryptedBook1.out.xls");
            // ExEnd:1
        }
    }
}
