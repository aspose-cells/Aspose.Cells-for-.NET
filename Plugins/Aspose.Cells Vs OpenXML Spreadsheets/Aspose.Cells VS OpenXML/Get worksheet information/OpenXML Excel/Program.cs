// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using DocumentFormat.OpenXml.Packaging;
using System;
using A = DocumentFormat.OpenXml.OpenXmlAttribute;
using E = DocumentFormat.OpenXml.OpenXmlElement;
using S = DocumentFormat.OpenXml.Spreadsheet.Sheets;

namespace Aspose.Plugins.AsposeVSOpenXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"..\..\..\..\Sample Files\";
            string FileName = FilePath + "Get worksheet information.xlsx";
            GetSheetInfo(FileName);
            Console.ReadKey();
        }
        public static void GetSheetInfo(string fileName)
        {
            // Open file as read-only.
            using (SpreadsheetDocument mySpreadsheet = SpreadsheetDocument.Open(fileName, false))
            {
                S sheets = mySpreadsheet.WorkbookPart.Workbook.Sheets;

                // For each sheet, display the sheet information.
                foreach (E sheet in sheets)
                {
                    foreach (A attr in sheet.GetAttributes())
                    {
                        Console.WriteLine("{0}: {1}", attr.LocalName, attr.Value);
                    }
                }
            }
        }
    }
}
