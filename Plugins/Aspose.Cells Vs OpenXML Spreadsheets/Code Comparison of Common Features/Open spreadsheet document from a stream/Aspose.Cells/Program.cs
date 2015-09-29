using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.Cells
{
    class Program
    {
        static void Main(string[] args)
        {
            string strDoc = @"E:\Aspose\Aspose Vs OpenXML\Aspose.Cells Vs OpenXML Spreadsheet v 1.1\SampleFiles\Open a spreadsheet document from a stream.xlsx";
            Stream stream = File.Open(strDoc, FileMode.Open);
            OpenAndAddToSpreadsheetStream(stream);
            stream.Close();
        }
        public static void OpenAndAddToSpreadsheetStream(Stream stream)
        {
            //Creating a Workbook object, open the file from a Stream object
            //that contains the content of file and it should support seeking
            Workbook workbook = new Workbook(stream);
        }
    }
}
