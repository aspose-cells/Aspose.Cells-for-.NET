using System.IO;

using Aspose.Cells;
using System;

namespace CSharp.Files.Handling
{
    public class OpeningTabDelimitedFiles
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            
             // Opening Tab Delimited Files
            // Instantiate LoadOptions specified by the LoadFormat.
            LoadOptions loadOptions5 = new LoadOptions(LoadFormat.TabDelimited);

            // Create a Workbook object and opening the file from its path
            Workbook wbTabDelimited = new Workbook(dataDir + "Book1TabDelimited.txt", loadOptions5);
            Console.WriteLine("Tab delimited file opened successfully!");
            // ExEnd:1
            }
          }
        }
            
