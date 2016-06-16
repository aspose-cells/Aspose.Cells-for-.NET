using System.IO;
using System.Drawing;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.ModifyExistingStyle
{
    public class ModifyThroughSampleExcelFile
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create a workbook.
            // Open a template file. 
            // In the book1.xls file, we have applied Ms Excel's 
            // Named style i.e., "Percent" to the range "A1:C8". 
            Workbook workbook = new Workbook(dataDir+ "book1.xlsx");

            // We get the Percent style and create a style object.
            Style style = workbook.GetNamedStyle("Percent");

            // Change the number format to "0.00%".
            style.Number = 11;

            // Set the font color.
            style.Font.Color = System.Drawing.Color.Red;

            // Update the style. so, the style of range "A1:C8" will be changed too.
            style.Update();

            // Save the excel file.	
            workbook.Save(dataDir+ "book2.out.xlsx");
            // ExEnd:1
            
        }
    }
}
