using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.Files.Handling
{
    public class SaveWorkbookToTextCSVFormat
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Load your source workbook
            Workbook workbook = new Workbook(dataDir + "book1.xls");

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
            File.WriteAllBytes(dataDir + "out.txt", workbookData);

            
        }
    }
}