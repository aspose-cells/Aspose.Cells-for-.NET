using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;

namespace Aspose.Plugins.AsposeVSOpenXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"..\..\..\..\Sample Files\";
            string FileName = FilePath + "Retrieve a dictionary of all named ranges.xlsx";
            Dictionary<String, String> ranges = GetDefinedNames(FileName);
        }
        public static Dictionary<String, String> GetDefinedNames(String fileName)
        {
            // Given a workbook name, return a dictionary of defined names.
            // The pairs include the range name and a string representing the range.
            var returnValue = new Dictionary<String, String>();

            // Open the spreadsheet document for read-only access.
            using (SpreadsheetDocument document =
                SpreadsheetDocument.Open(fileName, false))
            {
                // Retrieve a reference to the workbook part.
                var wbPart = document.WorkbookPart;

                // Retrieve a reference to the defined names collection.
                DefinedNames definedNames = wbPart.Workbook.DefinedNames;

                // If there are defined names, add them to the dictionary.
                if (definedNames != null)
                {
                    foreach (DefinedName dn in definedNames)
                        returnValue.Add(dn.Name.Value, dn.Text);
                }
            }
            return returnValue;
        }
    }
}
