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
            string FileName = FilePath + "Delete text from a cell.xlsx";
            
            string sheetName = "Sheet1";
            string colName = "B";
            uint rowIndex = 2;
            DeleteTextFromCell(FileName, sheetName, colName, rowIndex);
        }

        private static void DeleteTextFromCell(string docName, string sheetName, string colName, uint rowIndex)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook(docName);

            //Obtaining the reference of the worksheet by passing its Name
            Worksheet worksheet = workbook.Worksheets[sheetName];

            //Removing value from cell
            worksheet.Cells[colName + rowIndex].PutValue("");

            //Saving the Excel file
            workbook.Save(docName);
        }
    }
}
