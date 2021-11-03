using Aspose.Cells.Drawing;
using Aspose.Cells.WebExtensions;
using System;
using System.IO;

namespace Aspose.Cells.Examples.CSharp._Workbook
{
    public class ExtractEmbeddedMolFile
    {
        public static void Run()
        {
            // ExStart:1
            //directories
            string SourceDir = RunExamples.Get_SourceDirectory();
            string outputDir = RunExamples.Get_OutputDirectory();

            Workbook workbook = new Workbook(SourceDir + "EmbeddedMolSample.xlsx");
            var index = 1;
            foreach (Worksheet sheet in workbook.Worksheets)
            {
                OleObjectCollection oles = sheet.OleObjects;
                foreach (OleObject ole in oles)
                {
                    string fileName = outputDir + "OleObject" + index + ".mol ";
                    FileStream fs = File.Create(fileName);
                    fs.Write(ole.ObjectData, 0, ole.ObjectData.Length);
                    fs.Close();
                    index++;
                }
            }
            // ExEnd:1

            Console.WriteLine("ExtractEmbeddedMolFile executed successfully.");
        }
    }
}
