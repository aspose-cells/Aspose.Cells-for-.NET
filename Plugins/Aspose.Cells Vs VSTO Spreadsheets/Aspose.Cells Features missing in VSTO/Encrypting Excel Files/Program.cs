using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypting_Excel_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate a Workbook object.
            //Open an excel file.
            Workbook workbook = new Workbook(@"F:\test\Book1.xls");

            //Specify XOR encryption type.
            workbook.SetEncryptionOptions(EncryptionType.XOR, 40);

            //Specify Strong Encryption type (RC4,Microsoft Strong Cryptographic Provider).
            workbook.SetEncryptionOptions(EncryptionType.StrongCryptographicProvider, 128);

            //Password protect the file.
            workbook.Settings.Password = "1234";

            //Save the excel file.
            workbook.Save(@"F:\test\encryptedBook1.xls");
        }
    }
}
