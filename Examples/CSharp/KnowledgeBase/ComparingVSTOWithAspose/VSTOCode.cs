using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace Aspose.Cells.Examples.CSharp.KnowledgeBase.ComparingVSTOWithAspose
{
    public class VSTOCode
    {
        public static void Run()
        {
            try
            {
                // ExStart:1
                // The path to the documents directory.
                string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

                DateTime start = DateTime.Now;
                Excel.Application excelApp = new Application();
                string myPath = dataDir + @"TempBook.xls";
                excelApp.Workbooks.Open(myPath, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value,
                Missing.Value, Missing.Value,
                Missing.Value, Missing.Value,
                Missing.Value, Missing.Value,
                Missing.Value, Missing.Value,
                Missing.Value, Missing.Value);

                for (int i = 1; i <= 1000; i++)
                {
                    for (int j = 1; j <= 20; j++)
                    {
                        excelApp.Cells[i, j] = "Row " + i.ToString() + " " + "Col " + j.ToString();
                    }
                }

                excelApp.Save(dataDir + @"TempBook1_out.xls");
                excelApp.Quit();
                DateTime end = DateTime.Now;
                TimeSpan time = end - start;
                Console.WriteLine("File Created! " + "Time consumed (Seconds): " + time.TotalSeconds.ToString());
                // ExEnd:1
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
