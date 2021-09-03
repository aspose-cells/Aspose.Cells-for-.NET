using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class SavingFiletoStream
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string filePath = dataDir + "Book1.xlsx";

            // Load your source workbook
            using (FileStream stream = new FileStream(dataDir + "output.xlsx", FileMode.CreateNew))
            {
                Workbook workbook = new Workbook(filePath);

                workbook.Save(stream, SaveFormat.Xlsx);
                stream.Close();


            }
            // ExEnd:1


        }
    }
}