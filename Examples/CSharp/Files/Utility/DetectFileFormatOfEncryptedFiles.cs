using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Files.Utility
{
    public class DetectFileFormatOfEncryptedFiles
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();
            
            var filename = sourceDir + "encryptedBook1.out.tmp";

             Stream stream = File.Open(filename, FileMode.Open);

            FileFormatInfo fileFormatInfo = FileFormatUtil.DetectFileFormat(stream, "1234"); // The password is 1234

            Console.WriteLine("File Format: " + fileFormatInfo.FileFormatType);
            // ExEnd:1
        }
          }
        }
            
