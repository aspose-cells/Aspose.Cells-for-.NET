using Aspose.Cells.Rendering;
using Aspose.Cells.WebExtensions;
using System;

namespace Aspose.Cells.Examples.CSharp._Workbook
{
    public class AdjustCompressionLevel
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();
            string outDir = RunExamples.Get_OutputDirectory();

            Workbook workbook = new Workbook(sourceDir + "LargeSampleFile.xlsx");
            XlsbSaveOptions options = new XlsbSaveOptions();
            options.CompressionType = OoxmlCompressionType.Level1;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            workbook.Save(outDir + "LargeSampleFile_level_1_out.xlsb", options);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Level 1 Elapsed Time: " + elapsedMs);

            watch = System.Diagnostics.Stopwatch.StartNew();
            options.CompressionType = OoxmlCompressionType.Level6;
            workbook.Save(outDir + "LargeSampleFile_level_6_out.xlsb", options);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Level 6 Elapsed Time: " + elapsedMs);

            watch = System.Diagnostics.Stopwatch.StartNew();
            options.CompressionType = OoxmlCompressionType.Level9;
            workbook.Save(outDir + "LargeSampleFile_level_9_out.xlsb", options);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Level 9 Elapsed Time: " + elapsedMs);
            // ExEnd:1

            Console.WriteLine("AdjustCompressionLevel executed successfully.");
        }
    }
}
