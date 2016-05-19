// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Aspose.Plugins.AsposeVSOpenXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"..\..\..\..\Sample Files\";
            string FileName = FilePath + "Get a column heading.xlsx";
            
            string worksheetName = "Sheet1";
            string cellName = "B3";
            string s1 = GetColumnHeading(FileName, worksheetName, cellName);
        }
        // Given a document name, a worksheet name, and a cell name, gets the column of the cell and returns
        // the content of the first cell in that column.
        public static string GetColumnHeading(string docName, string worksheetName, string cellName)
        {
            // Open the document as read-only.
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(docName, false))
            {
                IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook.Descendants<Sheet>().Where(s => s.Name == worksheetName);
                if (sheets.Count() == 0)
                {
                    // The specified worksheet does not exist.
                    return null;
                }

                WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(sheets.First().Id);

                // Get the column name for the specified cell.
                string columnName = GetColumnName(cellName);

                // Get the cells in the specified column and order them by row.
                IEnumerable<Cell> cells = worksheetPart.Worksheet.Descendants<Cell>().Where(c => string.Compare(GetColumnName(c.CellReference.Value), columnName, true) == 0)
                    .OrderBy(r => GetRowIndex(r.CellReference));

                if (cells.Count() == 0)
                {
                    // The specified column does not exist.
                    return null;
                }

                // Get the first cell in the column.
                Cell headCell = cells.First();

                // If the content of the first cell is stored as a shared string, get the text of the first cell
                // from the SharedStringTablePart and return it. Otherwise, return the string value of the cell.
                if (headCell.DataType != null && headCell.DataType.Value == CellValues.SharedString)
                {
                    SharedStringTablePart shareStringPart = document.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
                    SharedStringItem[] items = shareStringPart.SharedStringTable.Elements<SharedStringItem>().ToArray();
                    return items[int.Parse(headCell.CellValue.Text)].InnerText;
                }
                else
                {
                    return headCell.CellValue.Text;
                }
            }
        }
        // Given a cell name, parses the specified cell to get the column name.
        private static string GetColumnName(string cellName)
        {
            // Create a regular expression to match the column name portion of the cell name.
            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellName);

            return match.Value;
        }

        // Given a cell name, parses the specified cell to get the row index.
        private static uint GetRowIndex(string cellName)
        {
            // Create a regular expression to match the row index portion the cell name.
            Regex regex = new Regex(@"\d+");
            Match match = regex.Match(cellName);

            return uint.Parse(match.Value);
        }
    }
}
