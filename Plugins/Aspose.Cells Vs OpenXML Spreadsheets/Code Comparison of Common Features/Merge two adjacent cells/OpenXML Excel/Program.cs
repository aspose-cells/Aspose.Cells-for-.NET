// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;

namespace OpenXML_Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            string docName = "Merge two adjacent cells.xlsx";
            string sheetName = "Sheet1";
            string cell1Name = "A2";
            string cell2Name = "B2";
            MergeTwoCells(docName, sheetName, cell1Name, cell2Name);
        }
        // Given a document name, a worksheet name, and the names of two adjacent cells, merges the two cells.
        // When two cells are merged, only the content from one cell is preserved:
        // the upper-left cell for left-to-right languages or the upper-right cell for right-to-left languages.
        private static void MergeTwoCells(string docName, string sheetName, string cell1Name, string cell2Name)
        {
            // Open the document for editing.
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(docName, true))
            {
                Worksheet worksheet = GetWorksheet(document, sheetName);
                if (worksheet == null || string.IsNullOrEmpty(cell1Name) || string.IsNullOrEmpty(cell2Name))
                {
                    return;
                }

                // Verify if the specified cells exist, and if they do not exist, create them.
                CreateSpreadsheetCellIfNotExist(worksheet, cell1Name);
                CreateSpreadsheetCellIfNotExist(worksheet, cell2Name);

                MergeCells mergeCells;
                if (worksheet.Elements<MergeCells>().Count() > 0)
                {
                    mergeCells = worksheet.Elements<MergeCells>().First();
                }
                else
                {
                    mergeCells = new MergeCells();

                    // Insert a MergeCells object into the specified position.
                    if (worksheet.Elements<CustomSheetView>().Count() > 0)
                    {
                        worksheet.InsertAfter(mergeCells, worksheet.Elements<CustomSheetView>().First());
                    }
                    else if (worksheet.Elements<DataConsolidate>().Count() > 0)
                    {
                        worksheet.InsertAfter(mergeCells, worksheet.Elements<DataConsolidate>().First());
                    }
                    else if (worksheet.Elements<SortState>().Count() > 0)
                    {
                        worksheet.InsertAfter(mergeCells, worksheet.Elements<SortState>().First());
                    }
                    else if (worksheet.Elements<AutoFilter>().Count() > 0)
                    {
                        worksheet.InsertAfter(mergeCells, worksheet.Elements<AutoFilter>().First());
                    }
                    else if (worksheet.Elements<Scenarios>().Count() > 0)
                    {
                        worksheet.InsertAfter(mergeCells, worksheet.Elements<Scenarios>().First());
                    }
                    else if (worksheet.Elements<ProtectedRanges>().Count() > 0)
                    {
                        worksheet.InsertAfter(mergeCells, worksheet.Elements<ProtectedRanges>().First());
                    }
                    else if (worksheet.Elements<SheetProtection>().Count() > 0)
                    {
                        worksheet.InsertAfter(mergeCells, worksheet.Elements<SheetProtection>().First());
                    }
                    else if (worksheet.Elements<SheetCalculationProperties>().Count() > 0)
                    {
                        worksheet.InsertAfter(mergeCells, worksheet.Elements<SheetCalculationProperties>().First());
                    }
                    else
                    {
                        worksheet.InsertAfter(mergeCells, worksheet.Elements<SheetData>().First());
                    }
                }

                // Create the merged cell and append it to the MergeCells collection.
                MergeCell mergeCell = new MergeCell() { Reference = new StringValue(cell1Name + ":" + cell2Name) };
                mergeCells.Append(mergeCell);

                worksheet.Save();
            }
        }
        // Given a Worksheet and a cell name, verifies that the specified cell exists.
        // If it does not exist, creates a new cell. 
        private static void CreateSpreadsheetCellIfNotExist(Worksheet worksheet, string cellName)
        {
            string columnName = GetColumnName(cellName);
            uint rowIndex = GetRowIndex(cellName);

            IEnumerable<Row> rows = worksheet.Descendants<Row>().Where(r => r.RowIndex.Value == rowIndex);

            // If the Worksheet does not contain the specified row, create the specified row.
            // Create the specified cell in that row, and insert the row into the Worksheet.
            if (rows.Count() == 0)
            {
                Row row = new Row() { RowIndex = new UInt32Value(rowIndex) };
                Cell cell = new Cell() { CellReference = new StringValue(cellName) };
                row.Append(cell);
                worksheet.Descendants<SheetData>().First().Append(row);
                worksheet.Save();
            }
            else
            {
                Row row = rows.First();

                IEnumerable<Cell> cells = row.Elements<Cell>().Where(c => c.CellReference.Value == cellName);

                // If the row does not contain the specified cell, create the specified cell.
                if (cells.Count() == 0)
                {
                    Cell cell = new Cell() { CellReference = new StringValue(cellName) };
                    row.Append(cell);
                    worksheet.Save();
                }
            }
        }

        // Given a SpreadsheetDocument and a worksheet name, get the specified worksheet.
        private static Worksheet GetWorksheet(SpreadsheetDocument document, string worksheetName)
{
    IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook.Descendants<Sheet>().Where(s => s.Name == worksheetName);
    WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(sheets.First().Id);
    if (sheets.Count() == 0)
        return null;
    else
        return worksheetPart.Worksheet;
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
