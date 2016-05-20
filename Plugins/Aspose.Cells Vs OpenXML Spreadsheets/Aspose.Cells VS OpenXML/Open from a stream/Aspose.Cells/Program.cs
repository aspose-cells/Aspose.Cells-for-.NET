using Aspose.Cells;
using System.IO;

/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Cells for .NET API reference when the project is build. Please check https://docs.nuget.org/consume/nuget-faq for more information. If you do not wish to use NuGet, you can manually download Aspose.Cells for .NET API from http://www.aspose.com/downloads, install it and then add its reference to this project. For any issues, questions or suggestions please feel free to contact us using http://www.aspose.com/community/forums/default.aspx
*/

namespace Aspose.Plugins.AsposeVSOpenXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"..\..\..\..\Sample Files\";
            string FileName = FilePath + "Open a spreadsheet document from a stream.xlsx";
            Stream stream = File.Open(FileName, FileMode.Open);
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
