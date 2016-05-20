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
            string FileName = FilePath + "Copy Shapes between Worksheets.xlsx";
            
            //Open the template file
            Workbook workbook = new Workbook(FileName);

            //Get the Chart from the "Chart" worksheet.
            Aspose.Cells.Charts.Chart source = workbook.Worksheets["Chart"].Charts[0];

            Aspose.Cells.Drawing.ChartShape cshape = source.ChartObject;

            //Copy the Chart to the Result Worksheet
            workbook.Worksheets["Result"].Shapes.AddCopy(cshape, 20, 0, 2, 0);

            //Save the Worksheet
            workbook.Save(FileName);
 
        }
    }
}
