using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.Data.Data.Handling.AccessingCells
{
    public class RowAndColumnIndex
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiating a Workbook object
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            //Using the Sheet 1 in Workbook
            Worksheet worksheet = workbook.Worksheets[0];

            //Accessing a cell using its name
            Cell cell = worksheet.Cells[0,0];

            string value = cell.Value.ToString();

            Console.WriteLine(value);
            //ExEnd:1
            
        }
    }
}
