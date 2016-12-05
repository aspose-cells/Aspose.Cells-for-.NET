using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.KnowledgeBase.Benchmarking
{
    public class CreateAnExcelFileSingleWorksheet
    {
        // ExStart:1
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            try
            {
                CreateAsposeCellsFile(dataDir + "CellsSample_out.xls");
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
            Worksheet ws = workbook.Worksheets[0];
            for (int row = 0; row < 10000; row++)
            {
                for (int col = 0; col < 30; col++)
                {
                    ws.Cells[row, col].PutValue(row.ToString() + "," + col.ToString());
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
