using System.IO;

using Aspose.Cells;
using System;
using System.Threading;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ReadingCellValuesInMultipleThreadsSimultaneously
    {
        public static void Main()
        {
        }

        public static Workbook testWorkbook;

        public static void ThreadLoop()
        {
            Random random = new Random();
            while (Thread.CurrentThread.IsAlive)
            {
                try
                {
                    int row = random.Next(0, 10000);
                    int col = random.Next(0, 100);
                    string s = testWorkbook.Worksheets[0].Cells[row, col].StringValue;
                    if (s != "R" + row + "C" + col)
                    {
                        Console.WriteLine("This message will show up when cells read values are incorrect.");
                    }
                }
                catch { }
            }
        }

        public static void TestMultiThreadingRead()
        {
            testWorkbook = new Workbook();
            testWorkbook.Worksheets.Clear();
            testWorkbook.Worksheets.Add("Sheet1");

            for (var row = 0; row < 10000; row++)
                for (var col = 0; col < 100; col++)
                    testWorkbook.Worksheets[0].Cells[row, col].Value = "R" + row + "C" + col;

            //Uncomment this line to remove the pop-up message on console
            //testWorkbook.Worksheets[0].Cells.MultiThreadReading = true;

            Thread myThread1;
            myThread1 = new Thread(new ThreadStart(ThreadLoop));
            myThread1.Start();

            Thread myThread2;
            myThread2 = new Thread(new ThreadStart(ThreadLoop));
            myThread2.Start();

            System.Threading.Thread.Sleep(5 * 1000);
            myThread1.Abort();
            myThread2.Abort();

            Console.WriteLine("ReadingCellValuesInMultipleThreadsSimultaneously executed successfully.");
        }
    }
}
