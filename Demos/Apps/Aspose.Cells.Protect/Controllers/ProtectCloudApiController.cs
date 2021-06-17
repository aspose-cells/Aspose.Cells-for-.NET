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
    public class ProtectCloudApiController : CellsCloudApiControllerBase
    {
        private const string AppName = "Protect";
        public ProtectCloudApiController(IStorageService storage, IConfiguration configuration, ILogger<ProtectCloudApiController> logger) : base(storage, configuration, logger)
        {
        }

        [HttpPost]
        public async Task<Response> Protect(string password)
        {

            return await RunBusinessCode(async (IDictionary<string, Stream> docs, string sessionId, string password) =>
            {
                var streams = new Dictionary<string, Stream>();
                var (_, outFilePath) = BeforeAction();
                var catchException = false;
                var exception = new Exception();
                Opts.AppName = "Protect";
                Opts.MethodName = "Protect";
                Opts.ZipFileName = "Protected files";

                try
                {
                    CellsCloudClient cells = new CellsCloudClient();
                    var value =cells.Protect(docs, password);
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
            }, AppName, password);

        }
    }
}