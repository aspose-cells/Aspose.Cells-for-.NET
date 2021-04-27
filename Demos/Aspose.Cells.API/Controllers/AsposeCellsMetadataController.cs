using Aspose.Cells.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Aspose.Cells.API.Models;
using Tools.Foundation.Models;
using Aspose.Cells.API.Config;

namespace Aspose.Cells.API.Controllers
{
    /// <summary>
    /// AsposeCellsMetadataController class
    /// </summary>
    public class AsposeCellsMetadataController : AsposeCellsBaseController
    {
        private const string App = "Metadata";

        ///<Summary>
        /// Properties method to get metadata
        ///</Summary>
        ///
        [HttpPost]
        [ActionName("Properties")]
        public HttpResponseMessage Properties(JObject obj)
        {
            Opts.AppName = "Metadata";
            Opts.MethodName = "Properties";
            Opts.FileName = Convert.ToString(obj["FileName"]);
            Opts.FolderName = Convert.ToString(obj["id"]);

            try
            {
                var workbook = new Workbook(Opts.WorkingFileName);
                return Request.CreateResponse(HttpStatusCode.OK, new PropertiesResponse(workbook));
            }
            catch (Exception e)
            {
                var message = $"{e.Message} | FileName = {Convert.ToString(obj["FileName"])}";
                NLogger.LogError(App, "Properties", message, Convert.ToString(obj["id"]));

                var response = new Response
                {
                    StatusCode = 500,
                    Status = e.Message,
                    FolderName = Opts.FolderName,
                    Text = "Metadata Properties"
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }

        ///<Summary>
        /// Properties method. Should include 'FileName', 'id', 'properties' as params
        ///</Summary>
        [HttpPost]
        [ActionName("Download")]
        public async Task<Response> Download(JObject obj)
        {
            Opts.AppName = "Metadata";
            Opts.MethodName = "Download";
            try
            {
                Opts.FileName = Convert.ToString(obj["FileName"]);
                Opts.ResultFileName = Opts.FileName;
                Opts.FolderName = Convert.ToString(obj["id"]);
                var workbook = new Workbook(Opts.WorkingFileName);

                var pars = obj["properties"]["BuiltIn"].ToObject<List<DocProperty>>();
                SetBuiltInProperties(workbook, pars);
                pars = obj["properties"]["Custom"].ToObject<List<DocProperty>>();
                SetCustomProperties(workbook, pars);

                return await Process((inFilePath, outPath, zipOutFolder) =>
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    NLogger.LogInfo($"Excel Metadata=>{outPath}=>Start");

                    var task = Task.Run(() => { workbook.Save(outPath); });
                    var isCompleted = task.Wait(Api.Configuration.MillisecondsTimeout);

                    if (!isCompleted)
                    {
                        NLogger.LogError($"Excel Metadata=>{outPath}=>{AppSettings.ProcessingTimedout}");
                        throw new TimeoutException(AppSettings.ProcessingTimedout);
                    }

                    stopWatch.Stop();
                    NLogger.LogInfo($"Excel Metadata=>{outPath}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}");
                });
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                var message = $"{exception.Message} | FileName = {Convert.ToString(obj["FileName"])}";
                NLogger.LogError(App, "Download", message, Convert.ToString(obj["id"]));

                return await Task.FromResult(new Response
                {
                    StatusCode = 500,
                    Status = exception.Message,
                    FolderName = Convert.ToString(obj["id"]),
                    Text = "Metadata Download"
                });
            }
        }

        ///<Summary>
        /// Properties method. Should include 'FileName', 'id' as params
        ///</Summary>
        [HttpPost]
        [ActionName("Clear")]
        public async Task<Response> Clear(JObject obj)
        {
            Opts.AppName = "Metadata";
            Opts.MethodName = "Clear";
            try
            {
                Opts.FileName = Convert.ToString(obj["FileName"]);
                Opts.ResultFileName = Opts.FileName;
                Opts.FolderName = Convert.ToString(obj["id"]);

                var workbook = new Workbook(Opts.WorkingFileName);
                workbook.BuiltInDocumentProperties.Clear();
                workbook.CustomDocumentProperties.Clear();

                return await Process((inFilePath, outPath, zipOutFolder) => { workbook.Save(outPath); });
            }
            catch (Exception e)
            {
                var message = $"{e.Message} | FileName = {Convert.ToString(obj["FileName"])}";
                NLogger.LogError(App, "Clear", message, Convert.ToString(obj["id"]));

                return await Task.FromResult(new Response
                {
                    StatusCode = 500,
                    Status = e.Message,
                    FolderName = Convert.ToString(obj["id"]),
                    Text = "Metadata Clear"
                });
            }
        }

        /// <summary>
        /// SetBuiltInProperties
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="pars"></param>
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

        /// <summary>
        /// SetCustomProperties
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="pars"></param>
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

        /// <summary>
        /// PropertiesResponse
        /// </summary>
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

        /// <summary>
        /// The same fields as in DocumentProperty
        /// </summary>
        private class DocProperty
        {
            public string Name { get; set; }
            public object Value { get; set; }
            public PropertyType Type { get; set; }
        }
    }
}