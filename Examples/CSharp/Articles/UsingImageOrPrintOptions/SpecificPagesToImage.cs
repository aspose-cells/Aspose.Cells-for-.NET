using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells;
using Aspose.Cells.Rendering;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles.UsingImageOrPrintOptions
{
    public class SpecificPagesToImage
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Open a template excel file
            Workbook book = new Workbook(dataDir + "Testbook1.xlsx");

            // Get the first worksheet.
            Worksheet sheet = book.Worksheets[0];

            // Get the second worksheet.
            // Worksheet sheet = book.Worksheets[1];

            // Define ImageOrPrintOptions
            ImageOrPrintOptions imgOptions = new ImageOrPrintOptions();

            // Specify the image format
            imgOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;

            // If you want entire sheet as a singe image
            imgOptions.OnePagePerSheet = true;

            // Render the sheet with respect to specified image/print options
            SheetRender sr = new SheetRender(sheet, imgOptions);

            // Render the image for the sheet
            Bitmap bitmap = sr.ToImage(0);

            // Save the image file
            bitmap.Save(dataDir + "SheetImage_out.jpg");
            // ExEnd:1
        }
    }
}
