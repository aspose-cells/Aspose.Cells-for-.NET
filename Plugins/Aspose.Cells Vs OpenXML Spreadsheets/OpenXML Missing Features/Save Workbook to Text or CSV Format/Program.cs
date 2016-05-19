using Aspose.Cells;
using System;
using System.IO;

/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Cells for .NET API reference when the project is build. Please check https://docs.nuget.org/consume/nuget-faq for more information. If you do not wish to use NuGet, you can manually download Aspose.Cells for .NET API from http://www.aspose.com/downloads, install it and then add its reference to this project. For any issues, questions or suggestions please feel free to contact us using http://www.aspose.com/community/forums/default.aspx
*/

namespace Aspose.Plugins.AsposeVSOpenXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"..\..\..\Sample Files\";
            string FileName = FilePath + "Save Workbook to Text or CSV Format.xlsx";
            string destFileName = FilePath + "Save Workbook to Text or CSV Format.txt";
           
            //Load your source workbook
            Workbook workbook = new Workbook(FileName);

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
            File.WriteAllBytes(destFileName, workbookData);
        }
    }
}
