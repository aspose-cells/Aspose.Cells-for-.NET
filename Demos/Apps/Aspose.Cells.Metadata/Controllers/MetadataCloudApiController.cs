using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Cells.Common.CloudHelper;
using Aspose.Cells.Common.Config;
using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Aspose.Cells.Common.Services;
using Aspose.Cells.Properties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Aspose.Cells.Metadata.Controllers
{
    public class MetadataCloudApiController : CellsCloudApiControllerBase
    {
        private const string AppName = "Metadata";

        public MetadataCloudApiController(IStorageService storage, IConfiguration configuration, ILogger<MetadataCloudApiController> logger) : base(storage, configuration, logger)
        {
        }

        [HttpPost]
        public async Task<ActionResult> Properties([FromBody] JObject obj)
        {
            Opts.AppName = "Metadata";
            Opts.MethodName = "Properties";
            Opts.FileName = Convert.ToString(obj["FileName"]);
            Opts.FolderName = Convert.ToString(obj["id"]);

            var interruptMonitor = new InterruptMonitor();
            var thread = new Thread(InterruptMonitor);
            try
            {
                var objectPath = $"{Configuration.SourceFolder}/{Opts.FolderName}/{Opts.FileName}";
                IDictionary<string, Stream> dictStreams = new Dictionary<string, Stream> ();
                dictStreams.Add(Opts.FileName, Storage.Download(objectPath).Result);
                CellsCloudClient cells = new CellsCloudClient();
                IList<CellsDocumentProperty> builtInDocumentProperties =  cells.GetMetadata(dictStreams, "BuiltIn").Result;
                IList<CellsDocumentProperty> customocumentProperties = cells.GetMetadata(dictStreams, "Custom").Result;

                return Ok(new CloudPropertiesResponse { BuiltIn = toDocProperties (builtInDocumentProperties), Custom = toDocProperties( customocumentProperties) });
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

                Logger.LogError("App = {App} | Method = {Method} | Message = {Message} | FileName = {FileName} | FolderName = {FolderName}",
                    AppName, "Properties", exception.Message, Convert.ToString(obj["FileName"]), Convert.ToString(obj["id"]));

                var response = new Response
                {
                    StatusCode = statusCode,
                    Status = exception.Message,
                    FolderName = Opts.FolderName,
                    Text = "Metadata Properties"
                };
                return BadRequest(response);
            }
            finally
            {
                thread.Interrupt();
            }
        }

        [HttpPost]
        public async Task<Response> Download([FromBody] JObject obj)
        {
            Opts.AppName = "Metadata";
            Opts.MethodName = "Download";

            var interruptMonitor = new InterruptMonitor();
            var thread = new Thread(InterruptMonitor);
            try
            {
                Opts.FileName = Convert.ToString(obj["FileName"]);
                Opts.ResultFileName = Opts.FileName;
                Opts.FolderName = Convert.ToString(obj["id"]);
                
                var (_, outFilePath) = BeforeAction();
                CellsCloudClient cellsCloudClient = new CellsCloudClient();
                var path = $"{Configuration.SourceFolder}/{Opts.FolderName}/{Opts.FileName}";
                var filenmae = $"{Opts.FileName}";
                IDictionary<string, Stream> files = new Dictionary<string, Stream>();
                files.Add(filenmae, Storage.Download(path).Result);
                CellsCloudFilesResult cellsCloudFilesResult = cellsCloudClient.PostMetadata(files, "BuildIn", obj["properties"]["BuiltIn"]?.ToObject<List<CellsDocumentProperty>>()).Result;
                cellsCloudFilesResult = cellsCloudClient.PostMetadata(cellsCloudFilesResult.Files.ToStream(), "Custom", obj["properties"]["Custom"]?.ToObject<List<CellsDocumentProperty>>()).Result;

                await Storage.UpdateStatus(Common.Models.Response.Process(Opts.FolderName, Opts.ResultFileName));

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Logger.LogWarning("AppName = {AppName} | MethodName = {MethodName} | Filename = {Filename} | Start",
                    AppName, Opts.MethodName, Opts.FileName);

               var response = await AfterAction(outFilePath,(Dictionary<string,Stream>) cellsCloudFilesResult.Files.ToStream());
                stopWatch.Stop();
                Logger.LogWarning("AppName = {AppName} | MethodName = {MethodName} | Filename = {Filename} | Cost Seconds = {Seconds}s",
                    AppName, Opts.MethodName, Opts.FileName, stopWatch.Elapsed.TotalSeconds);

                return response;
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                Logger.LogError("App = {App} | Method = {Method} | Message = {Message} | FileName = {FileName} | FolderName = {FolderName}",
                    AppName, "", exception.Message, Convert.ToString(obj["FileName"]), Convert.ToString(obj["id"]));

                return await Task.FromResult(new Response
                {
                    StatusCode = 500,
                    Status = exception.Message,
                    FolderName = Convert.ToString(obj["id"]),
                    Text = "Metadata Download"
                });
            }
            finally
            {
                thread.Interrupt();
            }
        }

        [HttpPost]
        public async Task<Response> Clear([FromBody] JObject obj)
        {
            Opts.AppName = "Metadata";
            Opts.MethodName = "Clear";

            var interruptMonitor = new InterruptMonitor();
            var thread = new Thread(InterruptMonitor);
            try
            {
                Opts.FileName = Convert.ToString(obj["FileName"]);
                Opts.ResultFileName = Opts.FileName;
                Opts.FolderName = Convert.ToString(obj["id"]);

                var (_, outFilePath) = BeforeAction();
                CellsCloudClient cellsCloudClient = new CellsCloudClient();
                var path = $"{Configuration.SourceFolder}/{Opts.FolderName}/{Opts.FileName}";
                var filenmae = $"{Opts.FileName}";
                IDictionary<string, Stream> files = new Dictionary<string, Stream>();
                files.Add(filenmae, Storage.Download(path).Result);
                CellsCloudFilesResult cellsCloudFilesResult = cellsCloudClient.DeleteMetadata(files, "ALL").Result;

                await Storage.UpdateStatus(Common.Models.Response.Process(Opts.FolderName, Opts.ResultFileName));

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Logger.LogWarning("AppName = {AppName} | MethodName = {MethodName} | Filename = {Filename} | Start",
                    AppName, Opts.MethodName, Opts.FileName);

                var response = await AfterAction(outFilePath, (Dictionary<string, Stream>)cellsCloudFilesResult.Files.ToStream());
                stopWatch.Stop();
                Logger.LogWarning("AppName = {AppName} | MethodName = {MethodName} | Filename = {Filename} | Cost Seconds = {Seconds}s",
                    AppName, Opts.MethodName, Opts.FileName, stopWatch.Elapsed.TotalSeconds);

                return response;
            }
            catch (Exception e)
            {
                Logger.LogError("AppName = {AppName} | MethodName = {MethodName} | Message = {Message} | Filename = {Filename} | FolderName = {FolderName}",
                    AppName, "Clear", e.Message, Convert.ToString(obj["FileName"]), Convert.ToString(obj["id"]));

                return await Task.FromResult(new Response
                {
                    StatusCode = 500,
                    Status = e.Message,
                    FolderName = Convert.ToString(obj["id"]),
                    Text = "Metadata Clear"
                });
            }
            finally
            {
                thread.Interrupt();
            }
        }


       
 
        private class CloudPropertiesResponse
        {
            public IList<DocProperty> BuiltIn { get; set; }
            public IList<DocProperty> Custom { get; set; }

            
        }

        private class DocProperty
        {
            public string Name { get; set; }
            public object Value { get; set; }
            public PropertyType Type { get; set; }
        }

        private IList<DocProperty> toDocProperties(IList<CellsDocumentProperty> cellsDocumentProperties)
        {
            IList<DocProperty> docProperties = new List<DocProperty>();

            foreach(var cellsDocumentProperty in cellsDocumentProperties)
            {
                DocProperty docProperty = new DocProperty();
                docProperty.Name = cellsDocumentProperty.Name;
                docProperty.Value = cellsDocumentProperty.Value;
                docProperty.Type  = string.IsNullOrEmpty(cellsDocumentProperty.Type)? PropertyType.String: Enum.Parse<PropertyType>(cellsDocumentProperty.Type);
                docProperties.Add(docProperty);
            }
            return docProperties;
        }
    }
}