using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.Cells.Common.Config
{
    public class CompositeFileWithOptionsProvider : IFileProvider
    {
        private readonly IFileProvider _webRootFileProvider;
        private readonly IEnumerable<StaticFileOptions> _staticFileOptions;

        public CompositeFileWithOptionsProvider(IFileProvider webRootFileProvider, params StaticFileOptions[] staticFileOptions)
      : this(webRootFileProvider, (IEnumerable<StaticFileOptions>)staticFileOptions) { }

        public CompositeFileWithOptionsProvider(IFileProvider webRootFileProvider, IEnumerable<StaticFileOptions> staticFileOptions)
        {
            _webRootFileProvider = webRootFileProvider ?? throw new ArgumentNullException(nameof(webRootFileProvider));
            _staticFileOptions = staticFileOptions;
        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            var provider = GetFileProvider(subpath, out string outpath);
            return provider.GetDirectoryContents(outpath);
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            var provider = GetFileProvider(subpath, out string outpath);
            return provider.GetFileInfo(outpath);
        }

        public IChangeToken Watch(string filter)
        {
            var provider = GetFileProvider(filter, out string outpath);
            return provider.Watch(outpath);
        }

        private IFileProvider GetFileProvider(string path, out string outpath)
        {
            outpath = path;
            var fileProviders = _staticFileOptions;
            if (fileProviders != null)
            {
                foreach (var item in fileProviders)
                {
                    if (path.StartsWith(item.RequestPath, StringComparison.Ordinal))
                    {
                        outpath = path.Substring(item.RequestPath.Value.Length, path.Length - item.RequestPath.Value.Length);
                        return item.FileProvider;
                    }
                }
            }
            return _webRootFileProvider;
        }
    }
}
