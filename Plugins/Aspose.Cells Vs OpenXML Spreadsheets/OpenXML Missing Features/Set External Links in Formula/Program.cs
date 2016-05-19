using Aspose.Cells;

/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Cells for .NET API reference when the project is build. Please check https://docs.nuget.org/consume/nuget-faq for more information. If you do not wish to use NuGet, you can manually download Aspose.Cells for .NET API from http://www.aspose.com/downloads, install it and then add its reference to this project. For any issues, questions or suggestions please feel free to contact us using http://www.aspose.com/community/forums/default.aspx
*/

namespace Aspose.Plugins.AsposeVSOpenXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"..\..\..\Sample Files\";
            string FileName = FilePath + "Set External Links in Formula.xlsx";
            
            //Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            //Get first Worksheet
            Worksheet sheet = workbook.Worksheets[0];

            //Get Cells collection
           Aspose.Cells.Cells cells = sheet.Cells;

            //Set formula with external links
            cells["A1"].Formula = "=SUM('[book1.xls]Sheet1'!A2, '[book1.xls]Sheet1'!A4)";

            //Set formula with external links
            cells["A2"].Formula = "='[book1.xls]Sheet1'!A8";

            //Save the workbook
            workbook.Save(FileName);
        }
    }
}
