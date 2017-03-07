using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.RowsColumns
{
    public class ConvertTextToColumns
    {
        public static void Run()
        {
            // ExStart:ConvertTextToColumns
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Create a workbook.
            Workbook wb = new Workbook();

            //Access first worksheet.
            Worksheet ws = wb.Worksheets[0];

            //Add people name in column A. Fast name and Last name are separated by space.
            ws.Cells["A1"].PutValue("John Teal");
            ws.Cells["A2"].PutValue("Peter Graham");
            ws.Cells["A3"].PutValue("Brady Cortez");
            ws.Cells["A4"].PutValue("Mack Nick");
            ws.Cells["A5"].PutValue("Hsu Lee");

            //Create text load options with space as separator.
            TxtLoadOptions opts = new TxtLoadOptions();
            opts.Separator = ' ';

            //Split the column A into two columns using TextToColumns() method.
            //Now column A will have first name and column B will have second name.
            ws.Cells.TextToColumns(0, 0, 5, opts);

            //Save the workbook in xlsx format.
            wb.Save(dataDir + "outputTextToColumns.xlsx");

            // ExEnd:ConvertTextToColumns
        }
    }
}