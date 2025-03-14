using System;
 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aspose.Cells.GridJs;
 
using System.IO;
using System.Threading;
 
using System.Collections;
using Microsoft.AspNetCore.StaticFiles;
using Aspose.Cells.GridJsDemo.Models;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO.Compression;
using Newtonsoft.Json;

namespace Aspose.Cells.GridJsDemo.Controllers
{
    
    [Route("[controller]/[action]")]
    [ApiController]
    public class GridJs2Controller : GridJsControllerBase
    {
            private readonly IGridJsService _gridJsService;

            public GridJs2Controller(IGridJsService gridJsService) : base(gridJsService)
            {
                _gridJsService = gridJsService;
            }
 
       

       





        // GET: /GridJs2/DetailJson?filename=
        public ActionResult DetailFileJson(string filename)
        {

            
            String file=Path.Combine(TestConfig.ListDir, filename);
            GridJsWorkbook wbj = new GridJsWorkbook();
            Workbook wb = new Workbook(file);
            wbj.ImportExcelFile(wb);
            return Content(wbj.ExportToJson(filename), "text/plain", System.Text.Encoding.UTF8);
           
        }


        // GET: /GridJs2/DetailFileJsonWithUid?filename=&uid=
        public ActionResult DetailFileJsonWithUid(string filename,string uid)
        {
            String fullFilePath = Path.Combine(TestConfig.ListDir, filename);
            StringBuilder ret= _gridJsService.DetailFileJsonWithUid(fullFilePath, uid);
           
           
            return Content(ret.ToString(), "text/plain", System.Text.Encoding.UTF8);
        }

        // GET: /GridJs2/DetailStreamJsonWithUid?filename=&uid=
        public ActionResult DetailStreamJsonWithUid(string filename, string uid,string fromUpload)
        {
            
            String fullFilePath =  Path.Combine(fromUpload != null? TestConfig.UploadDir:TestConfig.ListDir, filename);


            //check if already in cache
            Response.ContentType = "application/json";
            Response.Headers.Add("Content-Encoding", "gzip");

            using (GZipStream gzip = new GZipStream(Response.Body, CompressionLevel.Optimal))
            {
                _gridJsService.DetailStreamJsonWithUid(gzip, fullFilePath, uid);
            }

            return new EmptyResult();
        }


        // GET: /GridJs2/DetailStreamJson?filename=
        public ActionResult DetailStreamJson(string filename,string fromUpload)
        {


            String file = Path.Combine(fromUpload != null ? TestConfig.UploadDir : TestConfig.ListDir, filename);

            Response.ContentType = "application/json";
            Response.Headers.Add("Content-Encoding", "gzip");

            using (GZipStream gzip = new GZipStream(Response.Body, CompressionLevel.Optimal))
            {//simple way ,direct use file pathis also ok
                _gridJsService.DetailStreamJson(gzip, file);

               
            }

            return new EmptyResult();
        }


     

            


        
        
    }
}
