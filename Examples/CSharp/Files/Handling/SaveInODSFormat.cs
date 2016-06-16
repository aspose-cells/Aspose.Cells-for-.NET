using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class SaveInODSFormat
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Creating a Workbook object
            Workbook workbook = new Workbook();

 // Save in ODS format
            workbook.Save(dataDir + "output.ods", SaveFormat.ODS);
            // ExEnd:1
            }
        }
  }
