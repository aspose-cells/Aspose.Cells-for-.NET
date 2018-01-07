using System.IO;
using System;
using Aspose.Cells;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class InsertPictureCellReference
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiate a new Workbook
            Workbook workbook = new Workbook();

            // Get the first worksheet's cells collection
            Cells cells = workbook.Worksheets[0].Cells;

            Style st = workbook.CreateStyle();
            st.Pattern = BackgroundType.Solid;
            st.ForegroundColor = System.Drawing.Color.Yellow;

            // Add string values to the cells
            cells["A1"].PutValue("A1");
            cells["A1"].SetStyle(st, true);

            st.ForegroundColor = System.Drawing.Color.Red;
            cells["C10"].PutValue("C10");
            cells["C10"].SetStyle(st, true);

            // Get the conditional icon's image data
            byte[] imagedata = ConditionalFormattingIcon.GetIconImageData(IconSetType.TrafficLights31, 0);

            // Create a stream based on the image data
            MemoryStream stream = new MemoryStream(imagedata);

            // Add a blank picture to the D1 cell
            Picture pic = workbook.Worksheets[0].Shapes.AddPicture(5, 5, stream, 600, 600);

            // Specify the formula that refers to the source range of cells
            pic.Formula = "A1:C10";

            // Update the shapes selected value in the worksheet
            workbook.Worksheets[0].Shapes.UpdateSelectedValue();

            //Reset the picture to original height and width
            pic.HeightScale = 100;
            pic.WidthScale = 100;

            // Save the Excel file.
            workbook.Save(outputDir + "outputInsertPictureCellReference.xlsx");

            Console.WriteLine("InsertPictureCellReference executed successfully.");
        }
    }
}
