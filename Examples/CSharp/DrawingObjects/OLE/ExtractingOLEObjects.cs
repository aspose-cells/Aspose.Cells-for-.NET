using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.DrawingObjects.OLE
{
    public class ExtractingOLEObjects
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Open the template file.
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            // Get the OleObject Collection in the first worksheet.
            Aspose.Cells.Drawing.OleObjectCollection oles = workbook.Worksheets[0].OleObjects;

            // Loop through all the oleobjects and extract each object.
            // In the worksheet.
            for (int i = 0; i < oles.Count; i++)
            {
                Aspose.Cells.Drawing.OleObject ole = oles[i];

                // Specify the output filename.
                string fileName = dataDir + "ole_" + i + ".";

                // Specify each file format based on the oleobject format type.
                switch (ole.FileFormatType)
                {
                    case FileFormatType.Doc:
                        fileName += "doc";
                        break;
                    case FileFormatType.Xlsx:
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
                    ms.Write(ole.ObjectData, 0, ole.ObjectData.Length);
                    Workbook oleBook = new Workbook(ms);
                    oleBook.Settings.IsHidden = false;
                    oleBook.Save(dataDir + "Excel_File" + i + ".out.xlsx");
                }

                // Create the files based on the oleobject format types.
                else
                {
                    FileStream fs = File.Create(fileName);
                    fs.Write(ole.ObjectData, 0, ole.ObjectData.Length);
                    fs.Close();
                    // ExEnd:1
                }

            }

        }
    }
}
