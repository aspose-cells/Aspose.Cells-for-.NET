using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.KnowledgeBase.Benchmarking
{
    public class Creating50XLSFiles
    {
        // ExStart:1
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            try
            {
                CreateAsposeCellsFiles(dataDir + "AsposeSample");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void CreateAsposeCellsFiles(string filename)
        {
            DateTime start = DateTime.Now;
            for (int wkb = 0; wkb < 50; wkb++)
            {
                Workbook workbook = new Workbook();
                workbook.Worksheets.RemoveAt(0);
                for (int i = 0; i < 5; i++)
                {
                    Worksheet ws = workbook.Worksheets[workbook.Worksheets.Add()];
                    ws.Name = i.ToString();
                    for (int row = 0; row < 150; row++)
                    {
                        for (int col = 0; col < 50; col++)
                        {
                            ws.Cells[row, col].PutValue("row" + row.ToString() + " col" + col.ToString());
                        }
                    }
                }
                workbook.Save(filename + wkb.ToString() + "_out.xls");
            }
            DateTime end = DateTime.Now;
            TimeSpan time = end - start;
            Console.WriteLine("50 File(s) Created! \n" + "Time consumed (Seconds): " + time.TotalSeconds.ToString());
        }
        // ExEnd:1
    }
}
