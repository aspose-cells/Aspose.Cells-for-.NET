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
            string FileName = FilePath + "Insert text into a cell.xlsx";
            InsertText(FileName, "Inserted Text");
        }

        private static void InsertText(string docName, string text)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook(docName);

            //Obtaining the reference of the Active worksheet
            Worksheet worksheet = workbook.Worksheets[workbook.Worksheets.ActiveSheetIndex];

            //insert value from cell
            worksheet.Cells["A1"].PutValue(text);

            //Saving the Excel file
            workbook.Save(docName);
        }
    }
}
