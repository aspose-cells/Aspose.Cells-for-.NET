using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Slicers
{
    class ExportSlicerToPDF
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // ExStart:1
            Workbook workbook = new Workbook(sourceDir + "SampleSlicerChart.xlsx");
            workbook.Save(outputDir + "SampleSlicerChart.pdf", SaveFormat.Pdf);
            // ExEnd:1

            Console.WriteLine("ExportSlicerToPDF executed successfully.");
        }

    }
}
