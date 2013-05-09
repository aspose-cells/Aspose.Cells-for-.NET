//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace SavingFiles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Creating a Workbook object
            Workbook workbook = new Workbook();

            //Your Code goes here for any workbook related operations

            //Save in Excel 97 – 2003 format
            workbook.Save(dataDir + "book1.xls");

            //OR
            workbook.Save(dataDir + "book1.xls", new XlsSaveOptions(SaveFormat.Excel97To2003));

            //Save in Excel2007 xlsx format
            workbook.Save(dataDir + "book1.xlsx", SaveFormat.Xlsx);

            //Save in Excel2007 xlsb format
            workbook.Save(dataDir + "book1.xlsb", SaveFormat.Xlsb);

            //Save in ODS format
            workbook.Save(dataDir + "book1.ods", SaveFormat.ODS);

            //Save in Pdf format
            workbook.Save(dataDir + "book1.pdf", SaveFormat.Pdf);

            //Save in Html format
            workbook.Save(dataDir + "book1.html", SaveFormat.Html);

            //Save in SpreadsheetML format
            workbook.Save(dataDir + "book1.xml", SaveFormat.SpreadsheetML); 
        }
    }
}