using System;
using System.Collections.Generic;
using System.Text;
using Aspose.Cells;

namespace NewLineInCells
{
    class Program
    {
        static void Main(string[] args)
        {
            //----------------------------------------------------
            //  NPOI
            //----------------------------------------------------    
            //IWorkbook workbook = new XSSFWorkbook();
            //ISheet sheet = workbook.CreateSheet("Sheet1");

            //IRow row = sheet.CreateRow(2);
            //ICell cell = row.CreateCell(2);
            //cell.SetCellValue("Use \n with word wrap on to create a new line");

            ////to enable newlines you need set a cell styles with wrap=true
            //ICellStyle cs = workbook.CreateCellStyle();
            //cs.WrapText = true;
            //cell.CellStyle = cs;

            //FileStream sw = File.Create("test.xlsx");
            //workbook.Write(sw);
            //sw.Close();

            //----------------------------------------------------
            //  Aspose.Cells
            //----------------------------------------------------
            Workbook workbook = new Workbook(); // Creating a Workbook object
            Worksheet sheet = workbook.Worksheets[0];
            sheet.Cells[2,2].Value = "Use \n with word wrap on to create a new line";

            //Get Cell's Style
            Style style = sheet.Cells[2, 2].GetStyle();

            //Set Text Wrap property to true
            style.IsTextWrapped = true;

            //Set Cell's Style
            sheet.Cells[2, 2].SetStyle(style);

            workbook.Save("test.xlsx");
        }
    }
}
