using System.IO;

using Aspose.Cells;
using System;
using Aspose.Cells.Drawing;

namespace CSharp.Articles
{
    public class InsertingWAVFile
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Define a string variable to store the image path.
            string ImageUrl = dataDir+ "image2.jpg";

            // Get the picture into the streams.
            FileStream fs = File.OpenRead(ImageUrl);

            // Define a byte array.
            byte[] imageData = new Byte[fs.Length];

            // Obtain the picture into the array of bytes from streams.
            fs.Read(imageData, 0, imageData.Length);

            // Close the stream.
            fs.Close();

            // Get an excel file path in a variable.
            string path = dataDir+ "chord.wav";

            // Get the file into the streams.
            fs = File.OpenRead(path);

            // Define an array of bytes. 
            byte[] objectData = new Byte[fs.Length];

            // Store the file from streams.
            fs.Read(objectData, 0, objectData.Length);

            // Close the stream.
            fs.Close();
            int intIndex = 0;

            // Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            Worksheet sheet = workbook.Worksheets[0];

            // Add Ole Object
            sheet.OleObjects.Add(14, 3, 200, 220, imageData);
            workbook.Worksheets[0].OleObjects[intIndex].FileFormatType = FileFormatType.Unknown;
            workbook.Worksheets[0].OleObjects[intIndex].ObjectData = objectData;
            workbook.Worksheets[0].OleObjects[intIndex].ObjectSourceFullName = path;

            // Save the excel file
            workbook.Save(dataDir+ "testWAV.out.xlsx"); 
            // ExEnd:1
            
            
        }
    }
}
