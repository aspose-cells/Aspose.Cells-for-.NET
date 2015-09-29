using System;
using System.Collections.Generic;
using System.Text;
using Aspose.Cells;
using System.Drawing;

namespace _02._01_SetWorksheetTabColor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate a new Workbook
            Workbook workbook = new Workbook("../../data/test.xlsx");

            //Get the first worksheet in the book
            Worksheet worksheet = workbook.Worksheets[0];

            //Set the tab color
            worksheet.TabColor = Color.Red;

            //Save the Excel file
            workbook.Save("AsposeColoredTab_Out.xls");
        }
    }
}
