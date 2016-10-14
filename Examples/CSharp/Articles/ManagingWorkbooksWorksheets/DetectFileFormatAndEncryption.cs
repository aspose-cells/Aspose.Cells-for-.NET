using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class DetectFileFormatAndEncryption
    {
        public static void Run()
        {
            // ExStart:DetectFileFormatAndEncryption
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Detect file format
            FileFormatInfo info = FileFormatUtil.DetectFileFormat(dataDir + "Book1.xlsx");

            //Gets the detected load format
            Console.WriteLine("The spreadsheet format is: " + FileFormatUtil.LoadFormatToExtension(info.LoadFormat));

            //Check if the file is encrypted.
            Console.WriteLine("The file is encrypted: " + info.IsEncrypted);
            // ExEnd:DetectFileFormatAndEncryption
        }
    }
}
