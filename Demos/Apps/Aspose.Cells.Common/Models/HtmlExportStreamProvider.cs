using System.Collections.Generic;
using System.IO;

namespace Aspose.Cells.Common.Models
{
    public class HtmlExportStreamProvider : IStreamProvider
    {
        private readonly string _relativelyPath;

        internal HtmlExportStreamProvider(string filename)
        {
            FileStreams = new Dictionary<string, Stream>();
            var fileInfo = new FileInfo(filename);
            _relativelyPath = $"{fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length)}_files";
        }

        public void CloseStream(StreamProviderOptions options)
        {
        }

        public void InitStream(StreamProviderOptions options)
        {
            if (FileStreams.ContainsKey(options.DefaultPath)) return;

            options.Stream = new MemoryStream();
            var fileInfo = new FileInfo(options.DefaultPath);
            var customPath = $"{_relativelyPath}/{fileInfo.Name}";
            options.CustomPath = customPath;
            FileStreams.Add(customPath, options.Stream);
        }

        internal IDictionary<string, Stream> FileStreams { get; }
    }
}