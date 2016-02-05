using System.IO;
using System;
using System.Collections.Generic;

using System.Text;
using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class UsingLightCellsAPI
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            
            //Specify your desired matrix
            int rowsCount = 10000;
            int colsCount = 30;

            var workbook = new Workbook();
            var ooxmlSaveOptions = new OoxmlSaveOptions();

            ooxmlSaveOptions.LightCellsDataProvider = new TestDataProvider(workbook, rowsCount, colsCount);

            workbook.Save(dataDir+ "output.out.xlsx", ooxmlSaveOptions);
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
}
            


