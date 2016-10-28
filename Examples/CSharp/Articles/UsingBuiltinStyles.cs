using System;
using Aspose.Cells;
using Aspose.Cells.Metadata;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    class UsingBuiltinStyles
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string output1Path = dataDir + "Output.xlsx";
            string output2Path = dataDir + "Output.out.ods";

            Workbook workbook = new Workbook();
            Style style = workbook.CreateBuiltinStyle(BuiltinStyleType.Title);

            Cell cell = workbook.Worksheets[0].Cells["A1"];
            cell.PutValue("Aspose");
            cell.SetStyle(style);

            Worksheet worksheet = workbook.Worksheets[0];
            worksheet.AutoFitColumn(0);
            worksheet.AutoFitRow(0);

            workbook.Save(output1Path);
            Console.WriteLine("File saved {0}", output1Path);
            workbook.Save(output2Path);
            Console.WriteLine("File saved {0}", output1Path);
            // ExEnd:1
        }
    }
}
