namespace Aspose.Cells.Common.Config
{
    public static class Configuration
    {
        public static bool IsAsposeCloudApp { get; set; }
        public static string CellsCloudClientId { get; set; }
        public static string CellsCloudClientSecret { get; set; }
        public static string CellsCloudBaseUrl { get; set; }

        public static string CellsCloudAPIMethod { get; set; }
        public static string CellsCloudAPIMethodURI { get; set; }

        public static string CellsCloudAPIReferenceURI { get; set; }

        public static string CellsCloudAPIMethodDocument{ get; set; }

        public static bool IsProduction { get; set; }

        public static int MailServerTimeOut { get; set; }

        public static int MailServerPort { get; set; }

        public static string MailServer { get; set; }

        public static string MailServerUserId { get; set; }

        public static string MailServerUserPassword { get; set; }

        public static string RegionEndpoint { get; set; }
        public static string Bucket { get; set; }
        public static string AccessKeyId { get; set; }
        public static string SecretAccessKey { get; set; }

        public static string FontFolderPath { get; set; }

        public static string ForumKey { get; set; }
        public static string ForumUrl { get; set; }
        public static string ForumCategoryId { get; set; }

        public static string TranslationClientId { get; set; }

        public static string TranslationClientSecret { get; set; }

        public static string SourceFolder => "Source";
        public static string ConvertFolder => "Convert";
        public static string ReportFolder => "Report";
        public static string ErrorFolder => "Error";
        public static string GridJsCacheFolder => "GridJsCache";
        public static string GridJsErrorJsonFolder => "GridJsErrorJson";

        public static int MillisecondsTimeout => 300000;

        public const long MaxRequestBodySize = 0x9600000; // 150M, unit B
        public const int MaximumUploadFileSize = 20; // 20M, unit M
        public const int MaximumUploadFiles = 10;
        public static string ProcessingTimeout => "Your file processing timed out";

        public static int MaxPageCount = 100;
        public static int MaxColumn = 16383; // 0x3FFF
        public static int MaxRow = 0x100000 - 1; // 0xFFFFF
    }
}