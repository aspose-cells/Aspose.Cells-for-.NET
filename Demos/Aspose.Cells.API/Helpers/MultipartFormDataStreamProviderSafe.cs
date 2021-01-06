using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Aspose.Cells.API.Helpers
{
    ///<Summary>
    /// MultipartFormDataStreamProviderSafe  class
    ///</Summary>
    public class MultipartFormDataStreamProviderSafe : MultipartFormDataStreamProvider
    {
        ///<Summary>
        /// initialize MultipartFormDataStreamProviderSafe  class
        ///</Summary>
        public MultipartFormDataStreamProviderSafe(string rootPath) : base(rootPath)
        {
        }

        ///<Summary>
        /// GetLocalFileName method to get local file name from header
        ///</Summary>
        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            var fileName = headers?.ContentDisposition?.FileName;
            if (fileName == null) return base.GetLocalFileName(headers);
            fileName = fileName.TrimEnd('"').TrimStart('"');
            try
            {
                fileName = Path.GetFileName(fileName);
                if (!string.IsNullOrEmpty(fileName))
                {
                    var name = Path.GetFileNameWithoutExtension(fileName);
                    var extension = Path.GetExtension(fileName);
                    if (!File.Exists(Path.Combine(RootPath, name + extension))) return name + extension;
                    var i = 2;
                    while (File.Exists(Path.Combine(RootPath, name + " " + i + extension)))
                        i++;
                    name += " " + i;

                    return name + extension;
                }
            }
            catch
            {
                // ignored
            }

            return base.GetLocalFileName(headers);
        }
    }
}