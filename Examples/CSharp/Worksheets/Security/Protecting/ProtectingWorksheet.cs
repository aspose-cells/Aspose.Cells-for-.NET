//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Worksheets.Security.Protecting
{
    public class ProtectingWorksheet
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(dataDir + "book1.xls", FileMode.Open);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook excel = new Workbook(fstream);

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = excel.Worksheets[0];

            //Protecting the worksheet with a password
            worksheet.Protect(ProtectionType.All, "aspose", null);

            //Saving the modified Excel file in default format
            excel.Save(dataDir + "output.xls", SaveFormat.Excel97To2003);

            //Closing the file stream to free all resources
            fstream.Close();

        }
    }
}