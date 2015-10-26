using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace Aspose_Cells
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            //Specify the template Excel file path.
            string myPath = "Book1.xls";

            //Open the Excel file.
            workbook.Open(myPath);

            //Get the first sheet.
            Aspose.Cells.Worksheet objSheet = workbook.Worksheets["Sheet1"];

            findNow(objSheet, "test");

            workbook.Save(myPath);
        }

        private static void findNow(Worksheet objSheet, string textToFind)
        {
            //Get Cells collection 
            Cells cells = objSheet.Cells;

            //Instantiate FindOptions Object
            FindOptions findOptions = new FindOptions();

            //Create a Cells Area
            CellArea ca = new CellArea();
            ca.StartRow = 8;
            ca.StartColumn = 2;
            ca.EndRow = 17;
            ca.EndColumn = 13;

            //Set cells area for find options
            findOptions.SetRange(ca);

            //Set searching properties
            findOptions.SearchNext = true;

            findOptions.SeachOrderByRows = true;

            findOptions.LookInType = LookInType.Values;

            //Find the cell with 0 value
            Cell cell = cells.Find(textToFind, null, findOptions);

            Console.WriteLine(cell.StringValue);
        }
    }
}
