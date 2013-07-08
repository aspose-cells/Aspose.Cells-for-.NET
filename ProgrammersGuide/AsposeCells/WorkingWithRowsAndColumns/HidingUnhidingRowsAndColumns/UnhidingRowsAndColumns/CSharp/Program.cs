//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace UnhidingRowsAndColumns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(dataDir + "book1.xls", FileMode.Open);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            //Unhiding the 3rd row and setting its height to 13.5
            worksheet.Cells.UnhideRow(2, 13.5);

            //Unhiding the 2nd column and setting its width to 8.5
            worksheet.Cells.UnhideColumn(1, 8.5);

            //Saving the modified Excel file
            workbook.Save(dataDir + "output.xls");

            //Closing the file stream to free all resources
            fstream.Close();

        }
    }
}