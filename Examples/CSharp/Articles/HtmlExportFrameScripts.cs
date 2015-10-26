using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    class HtmlExportFrameScripts
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Open the required workbook to convert
            Workbook w = new Workbook(dataDir + "Sample1.xlsx");

            // Disable exporting frame scripts and document properties
            HtmlSaveOptions options = new HtmlSaveOptions();
            options.ExportFrameScriptsAndProperties = false;

            // Save workbook as HTML
            w.Save(dataDir + "output.html", options);
        }
    }
}
