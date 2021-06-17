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
    public class WatermarkCloudApiController : CellsCloudApiControllerBase
    {
        private const string AppName = "Watermark";
        public WatermarkCloudApiController(IStorageService storage, IConfiguration configuration, ILogger<WatermarkCloudApiController> logger) : base(storage, configuration, logger)
        {
        }

        [HttpPost]
        [ActionName("AddTextWatermark")]
        public async Task<Response> AddTextWatermark(string watermarkText, string watermarkColor,string outputType=null)
        {

            return await RunBusinessCode(async (IDictionary<string, Stream> docs, string sessionId,string format ) =>
            {
                var streams = new Dictionary<string, Stream>();
                var (_, outFilePath) = BeforeAction();
                var catchException = false;
                var exception = new Exception();
                Opts.AppName = AppName;
                Opts.MethodName = "AddTextWatermark";
                Opts.ZipFileName = "Watermark files";

                try
                {
                    CellsCloudClient cells = new CellsCloudClient();
                    var value =cells.WaterMarker(docs, watermarkText, watermarkColor);
                    foreach( CellsCloudFileInfo cellsCloudFileInfo in value.Result.Files)
                    {
                        streams.Add(cellsCloudFileInfo.Filename, new MemoryStream(System.Convert.FromBase64String(cellsCloudFileInfo.FileContent)));
                    }                   

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
                }

                if (!catchException)
                    return await AfterAction(outFilePath, streams);

                await Storage.UpdateStatus(Common.Models.Response.Error(Opts.FolderName, Opts.ResultFileName, exception.Message));
                throw exception;
            }, AppName, outputType);

        }
    }
}