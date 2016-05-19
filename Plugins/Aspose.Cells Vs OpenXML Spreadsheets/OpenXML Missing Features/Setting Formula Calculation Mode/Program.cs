using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string FileName = FilePath + "Setting Formula Calculation Mode.xlsx";
            
            //Create a workbook
            Workbook workbook = new Workbook();

            //Set the Formula Calculation Mode to Manual
            workbook.Settings.CalcMode = CalcModeType.Manual;

            //Save the workbook
            workbook.Save(FileName, SaveFormat.Xlsx);
        }
    }
}
