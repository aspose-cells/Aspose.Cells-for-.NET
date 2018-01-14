using System;
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ExtractOLEObjects
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open the template file.
            Workbook workbook = new Workbook(sourceDir + "sampleExtractOLEObjects.xlsx");

            // Get the OleObject Collection in the first worksheet.
            Aspose.Cells.Drawing.OleObjectCollection oles = workbook.Worksheets[0].OleObjects;

            // Loop through all the oleobjects and extract each object in the worksheet.
            for (int i = 0; i < oles.Count; i++)
            {
                Aspose.Cells.Drawing.OleObject ole = oles[i];

                byte[] oleData = ole.ObjectData;

                // Specify the output filename.
                string fileName = outputDir + "outputExtractOLEObjects" + (i+1) + ".";
                
                // Specify each file format based on the oleobject format type.
                switch (ole.FileFormatType)
                {
                    case FileFormatType.Doc:
                        fileName += "doc";
                        break;
                    case FileFormatType.Docx:
                        fileName += "docx";
                        break;
                    case FileFormatType.Excel97To2003:
                        fileName += "xls";
                        break;
                    case FileFormatType.Xlsx:
                        fileName += "xlsx";

                        MemoryStream ms = new MemoryStream();
                        ms.Write(ole.ObjectData, 0, ole.ObjectData.Length);
                        Workbook oleBook = new Workbook(ms);
                        oleBook.Settings.IsHidden = false;

                        ms = new MemoryStream();
                        oleBook.Save(ms, SaveFormat.Xlsx);

                        ms.Position = 0;
                        byte[] bts = new byte[ms.Length];
                        ms.Read(bts, 0, (int)ms.Length);
                        oleData = bts;

                        break;
                    case FileFormatType.Ppt:
                        fileName += "ppt";
                        break;
                    case FileFormatType.Pdf:
                        fileName += "pdf";
                        break;
                    case FileFormatType.Unknown:
                        Guid g = new Guid(ole.ClassIdentifier);

                        if (g.ToString() == "b801ca65-a1fc-11d0-85ad-444553540000")
                        {
                            fileName += "pdf";
                        }
                        else
                        {
                            fileName += "jpg";
                        }                      
                        break;
                    default:
                        //........
                        break;
                }

                File.WriteAllBytes(fileName, oleData);
            }//for

            Console.WriteLine("ExtractOLEObjects executed successfully.");
        }
    }
}
