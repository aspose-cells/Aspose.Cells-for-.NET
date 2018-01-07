using System.IO;
using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class LoadWebImage
    {
        public static void Run() 
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            try
            {
                // Define a string which will hold the web image url
                string sURL = "http://www.aspose.com/Images/aspose-logo.jpg";

                // Instantiate the web client object
                System.Net.WebClient objwebClient = new System.Net.WebClient();

                // Now, extract data into memory stream downloading the image data into the array of bytes
                MemoryStream objImage = new System.IO.MemoryStream(objwebClient.DownloadData(sURL));

                // Create a new workbook
                Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();

                // Get the first worksheet in the book
                Aspose.Cells.Worksheet sheet = wb.Worksheets[0];

                // Get the first worksheet pictures collection
                Aspose.Cells.Drawing.PictureCollection pictures = sheet.Pictures;

                // Insert the picture from the stream to B2 cell
                pictures.Add(1, 1, objImage);

                // Save the excel file
                wb.Save(outputDir + "outputLoadWebImage.xlsx");
            }
            catch (Exception ex)
            {
                // Write the error message on the console
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("LoadWebImage executed successfully.");
        }
    }
}
