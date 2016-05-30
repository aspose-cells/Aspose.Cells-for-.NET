using System.IO;

using Aspose.Cells;

namespace CSharp.Articles.CopyShapesBetweenWorksheets
{
    public class CopyControls
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create a workbook object
            // Open the template file
            Workbook workbook = new Workbook(dataDir+ "aspose-sample.xlsx");

            // Get the Shapes from the "Control" worksheet.
            Aspose.Cells.Drawing.ShapeCollection shape = workbook.Worksheets["Sheet3"].Shapes;

            // Copy the Textbox to the Result Worksheet
            workbook.Worksheets["Sheet1"].Shapes.AddCopy(shape[0], 5, 0, 2, 0);

            // Copy the Oval Shape to the Result Worksheet
            workbook.Worksheets["Sheet1"].Shapes.AddCopy(shape[1], 10, 0, 2, 0);

            // Save the Worksheet
            workbook.Save(dataDir+ "Controls.out.xlsx");
            // ExEnd:1
            
        }
    }
}
