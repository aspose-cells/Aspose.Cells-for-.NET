using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Data.AddOn.Merging
{
    public class UnMergingtheMergedCells
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create a Workbook.
            // Open the excel file.
            Workbook wbk = new Aspose.Cells.Workbook(dataDir + "mergingcells.xls");

            // Create a Worksheet and get the first sheet.
            Worksheet worksheet = wbk.Worksheets[0];

            // Create a Cells object ot fetch all the cells.
            Cells cells = worksheet.Cells;

            // Unmerge the cells.
            cells.UnMerge(5, 2, 2, 3);

            // Save the file.
            wbk.Save(dataDir + "unmergingcells.out.xls");
            // ExEnd:1


        }
    }
}
