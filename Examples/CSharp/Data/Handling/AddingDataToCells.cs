using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Data.Handling
{
    public class AddingDataToCells
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Obtaining the reference of the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Adding a string value to the cell
            worksheet.Cells["A1"].PutValue("Hello World");

            // Adding a double value to the cell
            worksheet.Cells["A2"].PutValue(20.5);

            // Adding an integer  value to the cell
            worksheet.Cells["A3"].PutValue(15);

            // Adding a boolean value to the cell
            worksheet.Cells["A4"].PutValue(true);

            // Adding a date/time value to the cell
            worksheet.Cells["A5"].PutValue(DateTime.Now);

            // Setting the display format of the date
            Style style = worksheet.Cells["A5"].GetStyle();
            style.Number = 15;
            worksheet.Cells["A5"].SetStyle(style);

            // Saving the Excel file
            workbook.Save(dataDir + "output.out.xls");
            // ExEnd:1

        }
    }
}
