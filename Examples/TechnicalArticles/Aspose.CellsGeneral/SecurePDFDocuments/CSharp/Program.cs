//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace SecurePDFDocumentsExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");
            //Open an Excel file
            Workbook workbook = new Workbook(dataDir+ "input.xlsx");

            //Instantiate PDFSaveOptions to manage security attributes
            PdfSaveOptions saveOption = new PdfSaveOptions();

            saveOption.SecurityOptions = new Aspose.Cells.Rendering.PdfSecurity.PdfSecurityOptions();
            //Set the user password
            saveOption.SecurityOptions.UserPassword = "user";

            //Set the owner password
            saveOption.SecurityOptions.OwnerPassword = "owner";

            //Disable extracting content permission
            saveOption.SecurityOptions.ExtractContentPermission = false;

            //Disable print permission
            saveOption.SecurityOptions.PrintPermission = false;

            //Save the PDF document with encrypted settings
            workbook.Save(dataDir+ "securepdf_test.pdf", saveOption);
            
        }
    }
}