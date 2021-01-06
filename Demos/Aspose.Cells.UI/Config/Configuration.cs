using System.Configuration;

namespace Aspose.Cells.UI.Config
{
    public static class Configuration
    {
        private static string _asposeReverseSearchApiURL = ConfigurationManager.AppSettings["AsposeReverseSearchAPIBasePath"];
        private static string _assetPath = ConfigurationManager.AppSettings["ASSETPATH"];
        private static string _gridWebCachePath = ConfigurationManager.AppSettings["GridWebCachePath"];
        private static string _gridWebFontFolderPath = ConfigurationManager.AppSettings["GridWebFontFolderPath"];
        private static string _appName = ConfigurationManager.AppSettings["AppName"];
        private static string _AsposeToolsAPIBasePath = ConfigurationManager.AppSettings["AsposeAppAPIBasePath"];
        private static int _smtpPort = int.Parse(ConfigurationManager.AppSettings["MailServerPort"]);
        private static string _smtpServer = ConfigurationManager.AppSettings["MailServer"];
        private static string _fromEmailAddress = ConfigurationManager.AppSettings["FromAddress"];
        private static string _mailServerUserId = ConfigurationManager.AppSettings["MailServerUserId"];
        private static string _mailServerUserPassword = ConfigurationManager.AppSettings["MailServerPassword"];
        private static int _mailServerTimeOut = int.Parse(ConfigurationManager.AppSettings["SmtpTimeOut"]);
        private static string _fileDownloadLink = ConfigurationManager.AppSettings["FileDownloadLink"];
        private static string _productsAsposeToolsURL = ConfigurationManager.AppSettings["ProductsAsposeAppURL"];
        private static string _fileViewLink = ConfigurationManager.AppSettings["FileViewLink"];

        //private static string _googleClientID = ConfigurationManager.AppSettings["GoogleClientID"];
        //private static string _googleAppID = ConfigurationManager.AppSettings["GoogleAppID"];
        //private static string _dropboxAppKey =  ConfigurationManager.AppSettings["DropboxAppKey"];
        private static string _productsAsposeAppAssetURL = ConfigurationManager.AppSettings["ProductsAsposeAppAssetURL"];

        private static string _resourceFileSessionName = ConfigurationManager.AppSettings["ResourceFileSessionName"];

        public static string OptimizationSEOUrl { get; set; } = ConfigurationManager.AppSettings["OptimizationSEOUrl"];
        public static string OptimizationSEOKey { get; set; } = ConfigurationManager.AppSettings["OptimizationSEOKey"];

        public static string ResourceFileSessionName => _resourceFileSessionName;
        //public static string DropboxAppKey
        //{
        //	get { return _dropboxAppKey; }
        //}
        //public static string GoogleClientID
        //{
        //	get { return _googleClientID; }
        //}
        //public static string GoogleAppID
        //{
        //	get { return _googleAppID; }
        //}

        public static string AsposeReverseSearchApiURL => _asposeReverseSearchApiURL;

        public static string ProductsAsposeToolsURL => _productsAsposeToolsURL;

        public static string ProductsAsposeAppAssetsURL => _productsAsposeAppAssetURL;

        public static string FileDownloadLink => _fileDownloadLink;

        public static int MailServerTimeOut => _mailServerTimeOut;

        public static string AssetPath => _assetPath;

        public static string GridWebCachePath => _gridWebCachePath;
        public static string GridWebFontFolderPath => _gridWebFontFolderPath;

        public static string AppName => _appName;

        public static string AsposeToolsAPIBasePath => _AsposeToolsAPIBasePath;

        public static int MailServerPort => _smtpPort;

        public static string MailServer => _smtpServer;

        public static string FromEmailAddress => _fromEmailAddress;

        public static string MailServerUserId => _mailServerUserId;

        public static string MailServerUserPassword => _mailServerUserPassword;

        public static string FileViewLink => _fileViewLink;
    }
}