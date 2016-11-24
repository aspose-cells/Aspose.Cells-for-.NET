using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithHTMLFormat
{
    // ExStart:ExportStreamProviderClass
    public class ExportStreamProvider : IStreamProvider
    {
        private string outputDir;

        public ExportStreamProvider(string dir)
        {
            outputDir = dir;
        }

        public void InitStream(StreamProviderOptions options)
        {
            string path = outputDir + Path.GetFileName(options.DefaultPath);
            options.CustomPath = path;
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            options.Stream = File.Create(path);
        }

        public void CloseStream(StreamProviderOptions options)
        {
            if (options != null && options.Stream != null)
            {
                options.Stream.Close();
            }
        }
    }
    // ExEnd:ExportStreamProviderClass

    public class ImplementIStreamProvider
    {
        public static void Run()
        {
            // ExStart:ImplementIStreamProvider
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            string outputDir = dataDir + @"out\";

            // Create workbook
            Workbook wb = new Workbook(dataDir + "sample.xlsx");

            HtmlSaveOptions options = new HtmlSaveOptions();
            options.StreamProvider = new ExportStreamProvider(outputDir);

            // Save into .html using HtmlSaveOptions
            wb.Save(dataDir + "output_out.html", options);
            // ExEnd:ImplementIStreamProvider
        }
    }
}
