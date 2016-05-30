using System.IO;

using Aspose.Cells;

namespace CSharp.Articles.ModifyExistingStyle
{
    public class ModifyThroughStyleObject
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Create a workbook.
            Workbook workbook = new Workbook();

            // Create a new style object.
            Style style = workbook.Styles[workbook.Styles.Add()];

            // Set the number format.
            style.Number = 14;

            // Set the font color to red color.
            style.Font.Color = System.Drawing.Color.Red;

            // Name the style.
            style.Name = "Date1";

            // Get the first worksheet cells.
            Cells cells = workbook.Worksheets[0].Cells;

            // Specify the style (described above) to A1 cell.
            cells["A1"].SetStyle(style);

            // Create a range (B1:D1).
            Range range = cells.CreateRange("B1", "D1");

            // Initialize styleflag object.
            StyleFlag flag = new StyleFlag();

            // Set all formatting attributes on.
            flag.All = true;

            // Apply the style (described above)to the range.
            range.ApplyStyle(style, flag);

            // Modify the style (described above) and change the font color from red to black.
            style.Font.Color = System.Drawing.Color.Black;

            // Done! Since the named style (described above) has been set to a cell and range, 
            // The change would be Reflected(new modification is implemented) to cell(A1) and // Range (B1:D1).
            style.Update();

            // Save the excel file. 
            workbook.Save(dataDir+ "book_styles.out.xls");
            // ExEnd:1
            
            
        }
    }
}
