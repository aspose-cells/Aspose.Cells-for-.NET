//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace LimitNumberOfPagesGeneratedExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");
            //Open an Excel file
            Workbook wb = new Workbook(dataDir+ "TestBook.xlsx");
            //Instantiate the PdfSaveOption
            PdfSaveOptions options = new PdfSaveOptions();

            //Print only Page 3 and Page 4 in the output PDF
            //Starting page index (0-based index)
            options.PageIndex = 3;
            //Number of pages to be printed
            options.PageCount = 2;

            //Save the PDF file
            wb.Save(dataDir+ "outPDF1.pdf", options);
            
            
        }
    }
}