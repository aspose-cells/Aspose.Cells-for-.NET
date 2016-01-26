using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.Articles
{
    public class LoadWebImage
    {
        public static void Main() 
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Define memory stream object
            System.IO.MemoryStream objImage;

            //Define web client object
            System.Net.WebClient objwebClient;

            //Define a string which will hold the web image url
            string sURL = "http://www.aspose.com/Images/aspose-logo.jpg";

            try
            {
                //Instantiate the web client object
                objwebClient = new System.Net.WebClient();

                //Now, extract data into memory stream downloading the image data into the array of bytes
                objImage = new System.IO.MemoryStream(objwebClient.DownloadData(sURL));

                //Create a new workbook
                Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();

                //Get the first worksheet in the book
                Aspose.Cells.Worksheet sheet = wb.Worksheets[0];

                //Get the first worksheet pictures collection
                Aspose.Cells.Drawing.PictureCollection pictures = sheet.Pictures;

                //Insert the picture from the stream to B2 cell
                pictures.Add(1, 1, objImage);

                //Save the excel file
                wb.Save(dataDir+ "webimagebook.xlsx");
            }
            catch (Exception ex)
            {
                //Write the error message on the console
                Console.WriteLine(ex.Message);
            }
            
            
        }
    }
}