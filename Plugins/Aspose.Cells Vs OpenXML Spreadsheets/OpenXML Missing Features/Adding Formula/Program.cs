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
            string FileName = FilePath + "Adding Formula.xlsx";
            
            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Adding a new worksheet to the Excel object
            int sheetIndex = workbook.Worksheets.Add();

            //Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[sheetIndex];

            //Adding a value to "A1" cell
            worksheet.Cells["A1"].PutValue(1);

            //Adding a value to "A2" cell
            worksheet.Cells["A2"].PutValue(2);

            //Adding a value to "A3" cell
            worksheet.Cells["A3"].PutValue(3);

            //Adding a SUM formula to "A4" cell
            worksheet.Cells["A4"].Formula = "=SUM(A1:A3)";

            //Calculating the results of formulas
            workbook.CalculateFormula();

            //Get the calculated value of the cell
            string value = worksheet.Cells["A4"].Value.ToString();

            //Saving the Excel file
            workbook.Save(FileName);
        }
    }
}
