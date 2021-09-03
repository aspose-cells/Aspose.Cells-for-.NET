using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Files.Utility
{
    public class ConvertingToXPS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Open an Excel file
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(dataDir + "Book1.xls");

            // Get the first worksheet
            Aspose.Cells.Worksheet sheet = workbook.Worksheets[0];

            // Apply different Image and Print options
            Aspose.Cells.Rendering.ImageOrPrintOptions options = new Aspose.Cells.Rendering.ImageOrPrintOptions();
            
            // Set the Format
            options.SaveFormat = SaveFormat.Xps;
            
            // Render the sheet with respect to specified printing options
            Aspose.Cells.Rendering.SheetRender sr = new Aspose.Cells.Rendering.SheetRender(sheet, options);
            
            // Save
            sr.ToImage(0, dataDir + "out_printingxps.out.xps");

            // Export the whole workbook to XPS
            Aspose.Cells.Rendering.WorkbookRender wr = new Aspose.Cells.Rendering.WorkbookRender(workbook, options);
            wr.ToImage(dataDir + "out_whole_printingxps.out.xps");
            // ExEnd:1
        }
    }
}
