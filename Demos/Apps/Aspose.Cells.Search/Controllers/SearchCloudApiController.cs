using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
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
    public class SearchCloudApiController : CellsCloudApiControllerBase
    {
        private const string AppName = "Search";
        public SearchCloudApiController(IStorageService storage, IConfiguration configuration, ILogger<SearchCloudApiController> logger) : base(storage, configuration, logger)
        {
        }

        [HttpPost]
        public async Task<Response> Search(string query)
        {
            return await RunBusinessCode(async (IDictionary<string, Stream> docs, string sessionId, string query) =>
            {
                var streams = new Dictionary<string, Stream>();
                var (_, outFilePath) = BeforeAction();
                var catchException = false;
                var exception = new Exception();
                Opts.AppName = "Search";
                Opts.MethodName = "Search";
                Opts.ZipFileName = "SearchResults files";
                Opts.OutputType = ".xlsx";
                Opts.ResultFileName = "SearchResults.txt";
                Opts.CreateZip = false;
                try
                {
                    CellsCloudClient cells = new CellsCloudClient();
                    var value =cells.Search(docs, query);
                    var found = new StringBuilder();
                    found.AppendLine("Searched Text: " + query);
                    found.AppendLine("===========================================");
                    found.AppendLine();
                    foreach ( TextItem item in value.Result)
                    {
                        found.AppendLine("Link : " + item.link.Href);
                        found.AppendLine("Cell Value: " + item.Text);
                        found.AppendLine();
                    }

                    var memoryStream = new MemoryStream();
                    var requestWriter = new StreamWriter(memoryStream);
                    await requestWriter.WriteAsync(found.ToString());
                    await requestWriter.FlushAsync();
                    streams.Add(Opts.ResultFileName, memoryStream);
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
                    return await AfterAction(Opts.ResultFileName, streams);

                await Storage.UpdateStatus(Common.Models.Response.Error(Opts.FolderName, Opts.ResultFileName, exception.Message));
                throw exception;
            }, AppName, query);

        }
    }
}