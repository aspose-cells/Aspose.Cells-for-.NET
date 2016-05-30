using System;
using System.IO;

using Aspose.Cells;
using System.Collections;

namespace CSharp.Articles
{
    public class FindIfCellValueStartsWithSingleQuote
    {
        public static void Run()
        {
            // ExStart:FindIfCellValueStartsWithSingleQuote
            // Create workbook
            Workbook wb = new Workbook();

            // Create worksheet
            Worksheet sheet = wb.Worksheets[0];

            // Access cell A1 and A2
            Cell a1 = sheet.Cells["A1"];
            Cell a2 = sheet.Cells["A2"];

            // Add sample in A1 and sample with quote prefix in A2
            a1.PutValue("sample");
            a2.PutValue("'sample");

            // Print their string values, A1 and A2 both are same
            Console.WriteLine("String value of A1: " + a1.StringValue);
            Console.WriteLine("String value of A2: " + a2.StringValue);

            // Access styles of A1 and A2
            Style s1 = a1.GetStyle();
            Style s2 = a2.GetStyle();

            Console.WriteLine();

            // Check if A1 and A2 has a quote prefix
            Console.WriteLine("A1 has a quote prefix: " + s1.QuotePrefix);
            Console.WriteLine("A2 has a quote prefix: " + s2.QuotePrefix);
            // ExEnd:FindIfCellValueStartsWithSingleQuote           
            
        }
    }
}
