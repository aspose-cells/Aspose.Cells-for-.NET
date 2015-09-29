// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using Aspose.Cells;

namespace Aspose_Cells
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = "Retrieve the values of cells.xlsx";

            // Retrieve the value in cell A1.
            string value = GetCellValue(fileName, "Sheet1", "A1");
            Console.WriteLine(value);
            Console.ReadKey();
        }
        // Retrieve the value of a cell, given a file name, sheet name, 
        // and address name.
        public static string GetCellValue(string fileName,
            string sheetName,
            string addressName)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook(fileName);

            //Obtaining the reference of the Active worksheet
            Worksheet worksheet = workbook.Worksheets.GetSheetByCodeName(sheetName);

            //retrieve value from cell
            string returnValue = worksheet.Cells[addressName].Value.ToString();

            return returnValue;

        }
    }
}
