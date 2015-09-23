using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace Aspose_Cells
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate a new Workbook.
            Workbook workbook = new Workbook();
            //Get the first worksheet. 
            Worksheet sheet = workbook.Worksheets[0];

            //Define a string variable to store the image path.
            string ImageUrl = "pic.jpeg";
            //Get the picture into the streams.
            FileStream fs = File.OpenRead(ImageUrl);
            //Define a byte array.
            byte[] imageData = new Byte[fs.Length];
            //Obtain the picture into the array of bytes from streams.
            fs.Read(imageData, 0, imageData.Length);
            //Close the stream.
            fs.Close();

            //Set the background image for the sheet.
            sheet.SetBackground(imageData);

            //Save the excel file.
            workbook.Save("BackgroundPicBook.xls");
        }
    }
}
