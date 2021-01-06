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

namespace Aspose.Cells.API.Controllers
{
    /// <summary>
    /// AsposeCellsMetadataController class
    /// </summary>
    public class AsposeCellsMetadataController : AsposeCellsBaseController
    {
        ///<Summary>
        /// Properties method to get metadata
        ///</Summary>
        ///
        [HttpPost]
        [ActionName("Properties")]
        public HttpResponseMessage Properties(JObject obj)
        {
            Opts.AppName = MetadataApp;
            Opts.MethodName = "Properties";
            Opts.FileName = Convert.ToString(obj["FileName"]);
            Opts.FolderName = Convert.ToString(obj["id"]);

            try
            {
                var workbook = new Workbook(Opts.WorkingFileName);
                return Request.CreateResponse(HttpStatusCode.OK, new PropertiesResponse(workbook));
            }
            catch (AppException ex)
            {
                NLogger.LogError(ex, $"{Opts.FolderName}-{Opts.MethodName}");
                return Request.CreateResponse(HttpStatusCode.InternalServerError, AppErrorResponse(ex.Message, Opts.FolderName, Opts.MethodName));
            }
            catch (Exception ex)
            {
                NLogger.LogError(ex, $"{Opts.FolderName}-{Opts.MethodName}");
                return Request.CreateResponse(HttpStatusCode.InternalServerError, InternalServerErrorResponse(Opts.FolderName, Opts.MethodName));
            }
        }

        ///<Summary>
        /// Properties method. Should include 'FileName', 'id', 'properties' as params
        ///</Summary>
        [HttpPost]
        [ActionName("Download")]
        public async Task<Response> Download(JObject obj)
        {
            Opts.AppName = MetadataApp;
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
                    NLogger.LogInfo($"Excel Metadata=>{outPath}=>Start", AsposeCells, ProductFamilyNameKeysEnum.cells, outPath);

                    var task = Task.Run(() => { workbook.Save(outPath); });
                    Task.WaitAll(task);

                    stopWatch.Stop();
                    NLogger.LogInfo($"Excel Metadata=>{outPath}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}", AsposeCells, ProductFamilyNameKeysEnum.cells, outPath);
                });
            }
            catch (Exception ex)
            {
                LogError(ex);
                return await Task.FromResult(new Response
                {
                    Status = "500 " + ex.Message,
                    StatusCode = 500
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
            Opts.AppName = MetadataApp;
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
            catch (Exception ex)
            {
                LogError(ex);
                return await Task.FromResult(new Response
                {
                    Status = "500 " + ex.Message,
                    StatusCode = 500
                });
            }
        }

        /// <summary>
        /// SetBuiltInProperties
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="pars"></param>
        private void SetBuiltInProperties(Workbook workbook, List<DocProperty> pars)
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
        private void SetCustomProperties(Workbook workbook, List<DocProperty> pars)
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