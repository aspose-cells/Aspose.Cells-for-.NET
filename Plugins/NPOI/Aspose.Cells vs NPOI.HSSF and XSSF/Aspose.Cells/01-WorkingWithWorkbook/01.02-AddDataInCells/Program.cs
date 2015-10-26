using System;
using System.Collections.Generic;
using System.Text;
using Aspose.Cells;

namespace AddDataInCells
{
    class Program
    {
        static void Main(string[] args)
        {
            //----------------------------------------------------
            //  NPOI
            //----------------------------------------------------    
            //IWorkbook workbook = new XSSFWorkbook();
            //ISheet sheet1 = workbook.CreateSheet("Sheet1");
            //sheet1.CreateRow(0).CreateCell(0).SetCellValue("This is a Sample");
            //int x = 1;
            //for (int i = 1; i <= 15; i++)
            //{
            //    IRow row = sheet1.CreateRow(i);
            //    for (int j = 0; j < 15; j++)
            //    {
            //        row.CreateCell(j).SetCellValue(x++);
            //    }
            //}
            //FileStream sw = File.Create("test.xlsx");
            //workbook.Write(sw);
            //sw.Close();

            //----------------------------------------------------
            //  Aspose.Cells
            //----------------------------------------------------
            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Accessing the added worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            int x = 1;
            for (int i = 1; i <= 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    worksheet.Cells[i, j].Value = x++;
                }
            }

            workbook.Save("test.xlsx");

        }
    }
}
