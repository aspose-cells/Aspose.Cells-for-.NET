using System.Configuration;

namespace Aspose.Cells.API.Config
{
    /// <summary>
    /// Summary description for App Setting
    /// </summary>
    public static class AppSettings
    {
        private static string _filesBaseDirectory = ConfigurationManager.AppSettings["FilesBaseDirectory"];
        private static string _outputDirectory = ConfigurationManager.AppSettings["OutputDirectory"];
        private static string _workingDirectory = ConfigurationManager.AppSettings["WorkingDirectory"];
        private static string _reportDirectory = ConfigurationManager.AppSettings["ReportDirectory"];
        private static string _languageResourceFilePath = ConfigurationManager.AppSettings["LanguageResourceFilePath"];
        private static string _fontFolderPath = ConfigurationManager.AppSettings["FontFolderPath"];
        private static string _forumCategoryId = ConfigurationManager.AppSettings["ForumCategoryId"];
        private static string _forumUrl = ConfigurationManager.AppSettings["ForumUrl"];
        private static string _forumKey = ConfigurationManager.AppSettings["ForumKey"];

        /// <summary>
        /// Get Output Directory
        /// </summary>
        public static string OutputDirectory => _outputDirectory;

        /// <summary>
        /// Get Output Files Base Directory
        /// </summary>
        public static string FilesBaseDirectory => _filesBaseDirectory;

        /// <summary>
        /// Get Working Directory
        /// </summary>
        public static string WorkingDirectory => _workingDirectory;

        public static string ReportDirectory => _reportDirectory;

        /// <summary>
        /// Get Language Resource File Path
        /// </summary>
        public static string LanguageResourceFilePath => _languageResourceFilePath;

        /// <summary>
        /// Get Font Folder Path
        /// </summary>
        public static string FontFolderPath => _fontFolderPath;

        public static string ForumCategoryId => _forumCategoryId;

        public static string ForumUrl => _forumUrl;

        public static string ForumKey => _forumKey;
    }
}