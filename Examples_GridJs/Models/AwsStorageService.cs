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
using Aspose.Cells.GridJsDemo.Models;
using Newtonsoft.Json;

namespace Aspose.Cells.GridJsDemo
{
   
   public class AwsHolder
    {
        public Stream s;
        public String str;
        public AwsMetaInfo meta;
        public AwsHolder(Stream s, String str, AwsMetaInfo meta)
        {
            this.s = s;
            this.str = str;
            this.meta = meta;
        }

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
       
         void Upload(string objectPath, Stream stream);
         void Upload(string objectPath, String str);

        Stream Download(string objectPath);


        string GetUrl(double durationHours,string p);
        bool CheckExist(string objectPath);
    }

    public class AwsStorageService : IStorageService
    {
         
        private AmazonS3Client _client;
        private readonly string _bucket;

        public AwsStorageService(  )
        {

            _bucket = AwsConfig.bucketName;
            Configure();
        }

        private void Configure( )
        {
            var regionEndpoint = AwsConfig.RegionEndpoint;
            var credentials = AwsConfig.Credentials;
            _client = new AmazonS3Client(credentials, regionEndpoint);
        }

        /// <summary>
        /// Uploads content specified by stream to object specified by path
        /// </summary>
        /// <param name="objectPath">object (file) path</param>
        /// <param name="stream">stream to upload</param>
        /// <param name="metadata">metadata custom fields</param>
        public   void Upload(string objectPath, Stream stream, AwsMetaInfo metadata)
        {
           
          
            var request = new PutObjectRequest
            {
                BucketName = _bucket,
                Key = GetObjectPath(objectPath),
                InputStream = stream,
                AutoCloseStream = true
            };
           
            try
            {
                 var s=  _client.PutObjectAsync(request).Result;
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        public void Upload(string objectPath, Stream stream)
        {
              Upload(objectPath, stream, null);
        }

        public   void Upload(string objectPath, string s)
        {
            var request = new PutObjectRequest
            {
                BucketName = _bucket,
                Key = GetObjectPath(objectPath),
                ContentBody = s,
                AutoCloseStream = true
            };

            
            try
            {
              var rr=  _client.PutObjectAsync(request).Result;
                 
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        private static Dictionary<string, string> Metadata(MetadataCollection m)
        {
            var dict = new Dictionary<string, string>();
            if (null == m) return dict;
            foreach (var k in m.Keys)
                dict.Add(k.ToLower(), HttpUtility.UrlDecode(m[k]));
            return dict;
        }

        private static string GetObjectPath(string objectPath)
        {
            return objectPath;
        }

        public   AwsHolder DownloadEx(string objectPath)
        {
            var request = new GetObjectRequest
            {
                BucketName = _bucket,
                Key = GetObjectPath(objectPath)
            };
            var response =   _client.GetObjectAsync(request).Result;
            var responseStream = response.ResponseStream;

            var ms = new MemoryStream();
            responseStream.CopyTo(ms);
            ms.Position = 0;
            return new AwsHolder(ms, response.Headers["Content-Type"], AwsMetaInfo.FromDict(Metadata(response.Metadata)));
        }



        public Stream Download(string objectPath)
        {
            AwsHolder holder = DownloadEx(objectPath);
            return holder.s;
        }

        public String GetUrl(double duration,string objectPath)
        {
            string urlString = "";
            try
            {
                GetPreSignedUrlRequest request1 = new GetPreSignedUrlRequest
                {
                    BucketName = _bucket,
                    Key = GetObjectPath(objectPath),
                    Expires = DateTime.UtcNow.AddHours(duration)
                };
                //client.getpu
                urlString = _client.GetPreSignedURL(request1);
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            return urlString;
        }

        public bool CheckExist(string objectPath)
        {
            try
            {
                GetObjectMetadataRequest request = new GetObjectMetadataRequest()
                {
                    BucketName = _bucket,
                    Key = GetObjectPath(objectPath),
                };
               var response = _client.GetObjectMetadataAsync(request).Result;

                return true;
            }

            catch (Amazon.S3.AmazonS3Exception ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return false;

                //status wasn't not found, so throw the exception
                throw;
            }
        }

        
    }
}