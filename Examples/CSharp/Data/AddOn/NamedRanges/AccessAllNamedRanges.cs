using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.Data.AddOn.NamedRanges
{
    public class AccessAllNamedRanges
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            //Getting all named ranges
            Range[] range = workbook.Worksheets.GetNamedRanges();

            if(range != null)
            Console.WriteLine("Total Number of Named Ranges: " + range.Length);

        }
    }
}