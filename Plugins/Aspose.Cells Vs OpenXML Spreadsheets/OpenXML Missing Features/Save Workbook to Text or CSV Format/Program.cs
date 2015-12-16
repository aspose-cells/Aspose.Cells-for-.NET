using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace Save_Workbook_to_Text_or_CSV_Format
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "source.xlsx";

            //Load your source workbook
            Workbook workbook = new Workbook(filePath);

            //0-byte array
            byte[] workbookData = new byte[0];

            //Text save options. You can use any type of separator
            TxtSaveOptions opts = new TxtSaveOptions();
            opts.Separator = '\t';

            //Copy each worksheet data in text format inside workbook data array
            for (int idx = 0; idx < workbook.Worksheets.Count; idx++)
            {
                //Save the active worksheet into text format
                MemoryStream ms = new MemoryStream();
                workbook.Worksheets.ActiveSheetIndex = idx;
                workbook.Save(ms, opts);

                //Save the worksheet data into sheet data array
                ms.Position = 0;
                byte[] sheetData = ms.ToArray();

                //Combine this worksheet data into workbook data array
                byte[] combinedArray = new byte[workbookData.Length + sheetData.Length];
                Array.Copy(workbookData, 0, combinedArray, 0, workbookData.Length);
                Array.Copy(sheetData, 0, combinedArray, workbookData.Length, sheetData.Length);

                workbookData = combinedArray;
            }

            //Save entire workbook data into file
            File.WriteAllBytes(filePath + ".out.txt", workbookData);
        }
    }
}
