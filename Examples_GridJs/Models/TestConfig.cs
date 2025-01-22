using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aspose.Cells.GridJsDemo.Models
{
    public class TestConfig
    {
        /// <summary>
        /// the directory which contains workbook files
        /// </summary>
       internal static String ListDir = "/app/wb";
        /// <summary>
        /// temp directory to store file cache
        /// </summary>
       internal static String TempDir =  "/app/grid_cache";
       internal static String UploadDir = "/app/uploads";
    }
    public class AwsConfig
    {
        public static RegionEndpoint RegionEndpoint = RegionEndpoint.GetBySystemName("YourRegion");
        public static BasicAWSCredentials Credentials = new BasicAWSCredentials("YourAccessKey", "YourSecretkey");
        public static AmazonS3Client client = new AmazonS3Client(Credentials, RegionEndpoint);
        public static String bucketName = "YourBucketName";
    }
}
