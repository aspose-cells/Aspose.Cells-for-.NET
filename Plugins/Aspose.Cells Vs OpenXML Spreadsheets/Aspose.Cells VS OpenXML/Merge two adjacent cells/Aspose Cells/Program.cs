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
            string FileName = FilePath + "Merge two adjacent cells.xlsx";
            string sheetName = "Sheet1";
            string cell1Name = "A2";
            string cell2Name = "B2";
            MergeTwoCells(FileName, sheetName, cell1Name, cell2Name);
        }

        private static void MergeTwoCells(string docName, string sheetName, string cell1Name, string cell2Name)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook(docName);

            //Obtaining the reference of the worksheet by passing its Name
            Worksheet worksheet = workbook.Worksheets[sheetName];

            //Get the range of cells i.e.., A1:C1.
            Range range = worksheet.Cells.CreateRange(cell1Name,cell2Name);

            //Merge the cells.
            range.Merge();

            //Saving the Excel file
            workbook.Save(docName);
        }
    }
}
