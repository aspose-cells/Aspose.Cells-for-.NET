using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aspose.Cells;
using Aspose.Cells.Charts;


namespace Aspose.Cells.Examples.CSharp.Charts
{
    class SetValuesFormatCodeOfChartSeries
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            //Load the source Excel file 
            Workbook wb = new Workbook(sourceDir + "sampleSeries_ValuesFormatCode.xlsx");

            //Access first worksheet
            Worksheet worksheet = wb.Worksheets[0];

            //Access first chart
            Chart ch = worksheet.Charts[0];

            //Add series using an array of values
            ch.NSeries.Add("{10000, 20000, 30000, 40000}", true);

            //Access the series and set its values format code
            Series srs = ch.NSeries[0];
            srs.ValuesFormatCode = "$#,##0";

            //Save the output Excel file
            wb.Save(outputDir + "outputSeries_ValuesFormatCode.xlsx");

            Console.WriteLine("SetValuesFormatCodeOfChartSeries executed successfully.");
        }

    }
}
