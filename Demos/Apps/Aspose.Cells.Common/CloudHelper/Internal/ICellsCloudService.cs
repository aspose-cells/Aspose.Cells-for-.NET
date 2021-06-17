namespace Aspose.Cells.Common.CloudHelper
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public interface ICellsCloudService : IDisposable
    {
        Task<string> GetJwtTokenUsingClientCredentialsAsync();

        Task<Stream> Convert(string requestId, string token, string filename, Stream stream, string format);
    }
}
