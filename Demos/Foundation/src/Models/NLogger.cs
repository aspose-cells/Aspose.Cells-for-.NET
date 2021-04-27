using NLog;

namespace Tools.Foundation.Models
{
    public static class NLogger
    {
        private static readonly Logger DatabaseLogger = LogManager.GetLogger("databaseLogger");

        public static void LogInfo(string message)
        {
            DatabaseLogger.Info(message);
        }

        public static void LogError(string message)
        {
            DatabaseLogger.Error(message);
        }

        public static void LogError(string app, string method, string message, string folder)
        {
            var error = $"App = {app} | Method = {method} | Message = {message} | Folder = {folder}";
            DatabaseLogger.Error(error);
        }
    }
}