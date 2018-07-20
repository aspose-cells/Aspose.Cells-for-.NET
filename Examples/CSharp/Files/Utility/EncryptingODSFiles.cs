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

            //Encrypt an ODS file
            //Encrypted ODS file can only be opened in OpenOffice as Excel does not support encrypted ODS files

            //Initialize loading options
            LoadOptions loadOptions = new LoadOptions(LoadFormat.ODS);

            // Instantiate a Workbook object.
            // Open an ODS file.
            Workbook workbook = new Workbook(dataDir + "Book1.ods", loadOptions);

            //Encryption options are not effective for ODS files

            // Password protect the file.
            workbook.Settings.Password = "1234";

            // Save the excel file.
            workbook.Save(dataDir + "encryptedBook1.out.ods");

            //Decrypt ODS file
            //Decrypted ODS file can be opened both in Excel and OpenOffice          

            // Set original password
            loadOptions.Password = "1234";

            // Load the encrypted ODS file with the appropriate load options
            Workbook encrypted = new Workbook(dataDir + "encryptedBook1.out.ods", loadOptions);

            // Unprotect the workbook
            encrypted.Unprotect("1234");

            // Set the password to null
            encrypted.Settings.Password = null;

            // Save the decrypted ODS file
            encrypted.Save(dataDir + "DencryptedBook1.out.ods");

            // ExEnd:1
        }
    }
}
