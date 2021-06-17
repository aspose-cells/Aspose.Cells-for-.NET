using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Cells.Common.CloudHelper;
using Aspose.Cells.Common.Config;
using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Aspose.Cells.Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Conversion.Controllers
{
    public class ConversionCloudApiController : CellsCloudApiControllerBase
    {
        private const string AppName = "Conversion";
        //private ICellsCloudService _cellsService;
        public ConversionCloudApiController(IStorageService storage, IConfiguration configuration, ILogger<ConversionCloudApiController> logger) : base(storage, configuration, logger)
        {
            //_cellsService = cellsService;
        }

        [HttpPost]
        public async Task<Response> Convert(string outputType)
        {
            return await RunBusinessCode(async (IDictionary<string, Stream> docs, string sessionId, string outputType) =>
           {
               var streams = new Dictionary<string, Stream>();
               var (_, outFilePath) = BeforeAction();
               var catchException = false;
               var exception = new Exception();
               Opts.AppName = "Conversion";
               Opts.MethodName = "Convert";
               Opts.ZipFileName = "Converted files";
               CellsCloudClient cells = new CellsCloudClient();

               foreach (var doc in docs)
               {
                   try
                   {
                       //var value = _cellsService.Convert(sessionId, token,doc.Key, doc.Value, Opts.OutputType).Result;
                       var value = cells.Convert(doc.Key, doc.Value, outputType).Result;
                       streams.Add(Path.GetFileNameWithoutExtension(doc.Key) + Opts.OutputType, value);
                   }
                   catch (Exception e)
                   {
                       catchException = true;

                       foreach (var (_, stream) in streams)
                       {
                           stream.Close();
                       }

                       await UploadErrorFiles(GetDocumentInfos(docs, sessionId), AppName);

                       exception = e.InnerException ?? e;
                       Logger.LogError("{Message}", exception.Message);
                       break;
                   }
               }

               if (!catchException)
                   return await AfterAction(outFilePath, streams);

               await Storage.UpdateStatus(Common.Models.Response.Error(Opts.FolderName, Opts.ResultFileName, exception.Message));
               throw exception;
           }, AppName, outputType);


            //var sessionId = Guid.NewGuid().ToString();

            //try
            //{
            //    var taskUpload = Task.Run(() => UploadFiles(sessionId, AppName));
            //    taskUpload.Wait(Configuration.MillisecondsTimeout);
            //    if (!taskUpload.IsCompleted)
            //    {
            //        Logger.LogError(
            //            "{AppName} UploadFiles=>{SessionId}=>{Timeout}",
            //            AppName,
            //            sessionId,
            //            Configuration.ProcessingTimeout);
            //        throw new TimeoutException(Configuration.ProcessingTimeout);
            //    }

            //    var docs = taskUpload.Result;
            //    if (docs == null)
            //        return PasswordProtectedResponse;
            //    if (docs.Count == 0 || docs.Count > MaximumUploadFiles)
            //        return MaximumFileLimitsResponse;
            //    SetDefaultOptions(GetDocumentInfos(docs,sessionId));
            //    Opts.AppName = "Conversion";
            //    Opts.MethodName = "Convert";
            //    Opts.ZipFileName = "Converted files";
            //    Opts.FolderName = sessionId;

            //    await Storage.UpdateStatus(Common.Models.Response.Process(Opts.FolderName, Opts.ResultFileName));

            //    var stopWatch = new Stopwatch();

            //    stopWatch.Start();
            //    Logger.LogWarning(
            //        "AppName = {AppName} | Filename = {Filename} | Start",
            //        AppName,
            //        string.Join(",", docs.Select(t => t.Key)));

            //    var taskProcessCellsBlock = ProcessCellsBlock(docs, sessionId, outputType);
            //    taskProcessCellsBlock.Wait(Configuration.MillisecondsTimeout);
            //    if (!taskProcessCellsBlock.IsCompleted)
            //    {
            //        Logger.LogError(
            //            "{AppName} ProcessCellsBlock=>{SessionId}=>{Timeout}",
            //            AppName,
            //            sessionId,
            //            Configuration.ProcessingTimeout);
            //        throw new TimeoutException(Configuration.ProcessingTimeout);
            //    }

            //    stopWatch.Stop();
            //    Logger.LogWarning(
            //        "AppName = {AppName} | Filename = {Filename} | Cost Seconds = {Seconds}ms",
            //        AppName,
            //        string.Join(",", docs.Select(t => t.Key)),
            //        stopWatch.Elapsed.TotalSeconds);

            //    if (!taskProcessCellsBlock.IsFaulted && taskProcessCellsBlock.Exception == null)
            //        return taskProcessCellsBlock.Result;

            //    return Common.Models.Response.Error(Opts.FolderName, Opts.ResultFileName, taskProcessCellsBlock.Exception?.Message ?? "500");
            //}
            //catch (Exception e)
            //{
            //    var exception = e.InnerException ?? e;
            //    var statusCode = 500;
            //    if (exception is CellsException {Code: ExceptionType.IncorrectPassword})
            //    {
            //        statusCode = 403;
            //    }

            //    Logger.LogError("AppName = {AppName} | Message = {Message} | OutputType = {OutputType}",
            //        AppName, exception.Message, outputType);

            //    return new Response
            //    {
            //        StatusCode = statusCode,
            //        Status = exception.Message,
            //        FolderName = sessionId,
            //        Text = AppName
            //    };
            //}
        }


    }

        //    private async Task<Response> ProcessCellsBlock(IDictionary<string, Stream> docs,string sessionId, string outputType)
        //    {
        //        var streams = new Dictionary<string, Stream>();
        //        var (_, outFilePath) = BeforeAction();
        //        var catchException = false;
        //        var exception = new Exception();

        //        CellsCloudClient cells = new CellsCloudClient();

        //        foreach (var doc in docs)
        //        {
        //            try
        //            {
        //                //var value = _cellsService.Convert(sessionId, token,doc.Key, doc.Value, Opts.OutputType).Result;
        //                var value = cells.Convert(doc.Key, doc.Value, outputType).Result;
        //                streams.Add(Path.GetFileNameWithoutExtension(doc.Key) + Opts.OutputType, value);
        //            }
        //            catch (Exception e)
        //            {
        //                catchException = true;

        //                foreach (var (_, stream) in streams)
        //                {
        //                    stream.Close();
        //                }

        //                await UploadErrorFiles(GetDocumentInfos(docs, sessionId), AppName);

        //                exception = e.InnerException ?? e;
        //                Logger.LogError("{Message}", exception.Message);
        //                break;
        //            }
        //        }

        //        if (!catchException)
        //            return await AfterAction(outFilePath, streams);

        //        await Storage.UpdateStatus(Common.Models.Response.Error(Opts.FolderName, Opts.ResultFileName, exception.Message));
        //        throw exception;
        //    }
        //}
    }
