// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System.Diagnostics;
using Aspose.Cells;

namespace Direct_Formula_Call
{
    class Program
    {
        static void Main(string[] args)
        {
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
            workbook.Save("Calulate Any Formula.xls");
        }
    }
}
