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
            string FileName = FilePath + "Copy Worksheet.xlsx";
            
            //Create a new Workbook.
            //Open an existing Excel file.
            Workbook wb = new Workbook(FileName);

            //Create a Worksheets object with reference to
            //the sheets of the Workbook.
            WorksheetCollection sheets = wb.Worksheets;

            //Copy data to a new sheet from an existing
            //sheet within the Workbook.
            sheets.AddCopy("MySheet");

            //Save the Excel file.
            wb.Save(FileName);
        }
    }
}
