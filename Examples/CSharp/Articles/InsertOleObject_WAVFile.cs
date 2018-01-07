using System.IO;

using Aspose.Cells;
using System;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class InsertOleObject_WAVFile
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            byte[] imageData = File.ReadAllBytes(sourceDir + "sampleInsertOleObject_WAVFile.jpg");

            // Define an array of bytes. 
            byte[] objectData = File.ReadAllBytes(sourceDir + "sampleInsertOleObject_WAVFile.wav");

            // Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            Worksheet sheet = workbook.Worksheets[0];

            // Add Ole Object
            int idx = sheet.OleObjects.Add(3, 3, 200, 220, imageData);

            OleObject ole = sheet.OleObjects[idx];

            ole.FileFormatType = FileFormatType.Ole10Native;
            ole.ObjectData = objectData;
            ole.ObjectSourceFullName = "sample.wav";
            ole.ProgID = "Packager Shell Object";

            Guid gu = new Guid("0003000c-0000-0000-c000-000000000046");
            ole.ClassIdentifier = gu.ToByteArray();

            // Save the excel file
            workbook.Save(outputDir + "outputInsertOleObject_WAVFile.xlsx");

            Console.WriteLine("InsertOleObject_WAVFile executed successfully.");
        }
    }
}
