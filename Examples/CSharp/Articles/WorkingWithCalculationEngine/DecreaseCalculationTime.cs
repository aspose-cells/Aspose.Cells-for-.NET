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
            // ExEnd:1           
            
        }
        // ExStart:TestCalcTimeRecursive
        static void TestCalcTimeRecursive(bool rec)
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Load your sample workbook
            Workbook wb = new Workbook(dataDir + "sample.xlsx");

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
        // ExEnd:TestCalcTimeRecursive
    }
}
