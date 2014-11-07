//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace ResamplingAddedImagesExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");
            //Initialize a new Workbook
            //Open an Excel file
            Workbook workbook = new Workbook(dataDir+ "input.xlsx");

            //Instantiate the PdfSaveOptions
            PdfSaveOptions pdfSaveOptions = new PdfSaveOptions();
            //Set Image Resample properties
            pdfSaveOptions.SetImageResample(300, 70);

            //Save the PDF file
            workbook.Save(dataDir+ "OutputFile.pdf", pdfSaveOptions);
            
        }
    }
}