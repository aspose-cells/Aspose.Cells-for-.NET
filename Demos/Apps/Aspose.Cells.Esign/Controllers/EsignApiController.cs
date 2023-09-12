using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Cells.Common.Config;
using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Aspose.Cells.Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Esign.Controllers
{
    public class EsignApiController : CellsApiControllerBase
    {
        private const string AppName = "Esign";

        public EsignApiController(IStorageService storage, IConfiguration configuration, ILogger<EsignApiController> logger) : base(storage, configuration, logger)
        {
        }
        
        [HttpPost]
        public async Task<Response> Esign()
        {
            var sessionId = Guid.NewGuid().ToString();

            var streams = new Dictionary<string, Stream>();

            var form = await HttpContext.Request.ReadFormAsync();
            IEnumerable<IFormFile> uploadProvider = form.Files;

            uploadProvider = uploadProvider.Union(await UploadLinks());
            var formFiles = uploadProvider.ToList();

            var excelFormFile = formFiles.First();
            var certFormFile = formFiles.Last();
            var password = form["password"].ToString();

            var excelFileName = excelFormFile.FileName;
            var outFileName = $"{Path.GetFileNameWithoutExtension(excelFileName)}.xlsx";
            var outFilePath = $"{sessionId}/{outFileName}";

            Opts.FolderName = sessionId;
            Opts.ResultFileName = outFileName;

            await Storage.UpdateStatus(Common.Models.Response.Process(sessionId, outFileName));

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Logger.FileUploading(formFiles.Select(x => x.FileName).ToArray(), "", false);

            await using var excelStream = new MemoryStream();
            await excelFormFile.CopyToAsync(excelStream);
            await using (var ms = new MemoryStream())
            {
                excelStream.Seek(0, SeekOrigin.Begin);
                await excelStream.CopyToAsync(ms);

                var objectPath = $"{Configuration.SourceFolder}/{sessionId}/{excelFileName}";
                await Storage.Upload(objectPath, ms, new AwsMetaInfo
                {
                    OriginalFileName = excelFileName,
                    Title = excelFileName
                });
            }

            await using var certStream = new MemoryStream();
            await certFormFile.CopyToAsync(certStream);
            await using (var ms = new MemoryStream())
            {
                var certFileName = certFormFile.FileName;
                certStream.Seek(0, SeekOrigin.Begin);
                await certStream.CopyToAsync(ms);

                var objectPath = $"{Configuration.SourceFolder}/{sessionId}/{certFileName}";
                await Storage.Upload(objectPath, ms, new AwsMetaInfo
                {
                    OriginalFileName = certFileName,
                    Title = certFileName
                });
            }

            stopWatch.Stop();
            Logger.FileUploaded(formFiles.Select(x => x.FileName).ToArray(), "", stopWatch.Elapsed);

            var interruptMonitor = new InterruptMonitor();
            var thread = new Thread(InterruptMonitor);
            try
            {
                thread.Start(new object[] { interruptMonitor, Configuration.MillisecondsTimeout, excelFileName });
                var loadOptions = GetLoadOptionsByExtension(Path.GetExtension(excelFileName), interruptMonitor);

                var fileLength = excelFormFile.Length / 1024.0 / 1024.0;
                if (fileLength > 5) loadOptions.MemorySetting = MemorySetting.MemoryPreference;

                using var workbook = new Workbook(excelStream, loadOptions);

                var dsCollection = new DigitalSignatures.DigitalSignatureCollection();

                var certificate = new System.Security.Cryptography.X509Certificates.X509Certificate2(certStream.GetBuffer(), password);

                var signature = new DigitalSignatures.DigitalSignature(certificate, "", DateTime.Now);
                dsCollection.Add(signature);

                workbook.AddDigitalSignature(dsCollection);

                var outStream = new MemoryStream();
                workbook.Save(outStream, SaveFormat.Xlsx);

                streams.Add(outFileName, outStream);
                return await AfterAction(outFilePath, streams);
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                var statusCode = 500;
                if (exception is CellsException {Code: ExceptionType.IncorrectPassword})
                {
                    statusCode = 403;
                }

                if (exception is CellsException {Code: ExceptionType.FileFormat})
                {
                    statusCode = 415;
                }

                Logger.LogError("AppName = {AppName} | Message = {Message} | Password = {Password}",
                    AppName, exception.Message );

                return new Response
                {
                    StatusCode = statusCode,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = AppName
                };
            }
            finally
            {
                thread.Interrupt();
            }
        }
    }
}