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
            string FilePath = @"..\..\..\..\Sample Files\";
            string FileName = FilePath + "Get a column heading.xlsx";
            
            string worksheetName = "Sheet1";
            string cellName = "B3";
            string s1 = GetColumnHeading(FileName, worksheetName, cellName);
        }

        private static string GetColumnHeading(string docName, string worksheetName, string cellName)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook(docName);

            //Obtaining the reference of the worksheet by passing its Name
            Worksheet worksheet = workbook.Worksheets[worksheetName];

            //Removing value from cell
            Cell Cell = worksheet.Cells[cellName];

            //Get First row of the column
            string ColumnHeadingName = CellsHelper.CellIndexToName(0, Cell.Column);

            //return value of heading cell
            return worksheet.Cells[ColumnHeadingName].Value.ToString();
        }
    }
}
