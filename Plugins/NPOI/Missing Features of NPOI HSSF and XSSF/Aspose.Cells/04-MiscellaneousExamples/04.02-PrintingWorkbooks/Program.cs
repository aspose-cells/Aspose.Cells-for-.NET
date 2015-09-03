using System;
using System.Collections.Generic;
using System.Text; using Aspose.Cells;
using Aspose.Cells.Rendering;

namespace _04._02_PrintingWorkbooks
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook("../../data/test.xlsx");

            //Create an object for ImageOptions
            ImageOrPrintOptions imgOptions = new ImageOrPrintOptions();

            //Get the first worksheet
            Worksheet sheet = workbook.Worksheets[0];

            //Create a SheetRender object with respect to your desired sheet
            SheetRender sr = new SheetRender(sheet, imgOptions);

            //Print the worksheet
            sr.ToPrinter("Samsung ML-1520 Series");
        }
    }
}
