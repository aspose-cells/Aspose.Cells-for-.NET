using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Aspose.Cells.Common.Config;
using Aspose.Cells.Common.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Aspose.Cells.Common.Services
{
    public class AwsConfig
    {
        public string RegionEndpoint { get; set; }
        public string ServiceUrl { get; set; }
        public bool? ForcePathStyle { get; set; }
        public string AccessKeyId { get; set; }
        public string SecretAccessKey { get; set; }
    }

    public class AwsMetaInfo
    {
        private const string MetaTitle = "x-amz-meta-title";
        private const string MetaOriginalFilename = "x-amz-meta-original-file-name";

        public string Title { get; set; }
        public string OriginalFileName { get; set; }

        public Dictionary<string, string> ToDict()
        {
            var result = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(Title)) result.Add(MetaTitle, Title);
            if (!string.IsNullOrEmpty(OriginalFileName)) result.Add(MetaOriginalFilename, OriginalFileName);

            return result;
        }

        public static AwsMetaInfo FromDict(Dictionary<string, string> dict)
        {
            var result = new AwsMetaInfo();

            if (dict.ContainsKey(MetaTitle)) result.Title = dict[MetaTitle];
            if (dict.ContainsKey(MetaOriginalFilename)) result.OriginalFileName = dict[MetaOriginalFilename];
            return result;
        }
    }

    public class AwsObjectInfo
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public DateTime Modified { get; set; }
    }

    public interface IStorageService
    {
        Task Upload(string objectPath, Stream stream, AwsMetaInfo metadata);
        Task Upload(string objectPath, Stream stream);
        Task<(Stream, string, AwsMetaInfo)> DownloadEx(string objectPath);
        Task<Stream> Download(string objectPath);
        Task Delete(string objectPath);
        Task<(AwsMetaInfo, string)> ObjectMetaInfoEx(string objectPath);
        Task<AwsMetaInfo> ObjectMetaInfo(string objectPath);

        Task<IEnumerable<AwsObjectInfo>> List(string path, int maxItems = -1);
        Task<IEnumerable<string>> ListNames(string path, int maxItems = -1);
        Task<Response> CheckStatus(string path);
        Task UpdateStatus(Response data);
        Task<bool> CheckExists(string objectPath);
        Task DeleteDirectory(string id);
        Task<List<S3Object>> GetS3Objects(string objectPath);
        Task CopyingObjectAsync(string sourceKey, string destinationKey);

        string GetUrl(double durationHours, string p);
    }

    public class AwsStorageService : IStorageService
    {
        private readonly ILogger<AwsStorageService> _logger;
        private AmazonS3Client _client;
        private readonly string _bucket;

        public AwsStorageService(AwsConfig config, string bucket, ILogger<AwsStorageService> logger)
        {
            _logger = logger;
            _bucket = bucket;
            Configure(config);
        }

        private void Configure(AwsConfig config)
        {
            var regionEndpoint = RegionEndpoint.GetBySystemName(config.ServiceUrl);
            var credentials = new BasicAWSCredentials(config.AccessKeyId, config.SecretAccessKey);
            _client = new AmazonS3Client(credentials, regionEndpoint);
        }

        /// <summary>
        /// Uploads content specified by stream to object specified by path
        /// </summary>
        /// <param name="objectPath">object (file) path</param>
        /// <param name="stream">stream to upload</param>
        /// <param name="metadata">metadata custom fields</param>
        public async Task Upload(string objectPath, Stream stream, AwsMetaInfo metadata)
        {
            var request = new PutObjectRequest
            {
                BucketName = _bucket,
                Key = GetObjectPath(objectPath),
                InputStream = stream,
                AutoCloseStream = true
            };

            if (null != metadata)
                foreach (var (key, value) in metadata.ToDict())
                    request.Metadata.Add(key.ToLower(), HttpUtility.UrlEncode(value));
            try
            {
                await _client.PutObjectAsync(request);
            }
            catch (Exception e)
            {
                _logger.AWSUploadStatusError(e);
                throw;
            }
        }

        public async Task Upload(string objectPath, Stream stream)
        {
            await Upload(objectPath, stream, null);
        }

        private static Dictionary<string, string> Metadata(MetadataCollection m)
        {
            var dict = new Dictionary<string, string>();
            if (null == m) return dict;
            foreach (var k in m.Keys)
                dict.Add(k.ToLower(), HttpUtility.UrlDecode(m[k]));
            return dict;
        }

        private static string GetObjectPath(string objectPath) => objectPath;
        //objectPath.StartsWith('/') ? objectPath : $"/{objectPath}";

        public static string Join(params string[] items) => string.Join('/', items.Where(x => !string.IsNullOrEmpty(x)));

        /// <summary>
        /// Downloads object(file) specified by objectPath
        /// </summary>
        /// <param name="objectPath">object(file) path to download</param>
        /// <returns>
        ///     Tuple:
        ///         Item1: file content stream
        ///         Item2: content type
        ///         Item3: metadata custom fields, associated with object
        /// </returns>
        public async Task<(Stream, string, AwsMetaInfo)> DownloadEx(string objectPath)
        {
            var request = new GetObjectRequest
            {
                BucketName = _bucket,
                Key = GetObjectPath(objectPath)
            };
            using var response = await _client.GetObjectAsync(request);
            await using var responseStream = response.ResponseStream;
            var ms = new MemoryStream();
            await responseStream.CopyToAsync(ms);
            ms.Position = 0;
            return (ms, response.Headers["Content-Type"], AwsMetaInfo.FromDict(Metadata(response.Metadata)));
        }

        public async Task<bool> CheckExists(string objectPath)
        {
            var key = GetObjectPath(objectPath);
            var request = new ListObjectsRequest {BucketName = _bucket, Prefix = key};
            var response = await _client.ListObjectsAsync(request);
            return response.S3Objects.Any(o => o.Key == key);
        }

        public async Task<List<S3Object>> GetS3Objects(string objectPath)
        {
            var key = GetObjectPath(objectPath);
            var request = new ListObjectsRequest {BucketName = _bucket, Prefix = key};
            var response = await _client.ListObjectsAsync(request);
            return response.S3Objects;
        }

        /// <summary>
        /// Downloads object(file) specified by objectPath
        /// </summary>
        /// <param name="objectPath">object(file) path to download</param>
        /// <returns>
        ///     Tuple:
        ///         Item1: file content stream
        ///         Item2: content type
        /// </returns>
        public async Task<(Stream, string)> Download1(string objectPath)
        {
            var (stream, contentType, _) = await DownloadEx(objectPath);
            return (stream, contentType);
        }

        /// <summary>
        /// Downloads object(file) specified by objectPath
        /// </summary>
        /// <param name="objectPath">object(file) path to download</param>
        /// <returns>file content stream</returns>
        public async Task<Stream> Download(string objectPath) => (await DownloadEx(objectPath)).Item1;

        /// <summary>
        /// Delete object(file) specified by objectPath
        /// </summary>
        /// <param name="objectPath">object(file) path to download</param>
        public async Task Delete(string objectPath)
        {
            var request = new DeleteObjectRequest
            {
                BucketName = _bucket,
                Key = GetObjectPath(objectPath)
            };
            await _client.DeleteObjectAsync(request);
        }

        /// <summary>
        /// Returns Metadata info specified by objectPath
        /// </summary>
        /// <param name="objectPath">object(file) path</param>
        /// <returns>
        ///     Tuple:
        ///         Item1: metadata custom fields, associated with object
        ///         Item2: content type
        /// </returns>
        public async Task<(AwsMetaInfo, string)> ObjectMetaInfoEx(string objectPath)
        {
            var request = new GetObjectMetadataRequest
            {
                BucketName = _bucket,
                Key = GetObjectPath(objectPath)
            };
            var response = await _client.GetObjectMetadataAsync(request);
            return (AwsMetaInfo.FromDict(Metadata(response.Metadata)), response.Headers["Content-Type"]);
        }

        /// <summary>
        /// Returns Metadata info specified by objectPath
        /// </summary>
        /// <param name="objectPath">object(file) path</param>
        /// <returns>Metadata custom fields associated with the object</returns>
        public async Task<AwsMetaInfo> ObjectMetaInfo(string objectPath) => (await ObjectMetaInfoEx(objectPath)).Item1;

        /// <summary>
        /// List objects within the path
        /// </summary>
        /// <param name="path">Root path</param>
        /// <param name="maxItems">max items returned (-1 - no restrictions)</param>
        /// <returns>AWSObjectInfo enumeration</returns>
        public async Task<IEnumerable<AwsObjectInfo>> List(string path, int maxItems = -1)
        {
            var result = new List<AwsObjectInfo>();
            var request = new ListObjectsRequest
            {
                BucketName = _bucket,
                Prefix = GetObjectPath(path),
                MaxKeys = 100
            };
            ListObjectsResponse response;
            do
            {
                response = await _client.ListObjectsAsync(request);

                result.AddRange(response.S3Objects.Select(o => new AwsObjectInfo
                {
                    Path = o.Key,
                    Name = o.Key.StartsWith(request.Prefix) ? o.Key.Substring(request.Prefix.Length).TrimStart('/') : o.Key.TrimStart('/'),
                    Size = o.Size,
                    Modified = o.LastModified
                }));

                request.Marker = response.NextMarker;
            } while (response.IsTruncated && (maxItems == -1 || maxItems > 0 && result.Count < maxItems));

            return result;
        }

        /// <summary>
        /// List names within the path
        /// </summary>
        /// <param name="path">Root path</param>
        /// <param name="maxItems">max items returned (-1 - no restrictions)</param>
        /// <returns>names enumeration</returns>
        public async Task<IEnumerable<string>> ListNames(string path, int maxItems = -1) => (await List(path, maxItems)).Select(o => o.Name);

        public async Task<Response> CheckStatus(string path)
        {
            var (stream, _, _) = await DownloadEx(Join(path, "status.json"));
            var serializer = new JsonSerializer();

            using var sr = new StreamReader(stream);
            using var jsonTextReader = new JsonTextReader(sr);
            return serializer.Deserialize<Response>(jsonTextReader);
        }

        public async Task UpdateStatus(Response data)
        {
            await using var ms = new MemoryStream();
            await using var writer = new StreamWriter(ms);
            using var jsonWriter = new JsonTextWriter(writer);
            var ser = new JsonSerializer();
            ser.Serialize(jsonWriter, data);
            await jsonWriter.FlushAsync();
            await Upload(Join(data.FolderName, "status.json"), ms);
        }

        public async Task DeleteDirectory(string id)
        {
            var key = GetObjectPath(id + "/");
            var request = new ListObjectsRequest {BucketName = _bucket, Prefix = key};
            var response = await _client.ListObjectsAsync(request);
            foreach (var o in response.S3Objects)
            {
                await Delete(o.Key);
            }

            await Delete(id + "/");
        }

        public async Task CopyingObjectAsync(string sourceKey, string destinationKey)
        {
            try
            {
                var request = new CopyObjectRequest
                {
                    SourceBucket = _bucket,
                    SourceKey = GetObjectPath(sourceKey),
                    DestinationBucket = _bucket,
                    DestinationKey = GetObjectPath(destinationKey)
                };
                await _client.CopyObjectAsync(request);
            }
            catch (AmazonS3Exception e)
            {
                _logger.LogError("Error encountered on server. Message:{Message} when writing an object", e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError("Unknown encountered on server. Message:{Message} when writing an object", e.Message);
            }
        }

        public string GetUrl(double duration, string objectPath)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = _bucket,
                Key = GetObjectPath(objectPath),
                Expires = DateTime.UtcNow.AddHours(duration)
            };
            var urlString = _client.GetPreSignedURL(request);
            return urlString;
        }
    }
}