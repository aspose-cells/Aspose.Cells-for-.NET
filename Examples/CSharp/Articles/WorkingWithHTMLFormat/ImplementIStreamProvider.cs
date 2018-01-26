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
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create workbook
            Workbook wb = new Workbook(sourceDir + "sampleImplementIStreamProvider.xlsx");

            HtmlSaveOptions options = new HtmlSaveOptions();
            options.StreamProvider = new ExportStreamProvider(outputDir + @"out\");

            // Save into .html using HtmlSaveOptions
            wb.Save(outputDir + "outputImplementIStreamProvider.html", options);

            Console.WriteLine("ImplementIStreamProvider executed successfully.");
        }
    }
}
