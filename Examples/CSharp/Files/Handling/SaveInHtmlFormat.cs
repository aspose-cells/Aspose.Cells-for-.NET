using System.IO;

using Aspose.Cells;

namespace CSharp.Files.Handling
{
    public class SaveInHtmlFormat
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Creating a Workbook object
            Workbook workbook = new Workbook();
          // Save in Html format
            workbook.Save(dataDir + "output.html", SaveFormat.Html);
            
          // ExEnd:1
          }
     }
 }
