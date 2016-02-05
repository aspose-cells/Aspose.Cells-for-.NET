using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.DrawingObjects.OLE
{
    public class ExtractingOLEObjects
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiating a Workbook object
            //Open the template file.
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            //Get the OleObject Collection in the first worksheet.
            Aspose.Cells.Drawing.OleObjectCollection oles = workbook.Worksheets[0].OleObjects;

            //Loop through all the oleobjects and extract each object.
            //in the worksheet.
            for (int i = 0; i < oles.Count; i++)
            {
                Aspose.Cells.Drawing.OleObject ole = oles[i];

                //Specify the output filename.
                string fileName = dataDir + "ole_" + i + ".";

                //Specify each file format based on the oleobject format type.
                switch (ole.FileType)
                {
                    case Aspose.Cells.Drawing.OleFileType.Doc:
                        fileName += "doc";
                        break;
                    case Aspose.Cells.Drawing.OleFileType.Xls:
                        fileName += "Xls";
                        break;
                    case Aspose.Cells.Drawing.OleFileType.Ppt:
                        fileName += "Ppt";
                        break;
                    case Aspose.Cells.Drawing.OleFileType.Pdf:
                        fileName += "Pdf";
                        break;
                    case Aspose.Cells.Drawing.OleFileType.Unknown:
                        fileName += "Jpg";
                        break;
                    default:
                        //........
                        break;
                }

                //Save the oleobject as a new excel file if the object type is xls.
                if (ole.FileType == Aspose.Cells.Drawing.OleFileType.Xls)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(ole.ObjectData, 0, ole.ObjectData.Length);
                    Workbook oleBook = new Workbook(ms);
                    oleBook.Settings.IsHidden = false;
                    oleBook.Save(dataDir + "Excel_File" + i + ".out.xls");
                }

                //Create the files based on the oleobject format types.
                else
                {
                    FileStream fs = File.Create(fileName);
                    fs.Write(ole.ObjectData, 0, ole.ObjectData.Length);
                    fs.Close();
                }

            }

        }
    }
}