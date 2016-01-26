using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.Data.Handling.Find
{
    public class FindingCellsWithStringOrNumber
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiate the workbook object
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            //Get Cells collection
            Cells cells = workbook.Worksheets[0].Cells;

            FindOptions opts = new FindOptions();
            opts.LookInType = LookInType.Values;
            opts.LookAtType = LookAtType.EntireContent;

            //Find the cell with the input integer or double
            Cell cell1 = cells.Find(205, null, opts);

            if (cell1 != null)
            {
                Console.WriteLine("Name of the cell containing the value: " + cell1.Name);
            }
            else
            {
                Console.WriteLine("Record not found ");
            }

            //Find the cell with the input string
            Aspose.Cells.Cell cell2 = cells.Find("Items A", null, opts);

            if (cell2 != null)
            {
                Console.WriteLine("Name of the cell containing the value: " + cell2.Name);
            }
            else
            {
                Console.WriteLine("Record not found ");
            }

            //Find the cell containing with the input string
            opts.LookAtType = LookAtType.Contains;
            Cell cell3 = cells.Find("Data", null, opts);

            if (cell3 != null)
            {
                Console.WriteLine("Name of the cell containing the value: " + cell3.Name);
            }
            else
            {
                Console.WriteLine("Record not found ");
            }
        }
    }
}