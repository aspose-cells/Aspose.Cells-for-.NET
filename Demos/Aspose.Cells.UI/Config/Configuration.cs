using System.Configuration;

namespace Aspose.Cells.UI.Config
{
    public static class Configuration
    {
        public static string ResourceFileSessionName { get; } = ConfigurationManager.AppSettings["ResourceFileSessionName"];

        public static string ProductsAsposeToolsURL { get; } = ConfigurationManager.AppSettings["ProductsAsposeAppURL"];

        public static string FileDownloadLink { get; } = ConfigurationManager.AppSettings["FileDownloadLink"];

        public static int MailServerTimeOut { get; } = int.Parse(ConfigurationManager.AppSettings["SmtpTimeOut"]);

        public static string AsposeToolsAPIBasePath { get; } = ConfigurationManager.AppSettings["AsposeAppAPIBasePath"];

        public static int MailServerPort { get; } = int.Parse(ConfigurationManager.AppSettings["MailServerPort"]);

        public static string MailServer { get; } = ConfigurationManager.AppSettings["MailServer"];

        public static string FromEmailAddress { get; } = ConfigurationManager.AppSettings["FromAddress"];

        public static string MailServerUserId { get; } = ConfigurationManager.AppSettings["MailServerUserId"];

        public static string MailServerUserPassword { get; } = ConfigurationManager.AppSettings["MailServerPassword"];

        public static string FileViewLink { get; } = ConfigurationManager.AppSettings["FileViewLink"];
    }
}