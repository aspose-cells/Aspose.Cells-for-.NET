using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class OpeningMicrosoftExcel2007XlsxFiles
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
             // Opening Microsoft Excel 2007 Xlsx Files
            // Instantiate LoadOptions specified by the LoadFormat.
            LoadOptions loadOptions2 = new LoadOptions(LoadFormat.Xlsx);

            // Create a Workbook object and opening the file from its path
            Workbook wbExcel2007 = new Workbook(dataDir + "Book_Excel2007.xlsx", loadOptions2);
            Console.WriteLine("Microsoft Excel 2007 workbook opened successfully!");
            // ExEnd:1
            }
          }
        }
