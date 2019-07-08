using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class OpeningFODSFiles
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Instantiate LoadOptions specified by the LoadFormat.
            LoadOptions loadOptions = new LoadOptions(LoadFormat.FODS);

            // Create a Workbook object and opening the file from its path
            //Workbook workbook = new Workbook(sourceDir + "Book_CSV.csv", loadOptions);
            Workbook workbook = new Workbook(sourceDir + "SampleFods.fods");

            // Using the Sheet 1 in Workbook
            Worksheet worksheet = workbook.Worksheets[0];

            // Accessing a cell using its name
            Cell cell = worksheet.Cells["A1"];

            Console.WriteLine("Cell Name: " + cell.Name + " Value: " + cell.StringValue);

            // ExEnd:1
            Console.WriteLine("OpeningFODSFiles executed successfully!");
            }
          }
        }
            
