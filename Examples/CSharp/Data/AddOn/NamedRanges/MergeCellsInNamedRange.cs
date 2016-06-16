using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Data.AddOn.NamedRanges
{
    public class MergeCellsInNamedRange
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            // Instantiate a new Workbook.
            Workbook wb1 = new Workbook();

            // Get the first worksheet in the workbook.
            Worksheet worksheet1 = wb1.Worksheets[0];

            // Create a range.
            Range mrange = worksheet1.Cells.CreateRange("A18", "J18");

            // Name the range.
            mrange.Name = "Details";

            // Merge the cells of the range.
            mrange.Merge();

            // Get the range.
            Range range1 = wb1.Worksheets.GetRangeByName("Details");      

            // Define a style object.
            Style style = wb1.CreateStyle();

            // Set the alignment.
            style.HorizontalAlignment = TextAlignmentType.Center;

            // Create a StyleFlag object.
            StyleFlag flag = new StyleFlag();
            // Make the relative style attribute ON.
            flag.HorizontalAlignment = true;

            // Apply the style to the range.
            range1.ApplyStyle(style, flag);

            // Input data into range.
            range1[0, 0].PutValue("Aspose");

            // Save the excel file.
            wb1.Save(dataDir + "mergingrange.out.xls");
            // ExEnd:1
        }
    }
}
