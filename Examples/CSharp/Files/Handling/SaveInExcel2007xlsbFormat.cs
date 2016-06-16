using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class SaveInExcel2007xlsbFormat
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Creating a Workbook object
            Workbook workbook = new Workbook();
        // Save in Excel2007 xlsb format
            workbook.Save(dataDir + "output.xlsb", SaveFormat.Xlsb);   
            // ExEnd:1
        }
    }
  }
