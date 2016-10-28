using System.IO;
using System;
using System.Collections.Generic;

using System.Text;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    // ExStart:WritingLargeExcelFile
    public class WriteUsingLightCellsAPI
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Specify your desired matrix
            int rowsCount = 10000;
            int colsCount = 30;

            var workbook = new Workbook();
            var ooxmlSaveOptions = new OoxmlSaveOptions();

            ooxmlSaveOptions.LightCellsDataProvider = new TestDataProvider(workbook, rowsCount, colsCount);

            workbook.Save(dataDir + "output.out.xlsx", ooxmlSaveOptions);
        }
    }

    class TestDataProvider : LightCellsDataProvider
    {
        private int _row = -1;
        private int _column = -1;

        private int maxRows;
        private int maxColumns;

        private Workbook _workbook;
        public TestDataProvider(Workbook workbook, int maxRows, int maxColumns)
        {
            this._workbook = workbook;
            this.maxRows = maxRows;
            this.maxColumns = maxColumns;
        }

        #region LightCellsDataProvider Members
        public bool IsGatherString()
        {
            return false;
        }

        public int NextCell()
        {
            ++_column;
            if (_column < this.maxColumns)
                return _column;
            else
            {
                _column = -1;
                return -1;
            }
        }
        public int NextRow()
        {
            ++_row;
            if (_row < this.maxRows)
            {
                _column = -1;
                return _row;
            }
            else
                return -1;
        }

        public void StartCell(Cell cell)
        {
            cell.PutValue(_row + _column);
            if (_row == 1)
            {
            }
            else
            {
                cell.Formula = "=Rand() + A2";
            }
        }

        public void StartRow(Row row)
        {
        }

        public bool StartSheet(int sheetIndex)
        {
            if (sheetIndex == 0)
            {
                return true;
            }
            else
                return false;
        }
        #endregion
    }
    // ExEnd:WritingLargeExcelFile

    // ExStart:ReadingLargeExcelFile
    public class ReadUsingLightCellsApi
    {
        public static void Run()
        {
            // ExStart:ExampleTitle
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            LoadOptions opts = new LoadOptions();
            LightCellsDataHandlerVisitCells v = new LightCellsDataHandlerVisitCells();
            opts.LightCellsDataHandler = v;
            Workbook wb = new Workbook(dataDir + "LargeBook1.xlsx", opts);
            int sheetCount = wb.Worksheets.Count;
            Console.WriteLine("Total sheets: " + sheetCount + ", cells: " + v.CellCount
                + ", strings: " + v.StringCount + ", formulas: " + v.FormulaCount);
        }
    }

    class LightCellsDataHandlerVisitCells : LightCellsDataHandler
    {
        private int cellCount;
        private int formulaCount;
        private int stringCount;

        internal LightCellsDataHandlerVisitCells()
        {
            cellCount = 0;
            formulaCount = 0;
            stringCount = 0;
        }

        public int CellCount
        {
            get { return cellCount; }
        }

        public int FormulaCount
        {
            get { return formulaCount; }
        }

        public int StringCount
        {
            get { return stringCount; }
        }

        public bool StartSheet(Worksheet sheet)
        {
            Console.WriteLine("Processing sheet[" + sheet.Name + "]");
            return true;
        }

        public bool StartRow(int rowIndex)
        {
            return true;
        }

        public bool ProcessRow(Row row)
        {
            return true;
        }

        public bool StartCell(int column)
        {
            return true;
        }

        public bool ProcessCell(Cell cell)
        {
            cellCount++;
            if (cell.IsFormula)
            {
                formulaCount++;
            }
            else if (cell.Type == CellValueType.IsString)
            {
                stringCount++;
            }
            return false;
        }
    }
    // ExEnd:ReadingLargeExcelFile
}
            


