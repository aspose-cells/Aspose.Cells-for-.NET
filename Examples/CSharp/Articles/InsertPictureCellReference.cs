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
            try
            {
                // ExStart:1
                // The path to the documents directory.
                string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                // Instantiate a new Workbook
                Workbook workbook = new Workbook();
                // Get the first worksheet's cells collection
                Cells cells = workbook.Worksheets[0].Cells;

                // Add string values to the cells
                cells["A1"].PutValue("A1");
                cells["C10"].PutValue("C10");

                // Get the conditional icon's image data
                byte[] imagedata = ConditionalFormattingIcon.GetIconImageData(IconSetType.TrafficLights31, 0);
                // Create a stream based on the image data
                MemoryStream stream = new MemoryStream(imagedata);

                // Add a blank picture to the D1 cell
                Picture pic = (Picture)workbook.Worksheets[0].Shapes.AddPicture(0, 3, stream, 10, 10);
                // Specify the formula that refers to the source range of cells
                pic.Formula = "A1:C10";
                // Update the shapes selected value in the worksheet
                workbook.Worksheets[0].Shapes.UpdateSelectedValue();

                // Save the Excel file.
                workbook.Save(dataDir + "referencedpicture.out.xlsx");
                // ExEnd:1
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
