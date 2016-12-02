using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.KnowledgeBase.ComparingVSTOWithAspose
{
    public class UsingAsposeCells
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            DateTime start = DateTime.Now;
            string myPath = dataDir + @"TempBook.xls";
            Workbook workbook = new Workbook(myPath);
            Worksheet ws = workbook.Worksheets[0];

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    ws.Cells[i, j].PutValue("Row " + (i + 1).ToString() + " " + "Col " + (j + 1).ToString());
                }
            }

            workbook.Save(dataDir + @"TempBook1.xls");
            DateTime end = DateTime.Now;
            TimeSpan time = end - start;
            Console.WriteLine("File Created! " + "Time consumed (Seconds): " + time.TotalSeconds.ToString());
            // ExEnd:1
        }
    }
}
