// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using DocumentFormat.OpenXml.Packaging;
using S = DocumentFormat.OpenXml.Spreadsheet.Sheets;
using E = DocumentFormat.OpenXml.OpenXmlElement;
using A = DocumentFormat.OpenXml.OpenXmlAttribute;

namespace OpenXML_Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            GetSheetInfo("Get worksheet information.xlsx");
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
