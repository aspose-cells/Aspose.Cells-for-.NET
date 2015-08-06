//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Files.Utility
{
    public class EncryptingFiles
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiate a Workbook object.
            //Open an excel file.
            Workbook workbook = new Workbook(dataDir + "Book1.xls");

            //Specify XOR encryption type.
            workbook.SetEncryptionOptions(EncryptionType.XOR, 40);

            //Specify Strong Encryption type (RC4,Microsoft Strong Cryptographic Provider).
            workbook.SetEncryptionOptions(EncryptionType.StrongCryptographicProvider, 128);

            //Password protect the file.
            workbook.Settings.Password = "1234";

            //Save the excel file.
            workbook.Save(dataDir + "encryptedBook1.xls");
        }
    }
}