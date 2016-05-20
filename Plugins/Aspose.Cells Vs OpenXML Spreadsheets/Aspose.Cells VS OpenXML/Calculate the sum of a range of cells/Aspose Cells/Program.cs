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
            string FileName = FilePath + "Calculate the sum of a range of cells.xlsx";
            string worksheetName = "Sheet1";
            string firstCellName = "A1";
            string lastCellName = "A3";
            string resultCell = "A4";
            CalculateSumOfCellRange(FileName, worksheetName, firstCellName, lastCellName, resultCell);
        }

        private static void CalculateSumOfCellRange(string docName, string worksheetName, string firstCellName, string lastCellName, string resultCell)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook(docName);

            //Obtaining the reference of the worksheet by passing its Name
            Worksheet worksheet = workbook.Worksheets[worksheetName];

            //Adding a SUM formula to "A4" cell
            worksheet.Cells[resultCell].Formula = "=SUM(" + firstCellName + ":" + lastCellName + ")"; // =SUM(A1:A3)

            //Calculating the results of formulas
            workbook.CalculateFormula();

            //Get the calculated value of the cell
            string value = worksheet.Cells["A4"].Value.ToString();

            //Saving the Excel file
            workbook.Save(docName);
        }
    }
}
