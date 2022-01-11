using System;
using System.IO;
using Amazon.S3;
 
using Aspose.Cells.GridJs;
 

namespace Aspose.Cells.GridJsDemo.Models
{
    public class AwsCache : GridCacheForStream
    {
        private readonly IStorageService _storage;

        public AwsCache(IStorageService storage)
        {
            _storage = storage;
        }

        private static string GetKey(string uid)
        {
            return "GridJsCache/" + uid;
        }
        
        public override void SaveStream(Stream s, string uid)
        {
            try
            {
                s.Position = 0;
                _storage.Upload(GetKey(uid), s);
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }
        }

        public override Stream LoadStream(string uid)
        {
            try
            {
                return _storage.Download(GetKey(uid));
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }

            return null;
        }

        public override String GetFileUrl(string uid)
        {
            try
            {
                return _storage.GetUrl(5,GetKey(uid));
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }

            return null;
        }

        //TODO 
        public override bool IsExisted(String uid)
        {

            return _storage.CheckExist(GetKey(uid));
           
        }
    }
}