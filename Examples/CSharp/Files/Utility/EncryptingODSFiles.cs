using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Files.Utility
{
    public class EncryptingODSFiles
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Encrypt an ods file
            //Encrypted ods file can only be opened in OpenOffice as Excel does not support encrypted ods files

        

            // Instantiate a Workbook object.
            // Open an ods file.
            Workbook workbook = new Workbook(dataDir + "Book1.ods");

            //Encryption options are not effective for ods files

            // Password protect the file.
            workbook.Settings.Password = "1234";

            // Save the excel file.
            workbook.Save(dataDir + "encryptedBook1.out.ods");

            //Decrypt ods file
            //Decrypted ods file can be opened both in Excel and OpenOffice          

            // Set original password
            OdsLoadOptions loadOptions = new OdsLoadOptions();
            loadOptions.Password = "1234";

            // Load the encrypted ods file with the appropriate load options
            Workbook encrypted = new Workbook(dataDir + "encryptedBook1.out.ods", loadOptions);

            // Unprotect the workbook
            encrypted.Unprotect("1234");

            // Set the password to null
            encrypted.Settings.Password = null;

            // Save the decrypted ods file
            encrypted.Save(dataDir + "DencryptedBook1.out.ods");

            // ExEnd:1
        }
    }
}
