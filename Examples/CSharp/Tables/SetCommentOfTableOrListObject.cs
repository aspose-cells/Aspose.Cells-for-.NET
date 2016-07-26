using System.IO;
using Aspose.Cells;
using Aspose.Cells.Tables;

namespace Aspose.Cells.Examples.CSharp.Tables
{
    public class SetCommentOfTableOrListObject
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Open the template file.
            Workbook workbook = new Workbook(dataDir + "source.xlsx");

            // Access first worksheet.
            Worksheet worksheet = workbook.Worksheets[0];

            // Access first list object or table.
            ListObject lstObj = worksheet.ListObjects[0];

            // Set the comment of the list object
            lstObj.Comment = "This is Aspose.Cells comment.";

            // Save the workbook in xlsx format
            workbook.Save(dataDir + "SetCommentOfTableOrListObject_out_.xlsx", SaveFormat.Xlsx);
            // ExEnd:1

        }
    }
}
