using System;

namespace Aspose.Cells.Examples.CSharp.Worksheets
{
    class GetCellValidationInODS
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Load source Excel file
            Workbook workbook = new Workbook(sourceDir + "SampleBook1.ods");

            //Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            Cell cell = worksheet.Cells["A9"];

            if (cell.GetValidation() != null)
            {
                Console.WriteLine(cell.GetValidation().Type);
            }
            // ExEnd:1

            Console.WriteLine("GetCellValidationInODS executed successfully.");
        }
    }
}
