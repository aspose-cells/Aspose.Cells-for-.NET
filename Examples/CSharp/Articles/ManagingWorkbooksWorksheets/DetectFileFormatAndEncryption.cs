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
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Detect file format
            FileFormatInfo info = FileFormatUtil.DetectFileFormat(sourceDir + "sampleDetectFileFormatAndEncryption");

            //Gets the detected load format
            Console.WriteLine("The spreadsheet format is: " + info.FileFormatType);

            //Check if the file is encrypted.
            Console.WriteLine("The file is encrypted: " + info.IsEncrypted);

            Console.WriteLine("DetectFileFormatAndEncryption executed successfully.");
        }
    }
}
