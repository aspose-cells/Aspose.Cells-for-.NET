using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class OpeningCSVFilesWithPreferredParser
    {
        //Input directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();
        // ExStart:1
        class TextParser : ICustomParser
        {
            public object ParseObject(string value)
            {
                return value;
            }
            public string GetFormat()
            {
                return "";
            }
        }

        class DateParser : ICustomParser
        {
            public object ParseObject(string value)
            {
                DateTime myDate = DateTime.ParseExact(value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                return myDate;
            }
            public string GetFormat()
            {
                return "dd/MM/yyyy";
            }
        }

        public static void Main()
        {
            // Initialize Text File's LoadFormat
            LoadFormat oLoadFormat = LoadFormat.Csv;

            // Initialize Text File's Load options
            TxtLoadOptions oTxtLoadOptions = new TxtLoadOptions(oLoadFormat);

            // Specify the separatot character
            oTxtLoadOptions.Separator = Convert.ToChar(",");

            // Specify the encoding scheme
            oTxtLoadOptions.Encoding = System.Text.Encoding.UTF8;

            // Set the flag to true for converting datetime data
            oTxtLoadOptions.ConvertDateTimeData = true;

            // Set the preferred parsers
            oTxtLoadOptions.PreferredParsers = new ICustomParser[] { new TextParser(), new DateParser() };

            // Initialize the workbook object by passing CSV file and text load options
            Workbook oExcelWorkBook = new Aspose.Cells.Workbook(sourceDir + "samplePreferredParser.csv", oTxtLoadOptions);

            // Get the first cell
            Cell oCell = oExcelWorkBook.Worksheets[0].Cells["A1"];

            // Display type of value
            Console.WriteLine("A1: " + oCell.Type.ToString() + " - " + oCell.DisplayStringValue);

            // Get the second cell
            oCell = oExcelWorkBook.Worksheets[0].Cells["B1"];

            // Display type of value
            Console.WriteLine("B1: " + oCell.Type.ToString() + " - " + oCell.DisplayStringValue);

            // Save the workbook to disc
            oExcelWorkBook.Save(outputDir + "outputsamplePreferredParser.xlsx");

            Console.WriteLine("OpeningCSVFilesWithPreferredParser executed successfully.\r\n");
        }
        // ExEnd:1
    }
}

