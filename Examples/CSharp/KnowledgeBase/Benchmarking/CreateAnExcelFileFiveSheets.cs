using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.KnowledgeBase.Benchmarking
{
    public class CreateAnExcelFileFiveSheets
    {
        // ExStart:1
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            try
            {
                CreateAsposeCellsFile(dataDir + "ACellsSample_out.xls");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private static void CreateAsposeCellsFile(string filename)
        {
            DateTime start = DateTime.Now;
            Workbook workbook = new Workbook();
            workbook.Worksheets.RemoveAt(0);
            for (int i = 0; i < 5; i++)
            {
                Worksheet ws = workbook.Worksheets[workbook.Worksheets.Add()];
                ws.Name = i.ToString();
                for (int row = 0; row < 150; row++)
                {
                    for (int col = 0; col < 56; col++)
                    {
                        ws.Cells[row, col].PutValue("row" + row.ToString() + " col" + col.ToString());
                    }
                }
            }
            workbook.Save(filename);
            DateTime end = DateTime.Now;
            TimeSpan time = end - start;
            Console.WriteLine("File Created! \n" + "Time consumed (Seconds): " + time.TotalSeconds.ToString());
        }
        // ExEnd:1
    }
}
