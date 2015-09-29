using System;
using System.Collections.Generic;
using System.Text;
using Aspose.Cells;

namespace GettingCellContents
{
    class Program
    {
        static void Main(string[] args)
        {
            //----------------------------------------------------
            //  NPOI
            //----------------------------------------------------  
            //IWorkbook wb = new XSSFWorkbook("../../data/test.xlsx");
            //ISheet sheet1 = wb.GetSheetAt(0);

            //for (int index = 0; index <= sheet1.LastRowNum; index++)
            //{
            //    IRow row = sheet1.GetRow(index);

            //    foreach (ICell cell in row.Cells)
            //    {
            //        CellReference cellRef = new CellReference(row.RowNum, cell.ColumnIndex);
            //        Console.Write(cellRef.FormatAsString());
            //        Console.Write(" - ");

            //        switch (cell.CellType)
            //        {
            //            case CellType.String:
            //                Console.Write(cell.StringCellValue);
            //                break;
            //            case CellType.Numeric:
            //                if (DateUtil.IsCellDateFormatted(cell))
            //                    Console.Write(cell.DateCellValue);
            //                else
            //                    Console.Write(cell.NumericCellValue);
            //                break;
            //            case CellType.Boolean:
            //                Console.Write(cell.BooleanCellValue);
            //                break;
            //            case CellType.Formula:
            //                Console.Write(cell.CellFormula);
            //                break;
            //        }
            //        Console.WriteLine();
            //    }
            //}

            //----------------------------------------------------
            //  Aspose.Cells
            //----------------------------------------------------
            Workbook workbook = new Workbook("../../data/test.xlsx");
            Worksheet sheet1 = workbook.Worksheets[0];

            Cells cells = sheet1.Cells;
		    Range range = sheet1.Cells.MaxDisplayRange;
            int tcols = range.ColumnCount;
            int trows = range.RowCount;

            for (int i = 0 ; i < trows; i++)
            {
	            for (int j = 0 ; j < tcols ; j++)
	            {
		            if (cells[i, j].Type != CellValueType.IsNull)
		            {
                        Console.WriteLine(cells[i, j].Name + " - " + cells[i, j].Value);
		            }
	            }
            }
        }
    }
}
