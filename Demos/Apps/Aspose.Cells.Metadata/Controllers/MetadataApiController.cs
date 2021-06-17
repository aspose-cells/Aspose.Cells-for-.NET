using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
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
    public class MetadataApiController : CellsApiControllerBase
    {
        private const string AppName = "Metadata";

        public MetadataApiController(IStorageService storage, IConfiguration configuration, ILogger<MetadataApiController> logger) : base(storage, configuration, logger)
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
                thread.Start(new object[] {interruptMonitor, Configuration.MillisecondsTimeout, Opts.FileName});
                var workbook = await GetWorkbook(interruptMonitor);
                return Ok(new PropertiesResponse(workbook));
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

                thread.Start(new object[] {interruptMonitor, Configuration.MillisecondsTimeout, Opts.FileName});
                var workbook = await GetWorkbook(interruptMonitor);

                var pars = obj["properties"]["BuiltIn"]?.ToObject<List<DocProperty>>();
                SetBuiltInProperties(workbook, pars);
                pars = obj["properties"]["Custom"]?.ToObject<List<DocProperty>>();
                SetCustomProperties(workbook, pars);

                var doc = new DocumentInfo {Workbook = workbook, FileName = Opts.FileName, FolderName = Opts.FolderName};

                await Storage.UpdateStatus(Common.Models.Response.Process(Opts.FolderName, Opts.ResultFileName));

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Logger.LogWarning("AppName = {AppName} | MethodName = {MethodName} | Filename = {Filename} | Start",
                    AppName, Opts.MethodName, Opts.FileName);

                var response = await ProcessCellsBlock(new[] {doc});

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

                thread.Start(new object[] {interruptMonitor, Configuration.MillisecondsTimeout, Opts.FileName});
                var workbook = await GetWorkbook(interruptMonitor);
                workbook.BuiltInDocumentProperties.Clear();
                workbook.CustomDocumentProperties.Clear();

                var doc = new DocumentInfo {Workbook = workbook, FileName = Opts.FileName, FolderName = Opts.FolderName};

                await Storage.UpdateStatus(Common.Models.Response.Process(Opts.FolderName, Opts.ResultFileName));

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Logger.LogWarning("AppName = {AppName} | MethodName = {MethodName} | Filename = {Filename} | Start",
                    AppName, Opts.MethodName, Opts.FileName);

                var response = await ProcessCellsBlock(new[] {doc});

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

        private static void SetBuiltInProperties(Workbook workbook, List<DocProperty> pars)
        {
            var builtin = workbook.BuiltInDocumentProperties;
            var t = builtin.GetType();
            foreach (var par in pars)
            {
                var prop = t.GetProperty(par.Name);
                if (prop != null)
                    switch (par.Type)
                    {
                        case PropertyType.String:
                            prop.SetValue(builtin, Convert.ToString(par.Value));
                            break;
                        case PropertyType.Boolean:
                            prop.SetValue(builtin, Convert.ToBoolean(par.Value));
                            break;
                        case PropertyType.Number:
                            prop.SetValue(builtin, Convert.ToInt32(par.Value));
                            break;
                        case PropertyType.DateTime:
                            prop.SetValue(builtin, Convert.ToDateTime(par.Value));
                            break;
                        case PropertyType.Double:
                            prop.SetValue(builtin, Convert.ToDouble(par.Value));
                            break;
                    }
            }
        }

        private static void SetCustomProperties(Workbook workbook, List<DocProperty> pars)
        {
            var custom = workbook.CustomDocumentProperties;
            custom.Clear();
            foreach (var par in pars)
                switch (par.Type)
                {
                    case PropertyType.String:
                        custom.Add(par.Name, Convert.ToString(par.Value));
                        break;
                    case PropertyType.Boolean:
                        custom.Add(par.Name, Convert.ToBoolean(par.Value));
                        break;
                    case PropertyType.Number:
                        custom.Add(par.Name, Convert.ToInt32(par.Value));
                        break;
                    case PropertyType.DateTime:
                        custom.Add(par.Name, Convert.ToDateTime(par.Value));
                        break;
                    case PropertyType.Double:
                        custom.Add(par.Name, Convert.ToDouble(par.Value));
                        break;
                }
        }

        private class PropertiesResponse
        {
            public BuiltInDocumentPropertyCollection BuiltIn { get; set; }
            public CustomDocumentPropertyCollection Custom { get; set; }

            public PropertiesResponse(Workbook workbook)
            {
                BuiltIn = workbook.BuiltInDocumentProperties;
                Custom = workbook.CustomDocumentProperties;
            }
        }

        private class DocProperty
        {
            public string Name { get; set; }
            public object Value { get; set; }
            public PropertyType Type { get; set; }
        }

        private async Task<Response> ProcessCellsBlock(DocumentInfo[] docs)
        {
            var streams = new Dictionary<string, Stream>();
            var (_, outFilePath) = BeforeAction();
            var catchException = false;
            var exception = new Exception();

            foreach (var doc in docs)
            {
                try
                {
                    var dictionary = SaveDocument(doc, GetSaveFormatTypeByFilename(doc.FileName));
                    foreach (var (key, value) in dictionary)
                    {
                        if (streams.ContainsKey(key)) continue;
                        streams.Add(key, value);
                    }
                }
                catch (Exception e)
                {
                    catchException = true;

                    foreach (var (_, stream) in streams)
                    {
                        stream.Close();
                    }

                    await UploadErrorFiles(docs, AppName);

                    exception = e.InnerException ?? e;
                    Logger.LogError("{Message}", exception.Message);
                    break;
                }
            }

            if (!catchException)
                return await AfterAction(outFilePath, streams);

            await Storage.UpdateStatus(Common.Models.Response.Error(Opts.FolderName, Opts.ResultFileName, exception.Message));
            throw exception;
        }
    }
}