using System.IO;

using Aspose.Cells;
using System;

namespace CSharp.Files.Handling
{
    public class OpeningFilewithDataOnly
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Load only specific sheets with data and formulas
            // Other objects, items etc. would be discarded

            // Instantiate LoadOptions specified by the LoadFormat
            LoadOptions loadOptions7 = new LoadOptions(LoadFormat.Xlsx);

            // Set the LoadDataOption
            LoadDataOption dataOption = new LoadDataOption();
            // Specify the sheet(s) in the template file to be loaded
            dataOption.SheetNames = new string[] { "Sheet2" };
            dataOption.ImportFormula = true;
            // Only data should be loaded.
            loadOptions7.LoadDataOnly = true;
            // Specify the LoadDataOption
            loadOptions7.LoadDataOptions = dataOption;

            // Create a Workbook object and opening the file from its path
            Workbook wb = new Workbook(dataDir + "Book1.xlsx", loadOptions7);
            Console.WriteLine("File data imported successfully!");
            // ExEnd:1
            
            }
          }
        }
