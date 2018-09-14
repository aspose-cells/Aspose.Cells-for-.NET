using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Files.Utility
{
    public class SettingImagePrefrencesforHTML
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Specify the file path
            string filePath = dataDir + "Book1.xlsx";

            // Load a spreadsheet to be converted
            Workbook book = new Workbook(filePath);

            // Create an instance of HtmlSaveOptions
            HtmlSaveOptions saveOptions = new HtmlSaveOptions(SaveFormat.Html);

            // Set the ImageFormat to PNG
            saveOptions.ImageOptions.ImageType = Drawing.ImageType.Png;

            // Set SmoothingMode to AntiAlias
            saveOptions.ImageOptions.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Set TextRenderingHint to AntiAlias
            saveOptions.ImageOptions.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            // Save spreadsheet to HTML while passing object of HtmlSaveOptions
            book.Save( dataDir + "output.html", saveOptions);

            // ExEnd:1
        }
    }
}
