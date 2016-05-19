// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using Aspose.Cells;
using System.Diagnostics;

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
            string FileName = FilePath + "Direct Formula Call.xlsx";
            
            //Create a workbook
            Workbook workbook = new Workbook();

            //Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Put 20 in cell A1
            Cell cellA1 = worksheet.Cells["A1"];
            cellA1.PutValue(20);

            //Put 30 in cell A2
            Cell cellA2 = worksheet.Cells["A2"];
            cellA2.PutValue(30);

            //Calculate the Sum of A1 and A2
            var results = worksheet.CalculateFormula("=Sum(A1:A2)");
            Cell cellA3 = worksheet.Cells["A3"];
            cellA3.PutValue(results);
            //Print the output
            Debug.WriteLine("Value of A1: " + cellA1.StringValue);
            Debug.WriteLine("Value of A2: " + cellA2.StringValue);
            Debug.WriteLine("Result of Sum(A1:A2): " + results.ToString());
            workbook.Save(FileName);
        }
    }
}
