using System.IO;
using System;
using System.Diagnostics;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithCalculationEngine
{
    public class DecreaseCalculationTime
    {
        public static void Run()
        {
            // ExStart:1
            // Test calculation time after setting recursive true
            TestCalcTimeRecursive(true);

            // Test calculation time after setting recursive false
            TestCalcTimeRecursive(false);

            Console.WriteLine("DecreaseCalculationTime executed successfully.");

        }
        // ExStart:TestCalcTimeRecursive
        static void TestCalcTimeRecursive(bool rec)
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();
            
            // Load your sample workbook
            Workbook wb = new Workbook(sourceDir + "sampleDecreaseCalculationTime.xlsx");

            // Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            // Set the calculation option, set recursive true or false as per parameter
            CalculationOptions opts = new CalculationOptions();
            opts.Recursive = rec;

            // Start stop watch            
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Calculate cell A1 one million times
            for (int i = 0; i < 1000000; i++)
            {
                ws.Cells["A1"].Calculate(opts);
            }

            // Stop the watch
            sw.Stop();

            // Calculate elapsed time in seconds
            long second = 1000;
            long estimatedTime = sw.ElapsedMilliseconds / second;

            // Print the elapsed time in seconds
            Console.WriteLine("Recursive " + rec + ": " + estimatedTime + " seconds");

        }
        
    }
}
