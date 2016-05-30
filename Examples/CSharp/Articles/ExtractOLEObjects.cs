using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;

namespace CSharp.Articles
{
    public class ExtractOLEObjects
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiating a Workbook object
            // Open the template file.
            Workbook workbook = new Workbook(dataDir + "oleFile.xlsx");

            // Get the OleObject Collection in the first worksheet.
            Aspose.Cells.Drawing.OleObjectCollection oles = workbook.Worksheets[0].OleObjects;

            // Loop through all the oleobjects and extract each object in the worksheet.
            for (int i = 0; i < oles.Count; i++)
            {
                Aspose.Cells.Drawing.OleObject ole = oles[i];
                // Specify the output filename.
                string fileName = dataDir+ "outOle" + i + ".";
                // Specify each file format based on the oleobject format type.
                switch (ole.FileFormatType)
                {
                    case FileFormatType.Doc:
                        fileName += "doc";
                        break;
                    case FileFormatType.Excel97To2003:
                        fileName += "Xlsx";
                        break;
                    case FileFormatType.Ppt:
                        fileName += "Ppt";
                        break;
                    case FileFormatType.Pdf:
                        fileName += "Pdf";
                        break;
                    case FileFormatType.Unknown:
                        fileName += "Jpg";
                        break;
                    default:
                        //........
                        break;
                }
                // Save the oleobject as a new excel file if the object type is xls.
                if (ole.FileFormatType == FileFormatType.Xlsx)
                {
                    MemoryStream ms = new MemoryStream();
                    if (ole.ObjectData != null)
                    {
                        ms.Write(ole.ObjectData, 0, ole.ObjectData.Length);
                        Workbook oleBook = new Workbook(ms);
                        oleBook.Settings.IsHidden = false;
                        oleBook.Save(dataDir + "outOle" + i + ".out.xlsx");
                    }
                }

                // Create the files based on the oleobject format types.
                else
                {
                    if (ole.ObjectData != null)
                    {
                        FileStream fs = File.Create(fileName);
                        fs.Write(ole.ObjectData, 0, ole.ObjectData.Length);
                        fs.Close();
                    }
                }
                // ExEnd:1
            }
        }
    }
}
