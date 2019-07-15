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
            Workbook workbook = new Workbook(sourceDir + "SampleFods.fods", loadOptions);

            Console.WriteLine("FODS file opened successfully!");

            // ExEnd:1
            }
          }
        }
            
