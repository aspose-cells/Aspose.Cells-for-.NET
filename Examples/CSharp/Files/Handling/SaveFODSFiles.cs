using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class SaveFODSFiles
    {
        public static void Run()
        {
            // ExStart:1
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create a Workbook object and opening the file from its path
            //Workbook workbook = new Workbook(sourceDir + "Book_CSV.csv", loadOptions);
            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets[0];

            worksheet.Cells[0, 0].Value = 1;
            worksheet.Cells[1, 0].Value = 2;
            worksheet.Cells[2, 0].Value = 3;
            worksheet.Cells[2, 2].Value = 4;
            workbook.Save(outputDir + "SaveFODSFiles.fods", SaveFormat.SXC);
            // ExEnd:1
            Console.WriteLine("SaveFODSFiles executed successfully!");
        }
          }
        }
            
