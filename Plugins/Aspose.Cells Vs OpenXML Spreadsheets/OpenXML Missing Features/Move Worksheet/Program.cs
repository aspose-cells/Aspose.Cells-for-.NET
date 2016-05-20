// Copyright (c) Aspose 2002-2014. All Rights Reserved.

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
            string FileName = FilePath + "Move Worksheet.xlsx";
            
            //Open an existing excel file.
            Workbook wb = new Workbook(FileName);

            //Create a Worksheets object with reference to
            //the sheets of the Workbook.
            WorksheetCollection sheets = wb.Worksheets;

            //Get the first worksheet.
            Worksheet worksheet = sheets[0];
            string test = worksheet.Name;
            //Move the first sheet to the third position in the workbook.
            worksheet.MoveTo(2);

            //Save the excel file.
            wb.Save(FileName);

        }
    }
}
