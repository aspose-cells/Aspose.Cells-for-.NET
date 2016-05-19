// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using Aspose.Cells;
using System;

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
            string FileName = FilePath + "Retrieve the values of cells.xlsx";
            

            // Retrieve the value in cell A1.
            string value = GetCellValue(FileName, "Sheet1", "A1");
            Console.WriteLine(value);
            Console.ReadKey();
        }
        // Retrieve the value of a cell, given a file name, sheet name, 
        // and address name.
        public static string GetCellValue(string fileName,
            string sheetName,
            string addressName)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook(fileName);

            //Obtaining the reference of the Active worksheet
            Worksheet worksheet = workbook.Worksheets.GetSheetByCodeName(sheetName);

            //retrieve value from cell
            string returnValue = worksheet.Cells[addressName].Value.ToString();

            return returnValue;

        }
    }
}
