//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace ReadingCSVMultipleEncodingsExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            string filePath = dataDir + "MultiEncoded.csv";

            //Set Multi Encoded Property to True
            TxtLoadOptions options = new TxtLoadOptions();
            options.IsMultiEncoded = true;

            //Load the CSV file into Workbook
            Workbook workbook = new Workbook(filePath, options);

            //Save it in XLSX format
            workbook.Save( filePath + ".out.xlsx", SaveFormat.Xlsx);
        }
    }
}