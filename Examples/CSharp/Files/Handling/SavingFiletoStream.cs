using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.Files.Handling
{
    public class SavingFiletoStream
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string filePath = dataDir + "Book1.xlsx";

            //Load your source workbook
            Workbook workbook = new Workbook(filePath);
            FileStream stream = new FileStream(dataDir + "output.xlsx", FileMode.CreateNew);
            workbook.Save(stream, new XlsSaveOptions(SaveFormat.Xlsx));
            stream.Close();

            //ExEnd:1


        }
    }
}