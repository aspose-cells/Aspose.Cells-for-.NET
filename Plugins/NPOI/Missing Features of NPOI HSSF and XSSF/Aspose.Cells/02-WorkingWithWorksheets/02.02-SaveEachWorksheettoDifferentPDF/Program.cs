using System;
using System.Collections.Generic;
using System.Text; using Aspose.Cells;

namespace _02._02_SaveEachWorksheettoDifferentPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate a new workbook and open the Excel
            //File from its location
            Workbook workbook = new Workbook("../../data/test.xlsx");

            //Get the count of the worksheets in the workbook
            int sheetCount = workbook.Worksheets.Count;

            //Make all sheets invisible except first worksheet
            for (int i = 1; i < workbook.Worksheets.Count; i++)
            {
                workbook.Worksheets[i].IsVisible = false;
            }

            //Take Pdfs of each sheet
            for (int j = 0; j < workbook.Worksheets.Count; j++)
            {
                Worksheet ws = workbook.Worksheets[j];
                workbook.Save(ws.Name + ".pdf");

                if (j < workbook.Worksheets.Count - 1)
                {
                    workbook.Worksheets[j + 1].IsVisible = true;
                    workbook.Worksheets[j].IsVisible =false;
                }
            }
        }
    }
}
