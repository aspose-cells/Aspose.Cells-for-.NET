using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Tables
{
    public class ConvertTableToOds
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open an existing file that contains a table/list object in it
            Workbook wb = new Workbook(sourceDir + "SampleTable.xlsx");

            // Save the file
            wb.Save(outputDir + "ConvertTableToOds_out.ods");
            // ExEnd:1

            Console.WriteLine("ConvertTableToOds executed successfully.");
        }
    }
}
