using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    class HtmlExportFrameScripts
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Open the required workbook to convert
            Workbook w = new Workbook(dataDir + "Sample1.xlsx");

            // Disable exporting frame scripts and document properties
            HtmlSaveOptions options = new HtmlSaveOptions();
            options.ExportFrameScriptsAndProperties = false;

            // Save workbook as HTML
            w.Save(dataDir + "output.out.html", options);
            // ExEnd:1
        }
    }
}
