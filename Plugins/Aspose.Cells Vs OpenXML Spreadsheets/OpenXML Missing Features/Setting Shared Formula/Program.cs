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
            string FileName = FilePath + "Setting Shared Formula.xlsx";

            //Instantiate a Workbook from existing file
            Workbook workbook = new Workbook(FileName);

            //Get the cells collection in the first worksheet
            Aspose.Cells.Cells cells = workbook.Worksheets[0].Cells;

            //Apply the shared formula in the range i.e.., B2:B14
            cells["B2"].SetSharedFormula("=A2*0.09", 13, 1);

            //Save the excel file
            workbook.Save(FileName, SaveFormat.Xlsx);
        }
    }
}
