using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Display_or_Hide_Row_Column_Headers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream("C:\\book1.xls", FileMode.Open);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            //Hiding the headers of rows and columns
            worksheet.IsRowColumnHeadersVisible = false;

            //Saving the modified Excel file
            workbook.Save("C:\\output.xls");

            //Closing the file stream to free all resources
            fstream.Close();
        }
    }
}
