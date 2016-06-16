using System;
using System.IO;
using Aspose.Cells;
using System.Data;

namespace Aspose.Cells.Examples.CSharp.Data.Handling
{
    public class ExportColumnContainingNonStronglyTypedData
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            string filePath = dataDir + "Book1.xlsx";

            // Instantiating a Workbook object
            Workbook workbook = new Workbook(filePath);

            // Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            // Exporting the contents of 7 rows and 2 columns starting from 1st cell to DataTable
            DataTable dataTable = worksheet.Cells.ExportDataTableAsString(0, 0, 11, 2, true);

            foreach (DataRow r in dataTable.Rows)
            {
                foreach (DataColumn c in dataTable.Columns)
                {
                    string value = r.Field<string>(c);
                    Console.Write(value + "            ");
                }
                Console.WriteLine();
            }
            // ExEnd:1

            
        }
    }
}
