using Microsoft.Extensions.Logging;
using System;

namespace Aspose.Cells.Common.Config
{
    public static class LoggerExtensions
    {
        private static readonly Action<ILogger, string, Exception> applicationStarting = LoggerMessage.Define<string>(
            eventId: LoggerEventIds.ApplicationStarting,
            logLevel: LogLevel.Information,
            formatString: "Starting application ({ApplicationId})");

        private static readonly Action<ILogger, string, Exception> applicationShutdown = LoggerMessage.Define<string>(
            eventId: LoggerEventIds.ApplicationShutdown,
            logLevel: LogLevel.Information,
            formatString: "Application ({ApplicationId}) shutdown");

        private static readonly Action<ILogger, string, Exception> applicationTerminatedException = LoggerMessage.Define<string>(
            eventId: LoggerEventIds.ApplicationTerminatedException,
            logLevel: LogLevel.Critical,
            formatString: "Application ({ApplicationId}) terminated unexpectedly!");

        private static readonly Action<ILogger, string, Exception> applicationVersion = LoggerMessage.Define<string>(
            eventId: LoggerEventIds.ApplicationInformation,
            logLevel: LogLevel.Information,
            formatString: "Application Version: {ApplicationVersion}");

        private static readonly Action<ILogger, string, Exception> applicationEnvironment = LoggerMessage.Define<string>(
            eventId: LoggerEventIds.ApplicationInformation,
            logLevel: LogLevel.Information,
            formatString: "Hosting environment: {ApplicationEnvironment}");

        private static readonly Action<ILogger, string, string, string, Exception> fileUploading = LoggerMessage.Define<string, string, string>(
            eventId: LoggerEventIds.FileUploading,
            logLevel: LogLevel.Debug,
            formatString: "Uploading file ({OriginalFileName}) of ({ContentType}) type {hasPassword}");

        private static readonly Action<ILogger, string, string, double, Exception> fileUploaded = LoggerMessage.Define<string, string, double>(
            eventId: LoggerEventIds.FileUploaded,
            logLevel: LogLevel.Information,
            formatString: "File ({OriginalFileName}) uploaded as ({FileName}) after {ElapsedMilliseconds}ms");

        private static readonly Action<ILogger, string, double, Exception> fileUploadingError = LoggerMessage.Define<string, double>(
            eventId: LoggerEventIds.FileUploadingError,
            logLevel: LogLevel.Error,
            formatString: "File ({FileName}) uploading was failed after {ElapsedMilliseconds}ms");

        private static readonly Action<ILogger, string, double, Exception> fileSaveError = LoggerMessage.Define<string, double>(
            eventId: LoggerEventIds.FileSaveError,
            logLevel: LogLevel.Error,
            formatString: "File ({FileName}) save to local was failed after {ElapsedMilliseconds}ms");

        private static readonly Action<ILogger, string, Exception> fileDownloading = LoggerMessage.Define<string>(
            eventId: LoggerEventIds.FileDownloading,
            logLevel: LogLevel.Information,
            formatString: "Downloading file {FileName}");

        private static readonly Action<ILogger, string, double, Exception> fileDownloadingError = LoggerMessage.Define<string, double>(
            eventId: LoggerEventIds.FileDownloadingError,
            logLevel: LogLevel.Error,
            formatString: "File ({FileName}) downloading failed after {ElapsedMilliseconds}ms");

        private static readonly Action<ILogger, string, double, Exception> fileCreateTempDirectoryError = LoggerMessage.Define<string, double>(
            eventId: LoggerEventIds.FileCreateTempDirectoryError,
            logLevel: LogLevel.Error,
            formatString: "Folder ({FileName}) creating failed after {ElapsedMilliseconds}ms");

        private static readonly Action<ILogger, string, double, Exception> fileCreateZipError = LoggerMessage.Define<string, double>(
            eventId: LoggerEventIds.FileCreateZipError,
            logLevel: LogLevel.Error,
            formatString: "File ({FileName}) creating failed after {ElapsedMilliseconds}ms");

        private static readonly Action<ILogger, string, string, Exception> fileWrongExtension = LoggerMessage.Define<string, string>(
            eventId: LoggerEventIds.FileInvalidExtension,
            logLevel: LogLevel.Error,
            formatString: "Uploading file ({FileName}) with wrong extension. Should be ({InputType})");

        private static readonly Action<ILogger, string, Exception> directoryDeleteError = LoggerMessage.Define<string>(
            eventId: LoggerEventIds.DirectoryDeleteError,
            logLevel: LogLevel.Error,
            formatString: "Can not delete directory ({FolderName})");

        private static readonly Action<ILogger, string, string, Exception> fileMoveError = LoggerMessage.Define<string, string>(
            eventId: LoggerEventIds.DirectoryDeleteError,
            logLevel: LogLevel.Error,
            formatString: "Can not move file ({fileName}) to ({destinationFolder})");

        private static readonly Action<ILogger, Exception> awsUploadStatusError = LoggerMessage.Define(
            eventId: LoggerEventIds.AWSUploadStatusError,
            logLevel: LogLevel.Error,
            formatString: "Can not change upload status on aws");

        private static readonly Action<ILogger, Exception> lockEncryptError = LoggerMessage.Define(
            eventId: LoggerEventIds.LockEncryptError,
            logLevel: LogLevel.Error,
            formatString: "Can not encrypt file");

        private static readonly Action<ILogger, Exception> emailSendError = LoggerMessage.Define(
            eventId: LoggerEventIds.EmailSendError,
            logLevel: LogLevel.Error,
            formatString: "Email not sent");

        private static readonly Action<ILogger, Exception> feedbackSendError = LoggerMessage.Define(
            eventId: LoggerEventIds.FeedbackSendError,
            logLevel: LogLevel.Error,
            formatString: "Feedback not sent");

        public static void ApplicationStarting(this ILogger logger, string applicationId)
        {
            applicationStarting(logger, applicationId, null);
        }

        public static void ApplicationShutdown(this ILogger logger, string applicationId)
        {
            applicationShutdown(logger, applicationId, null);
        }

        public static void ApplicationTerminatedException(this ILogger logger, string applicationId, Exception exception)
        {
            applicationTerminatedException(logger, applicationId, exception);
        }

        public static void ApplicationVersion(this ILogger logger, string version)
        {
            applicationVersion(logger, version, null);
        }

        public static void ApplicationEnvironment(this ILogger logger, string environment)
        {
            applicationEnvironment(logger, environment, null);
        }

        public static void FileUploading(this ILogger logger, string[] fileNames, string contentType, bool hasPassword)
        {
            fileUploading(logger, string.Join(", ", fileNames), contentType, hasPassword ? "has password" : "", null);
        }

        public static void FileUploaded(this ILogger logger, string[] fileNames, string fileLink, TimeSpan duration)
        {
            fileUploaded(logger, string.Join(", ", fileNames), fileLink, duration.TotalMilliseconds, null);
        }

        public static void FileUploadingError(this ILogger logger, string[] fileNames, TimeSpan duration, Exception exception)
        {
            fileUploadingError(logger, string.Join(", ", fileNames), duration.TotalMilliseconds, exception);
        }

        public static void FileSaveError(this ILogger logger, string fileName, TimeSpan duration, Exception exception)
        {
            fileSaveError(logger, fileName, duration.TotalMilliseconds, exception);
        }

        public static void FileDownloading(this ILogger logger, string fileName)
        {
            fileDownloading(logger, fileName, null);
        }

        public static void FileDownloadingError(this ILogger logger, string fileName, TimeSpan duration, Exception exception)
        {
            fileDownloadingError(logger, fileName, duration.TotalMilliseconds, exception);
        }

        public static void FileCreateTempDirectoryError(this ILogger logger, string fileName, TimeSpan duration, Exception exception)
        {
            fileCreateTempDirectoryError(logger, fileName, duration.TotalMilliseconds, exception);
        }

        public static void FileCreateZipError(this ILogger logger, string fileName, TimeSpan duration, Exception exception)
        {
            fileCreateZipError(logger, fileName, duration.TotalMilliseconds, exception);
        }

        public static void FileWrongExtension(this ILogger logger, string fileName, string inputType)
        {
            fileWrongExtension(logger, fileName, inputType, null);
        }

        public static void DirectoryDeleteError(this ILogger logger, string folderName, Exception exception)
        {
            directoryDeleteError(logger, folderName, exception);
        }

        public static void FileMoveError(this ILogger logger, string fileName, string destinationFolder, Exception exception)
        {
            fileMoveError(logger, fileName, destinationFolder, exception);
        }

        public static void AWSUploadStatusError(this ILogger logger, Exception exception)
        {
            awsUploadStatusError(logger, exception);
        }

        public static void LockEncryptError(this ILogger logger, Exception ex)
        {
            lockEncryptError(logger, ex);
        }

        public static void EmailSendError(this ILogger logger, Exception ex)
        {
            emailSendError(logger, ex);
        }

        public static void FeedbackSendError(this ILogger logger, Exception ex)
        {
            feedbackSendError(logger, ex);
        }
    }

    static class LoggerEventIds
    {
        // Application Core EventIds: 1 - 99
        public static readonly EventId ApplicationStarting = new EventId(1, "ApplicationStarting");
        public static readonly EventId ApplicationShutdown = new EventId(2, "ApplicationShutdown");
        public static readonly EventId ApplicationTerminatedException = new EventId(3, "ApplicationTerminatedException");
        public static readonly EventId ApplicationError = new EventId(4, "ApplicationError");
        public static readonly EventId ApplicationInformation = new EventId(5, "ApplicationInformation");

        // File EventIds: 100 - 199
        public static readonly EventId FileUploading = new EventId(100, "FileUploading");
        public static readonly EventId FileUploaded = new EventId(101, "FileUploaded");
        public static readonly EventId FileUploadingError = new EventId(102, "FileUploadingError");
        public static readonly EventId FileDownloading = new EventId(103, "FileDownloading");
        public static readonly EventId FileDownloadingError = new EventId(104, "FileDownloadingError");
        public static readonly EventId FileCreateTempDirectoryError = new EventId(105, "FileCreateTempDirectoryError");
        public static readonly EventId FileCreateZipError = new EventId(106, "FileCreateZipError");
        public static readonly EventId FileSaveError = new EventId(107, "FileSaveError");
        public static readonly EventId FileInvalidExtension = new EventId(108, "FileInvalidExtensionError");
        public static readonly EventId DirectoryDeleteError = new EventId(109, "DirectoryDeleteError");
        public static readonly EventId FileMoveError = new EventId(110, "FileMoveError");
        public static readonly EventId AWSUploadStatusError = new EventId(111, "AWSUploadStatusError");
        public static readonly EventId AWSFileDeleteError = new EventId(112, "AWSFileDeleteError");

        public static readonly EventId LockEncryptError = new EventId(1200, "LockEncryptError");
        public static readonly EventId EmailSendError = new EventId(908, "EmailSendError");
        public static readonly EventId FeedbackSendError = new EventId(909, "FeedbackSendError");
    }
}