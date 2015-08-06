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
    public class Excel2PDFConversion
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiate the Workbook object
            //Open an Excel file
            Workbook workbook = new Workbook(dataDir + "Book1.xls");

            //Save the document in PDF format
            workbook.Save(dataDir + "outBook1.pdf", SaveFormat.Pdf);

            // Display result, so that user knows the processing has finished.
            System.Console.WriteLine("Conversion completed.");
        }
    }
}