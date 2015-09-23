using System;
using System.Collections.Generic;
using System.Text; using Aspose.Cells;

namespace _01._01_FindValueInCells
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook("../../data/test.xlsx");

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            //Finding the cell containing the specified formula
            Cells cells = worksheet.Cells;

            //Instantiate FindOptions
            FindOptions findOptions = new FindOptions();

            //Finding the cell containing a string value that starts with "Or"
            findOptions.LookAtType = LookAtType.StartWith;

            Cell cell = cells.Find("SH", null, findOptions);

            //Printing the name of the cell found after searching worksheet
            Console.WriteLine("Name of the cell containing String: " + cell.Name);
        }
    }
}
