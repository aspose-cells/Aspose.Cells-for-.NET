

namespace Aspose.Cells.Common.CloudHelper
{
    using Aspose.Cells.Common.Config;
    using Aspose.Cells.Common.Controllers;
    using Aspose.Cells.Common.Models;
    using Aspose.Cells.Common.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public class CellsCloudApiControllerBase : CellsApiControllerBase
    {
        public CellsCloudApiControllerBase(IStorageService storage, IConfiguration configuration, ILogger<CellsCloudApiControllerBase> logger) : base(storage, configuration, logger)
        {

        }

        protected async Task<IDictionary<string, Stream>> UploadFiles(string sessionId, string appName)
        {
            var duration = Stopwatch.StartNew();
            var sourceKeyLs = new List<string>();
            IDictionary<string, Stream> keyValues = new Dictionary<string, Stream>();
            try
            {
                IEnumerable<IFormFile> uploadProvider = HttpContext.Request.Form.Files;

                var form = await HttpContext.Request.ReadFormAsync();
                var service = new WebClientService();
                var internalService = new InternalLinkService(Storage);
                var files = await Task.WhenAll(
                    form
                        .Where(item =>
                            Uri.IsWellFormedUriString(item.Value, UriKind.Absolute))
                        .AsParallel()
                        .Where(item =>
                            item.Key.StartsWith("link_"))
                        .Select(async item => await service.Upload(item.Value)));

                var internalFiles = await Task.WhenAll(
                    form
                        .Where(item => Uri.IsWellFormedUriString(item.Value, UriKind.Relative))
                        .AsParallel()
                        .Where(item =>
                            item.Key.StartsWith("link_"))
                        .Select(async item => await internalService.Upload(item.Value)));

                uploadProvider = uploadProvider.Union(files.Union(internalFiles).Where(f => f != null).ToArray());

                var formFiles = uploadProvider.ToList();
                Logger.FileUploading(formFiles.Select(x => x.FileName).ToArray(), "", false);

                foreach (var formFile in formFiles)
                {
                    await using var memoryStream = new MemoryStream();
                    await formFile.CopyToAsync(memoryStream);
                    await using (var stream = new MemoryStream())
                    {
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        await memoryStream.CopyToAsync(stream);

                        // upload source files to AWS S3
                        var objectPath = $"{Configuration.SourceFolder}/{sessionId}/{formFile.FileName}";
                        sourceKeyLs.Add(objectPath);
                        await Storage.Upload(objectPath, stream, new AwsMetaInfo
                        {
                            OriginalFileName = formFile.FileName,
                            Title = formFile.FileName
                        });
                    }

                    memoryStream.Seek(0, SeekOrigin.Begin);
                    MemoryStream fileStream = new MemoryStream();
                    memoryStream.CopyTo(fileStream);
                    fileStream.Seek(0, SeekOrigin.Begin);
                    keyValues.Add(formFile.FileName, fileStream);
                }

                Logger.FileUploaded(formFiles.Select(x => x.FileName).ToArray(), "", duration.Elapsed);
                return keyValues;
            }
            catch (CellsException e)
            {
                if (e.Code != ExceptionType.IncorrectPassword)
                {
                    foreach (var sourceKey in sourceKeyLs)
                    {
                        var destinationKey = sourceKey.Replace(Configuration.SourceFolder, $"{Configuration.ErrorFolder}/{appName}");
                        await Storage.CopyingObjectAsync(sourceKey, destinationKey);
                    }

                    if (e.Code == ExceptionType.Interrupted)
                    {
                        Logger.LogError("UploadWorkbooks {SessionId}=>{ProcessingTimeout}", sessionId, Configuration.ProcessingTimeout);
                        throw new TimeoutException(Configuration.ProcessingTimeout);
                    }
                }

                Logger.FileUploadingError(HttpContext.Request?.Form?.Files?.Select(x => x.FileName).ToArray(), duration.Elapsed, e);
                if (string.IsNullOrEmpty(e.Message))
                    throw new Exception("Invalid file, please ensure that uploading correct file");
                throw;
            }
            catch (Exception e)
            {
                foreach (var sourceKey in sourceKeyLs)
                {
                    var destinationKey = sourceKey.Replace(Configuration.SourceFolder, $"{Configuration.ErrorFolder}/{appName}");
                    await Storage.CopyingObjectAsync(sourceKey, destinationKey);
                }

                Logger.FileUploadingError(HttpContext.Request?.Form?.Files?.Select(x => x.FileName).ToArray(), duration.Elapsed, e);
                if (string.IsNullOrEmpty(e.Message))
                    throw new Exception("Invalid file, please ensure that uploading correct file");
                throw;
            }
        }


        protected DocumentInfo[] GetDocumentInfos(IDictionary<string, Stream> keyValues, string sessionId)
        {
            DocumentInfo[] documentInfos = new DocumentInfo[keyValues.Count];
            int pos = 0;
            foreach (KeyValuePair<string, Stream> keyValuePair in keyValues)
            {
                documentInfos[pos] = new DocumentInfo { FileName = keyValuePair.Key, FolderName = sessionId };
                pos++;
            }
            return documentInfos;
        }


        protected async Task<Response>  RunBusinessCode( Func<IDictionary<string, Stream> , string, string ,Task<Response> > action ,string AppName,string outputType)
        {
            var sessionId = Guid.NewGuid().ToString();

            try
            {
                var taskUpload = Task.Run(() => UploadFiles(sessionId, AppName));
                taskUpload.Wait(Configuration.MillisecondsTimeout);
                if (!taskUpload.IsCompleted)
                {
                    Logger.LogError(
                        "{AppName} UploadFiles=>{SessionId}=>{Timeout}",
                        AppName,
                        sessionId,
                        Configuration.ProcessingTimeout);
                    throw new TimeoutException(Configuration.ProcessingTimeout);
                }

                var docs = taskUpload.Result;
                if (docs == null)
                    return PasswordProtectedResponse;
                if (docs.Count == 0 || docs.Count > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;
                SetDefaultOptions(GetDocumentInfos(docs, sessionId));

                Opts.FolderName = sessionId;

                await Storage.UpdateStatus(Common.Models.Response.Process(Opts.FolderName, Opts.ResultFileName));

                var stopWatch = new Stopwatch();

                stopWatch.Start();
                Logger.LogWarning(
                    "AppName = {AppName} | Filename = {Filename} | Start",
                    AppName,
                    string.Join(",", docs.Select(t => t.Key)));

                var taskProcessCellsBlock = action(docs, sessionId, outputType);
                taskProcessCellsBlock.Wait(Configuration.MillisecondsTimeout);
                if (!taskProcessCellsBlock.IsCompleted)
                {
                    Logger.LogError(
                        "{AppName} ProcessCellsBlock=>{SessionId}=>{Timeout}",
                        AppName,
                        sessionId,
                        Configuration.ProcessingTimeout);
                    throw new TimeoutException(Configuration.ProcessingTimeout);
                }

                stopWatch.Stop();
                Logger.LogWarning(
                    "AppName = {AppName} | Filename = {Filename} | Cost Seconds = {Seconds}ms",
                    AppName,
                    string.Join(",", docs.Select(t => t.Key)),
                    stopWatch.Elapsed.TotalSeconds);

                if (!taskProcessCellsBlock.IsFaulted && taskProcessCellsBlock.Exception == null)
                    return taskProcessCellsBlock.Result;

                return Common.Models.Response.Error(Opts.FolderName, Opts.ResultFileName, taskProcessCellsBlock.Exception?.Message ?? "500");
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                var statusCode = 500;
                if (exception is CellsException { Code: ExceptionType.IncorrectPassword })
                {
                    statusCode = 403;
                }

                Logger.LogError("AppName = {AppName} | Message = {Message} | OutputType = {OutputType}",
                    AppName, exception.Message, outputType);

                return new Response
                {
                    StatusCode = statusCode,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = AppName
                };
            }
        }
    }
}
