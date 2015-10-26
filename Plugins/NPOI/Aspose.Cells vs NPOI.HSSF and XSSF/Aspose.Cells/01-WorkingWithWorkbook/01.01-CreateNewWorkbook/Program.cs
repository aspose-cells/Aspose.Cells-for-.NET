using System;
using System.Collections.Generic;
using System.Text;
using Aspose.Cells;

namespace CreateNewWorkbook
{
    class Program
    {
        static void Main(string[] args)
        {
            //----------------------------------------------------
            //  NPOI
            //----------------------------------------------------         
            //IWorkbook workbook = new XSSFWorkbook();
            //workbook.CreateSheet("Sheet A1");
            //workbook.CreateSheet("Sheet A2");
            //workbook.CreateSheet("Sheet A3");

            //FileStream sw = File.Create("test.xlsx");
            //workbook.Write(sw);
            //sw.Close();

            //----------------------------------------------------
            //  Aspose.Cells
            //----------------------------------------------------
            Workbook workbook = new Workbook(); // Creating a Workbook object
            workbook.Worksheets.Add("Sheet A1");
            workbook.Worksheets.Add("Sheet A2");
            workbook.Worksheets.Add("Sheet A3");
            workbook.Save("test.xlsx", SaveFormat.Xlsx); //Workbooks can be saved in many formats

        }
    }
}
