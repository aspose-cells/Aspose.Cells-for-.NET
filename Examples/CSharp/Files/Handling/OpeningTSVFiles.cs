using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class OpeningTSVFiles
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Instantiate LoadOptions specified by the LoadFormat.
            LoadOptions loadOptions = new LoadOptions(LoadFormat.Tsv);

            // Create a Workbook object and opening the file from its path
            Workbook workbook = new Workbook(sourceDir + "SampleTSVFile.tsv", loadOptions);

            // Using the Sheet 1 in Workbook
            Worksheet worksheet = workbook.Worksheets[0];

            // Accessing a cell using its name
            Cell cell = worksheet.Cells["C3"];

            Console.WriteLine("Cell Name: " + cell.Name + " Value: " + cell.StringValue);

            // ExEnd:1
            Console.WriteLine("OpeningTSVFiles executed successfully!");
            }
          }
        }
            
