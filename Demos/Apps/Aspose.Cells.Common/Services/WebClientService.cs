using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MimeKit;

namespace Aspose.Cells.Common.Services
{
    public class WebClientService
    {
        private const int MaxFileSizeBytes = 50000000;

        public async Task<FormFile> Upload(string url)
        {
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return null;
            }

            var reader = new UriBuilder(url);
            if (reader.Host.Contains("drive.google.com") && reader.Path.Contains("file/d/"))
            {
                var s = reader.Scheme;
                var h = reader.Host;
                var p = reader.Path.Split('/').Skip(3).FirstOrDefault();
                if (!string.IsNullOrEmpty(p))
                {
                    var builder = new UriBuilder {Scheme = s, Host = h, Path = "uc", Query = "export=download&id=" + p};
                    url = builder.Uri.AbsoluteUri;
                }
            }
            else if (reader.Host.Contains("dropbox.com"))
            {
                reader.Query = "dl=1";
                url = reader.Uri.AbsoluteUri;
            }

            var client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            client.DownloadProgressChanged += DownloadProgressChanged;

            byte[] data;
            try
            {
                data = await client.DownloadDataTaskAsync(url);
            }
            catch (Exception ex)
            {
                throw new ValidationException($"Can not parse link '{url}' {ex.Message}");
            }

            var header = client.ResponseHeaders["Content-Disposition"];
            string filename;
            if (header != null)
            {
                var contentDisposition = new System.Net.Mime.ContentDisposition(header);
                filename = contentDisposition.FileName;
            }
            else if (client.ResponseHeaders.AllKeys.Any(k => k == "Content-Type") &&
                     MimeTypes.TryGetExtension(client.ResponseHeaders["Content-Type"], out var ext))
            {
                filename = Guid.NewGuid() + ext;
            }
            else
            {
                filename = Guid.NewGuid() + ".html";
            }

            if (data.Length > MaxFileSizeBytes)
            {
                throw new ValidationException($"Link '{url}' has file '{filename}' larger when limit");
            }

            var content = new MemoryStream(data);

            return new FormFile(content, 0, content.Length, filename, filename);
        }

        private static void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            var webClient = (WebClient) sender;
            if (e.TotalBytesToReceive > MaxFileSizeBytes)
            {
                webClient.CancelAsync();
            }
        }
    }
}