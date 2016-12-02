using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.KnowledgeBase.FAQs
{
    public class FixOutOfMemoryException
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Specify the LoadOptions
            LoadOptions options = new LoadOptions();

            // Set the memory preferences
            options.MemorySetting = MemorySetting.MemoryPreference;

            // Load the Big Excel file having large Data set in it
            Workbook book = new Workbook(dataDir + "sample.xlsx", options);
            Console.WriteLine("File has been loaded successfully");
            // ExEnd:1
        }
    }
}
