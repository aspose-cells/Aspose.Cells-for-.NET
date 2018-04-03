using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Data
{
    class PreserveSingleQuotePrefixOfCellValueOrRange
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            //Create workbook
            Workbook wb = new Workbook();

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Access cell A1
            Cell cell = ws.Cells["A1"];

            //Put some text in cell, it does not have Single Quote at the beginning
            cell.PutValue("Text");

            //Access style of cell A1
            Style st = cell.GetStyle();

            //Print the value of Style.QuotePrefix of cell A1
            Console.WriteLine("Quote Prefix of Cell A1: " + st.QuotePrefix);

            //Put some text in cell, it has Single Quote at the beginning
            cell.PutValue("'Text");

            //Access style of cell A1
            st = cell.GetStyle();

            //Print the value of Style.QuotePrefix of cell A1
            Console.WriteLine("Quote Prefix of Cell A1: " + st.QuotePrefix);

            //Print information about StyleFlag.QuotePrefix property
            Console.WriteLine();
            Console.WriteLine("When StyleFlag.QuotePrefix is False, it means, do not update the value of Cell.Style.QuotePrefix.");
            Console.WriteLine("Similarly, when StyleFlag.QuotePrefix is True, it means, update the value of Cell.Style.QuotePrefix.");
            Console.WriteLine();

            //Create an empty style
            st = wb.CreateStyle();

            //Create style flag - set StyleFlag.QuotePrefix as false
            //It means, we do not want to update the Style.QuotePrefix property of cell A1's style.
            StyleFlag flag = new StyleFlag();
            flag.QuotePrefix = false;

            //Create a range consisting of single cell A1
            Range rng = ws.Cells.CreateRange("A1");

            //Apply the style to the range
            rng.ApplyStyle(st, flag);

            //Access the style of cell A1
            st = cell.GetStyle();

            //Print the value of Style.QuotePrefix of cell A1
            //It will print True, because we have not updated the Style.QuotePrefix property of cell A1's style.
            Console.WriteLine("Quote Prefix of Cell A1: " + st.QuotePrefix);

            //Create an empty style
            st = wb.CreateStyle();

            //Create style flag - set StyleFlag.QuotePrefix as true
            //It means, we want to update the Style.QuotePrefix property of cell A1's style.
            flag = new StyleFlag();
            flag.QuotePrefix = true;

            //Apply the style to the range
            rng.ApplyStyle(st, flag);

            //Access the style of cell A1
            st = cell.GetStyle();

            //Print the value of Style.QuotePrefix of cell A1
            //It will print False, because we have updated the Style.QuotePrefix property of cell A1's style.
            Console.WriteLine("Quote Prefix of Cell A1: " + st.QuotePrefix);

            Console.WriteLine("PreserveSingleQuotePrefixOfCellValueOrRange executed successfully.");
        }
    }

}
