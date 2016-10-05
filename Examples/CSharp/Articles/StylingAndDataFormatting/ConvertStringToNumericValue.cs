using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.StylingAndDataFormatting
{
    public class ConvertStringToNumericValue
    {
        public static void Run()
        {
            // ExStart:ConvertTextNumericDatatoNumber
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiate workbook object with an Excel file
            Workbook workbook = new Workbook(dataDir + "SampleBook.xlsx");

            for (int i = 0; i < workbook.Worksheets.Count; i++)
            {
                workbook.Worksheets[i].Cells.ConvertStringToNumericValue();
            }

            workbook.Save(dataDir + "output_out_.xlsx");
            // ExEnd:ConvertTextNumericDatatoNumber
        }
    }
}
