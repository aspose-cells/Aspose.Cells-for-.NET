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

namespace Aspose.Cells.GridJsDemo.Controllers
{
    class CppWarningCallback : IWarningCallback
    {
        public void Warning(WarningInfo warningInfo)
        {
            switch (warningInfo.WarningType)
            {
                case WarningType.DuplicateDefinedName:
                    return;
                case WarningType.InvalidTextOfDefinedName:
                    warningInfo.CorrectedObject = "_" + warningInfo.ErrorObject;
                    return;
                case WarningType.InvalidFontName:
                // throw new CellsException(ExceptionType.InvalidData, warningInfo.Description);
                case WarningType.UnsupportedFileFormat:
                // throw new CellsException(ExceptionType.UnsupportedStream, "Unsupported file format.");
                case WarningType.IO:
                case WarningType.Limitation:
                    return;
                default:
                    break;
    
            }
        }
    }
    
    [Route("[controller]/[action]")]
    [ApiController]
    public class GridJs2Controller : Controller 
    {
 
    
        public ActionResult List()
        {
            //this.ViewBag.list = new List<object>();
            ArrayList dirlistsss=new ArrayList ();
            ArrayList filelistsss = new ArrayList();
           
            DirectoryInfo dir = new DirectoryInfo(TestConfig.ListDir);

            //find files under the directory
            FileInfo[] fi = dir.GetFiles();
            foreach (FileInfo f in fi)
            {
                String fname = f.FullName.ToString();
                dirlistsss.Add(fname);
                filelistsss.Add(Path.GetFileName(fname));
            }
          //  ViewData.
            ViewBag.dirlist = dirlistsss;
            ViewBag.filelist = filelistsss;
            return View("~/Views/Home/list.cshtml");
        }

        // GET: /GridJs2/DetailJson?filename=
        public ActionResult DetailFileJson(string filename)
        {

            
            String file=Path.Combine(TestConfig.ListDir, filename);
           
            return DetailJson(file);
        }


        // GET: /GridJs2/DetailFileJsonWithUid?filename=&uid=
        public ActionResult DetailFileJsonWithUid(string filename,string uid)
        {
            String file = Path.Combine(TestConfig.ListDir, filename);
            GridJsWorkbook wbj = new GridJsWorkbook();
            //check if already in cache
           StringBuilder sb= wbj.GetJsonByUid(uid, filename);
            if(sb==null)
            {
                Workbook wb = new Workbook(file);
                wbj.ImportExcelFile(uid, wb);
                sb = wbj.ExportToJsonStringBuilder(filename);
            }
           
           
            return Content(sb.ToString(), "text/plain", System.Text.Encoding.UTF8);
        }



        private ActionResult DetailJson(string path)
        {
            GridJsWorkbook wbj = new GridJsWorkbook();
            wbj.WarningCallback = new CppWarningCallback();
            string filename = Path.GetFileName(path);
            try
            {
                GridInterruptMonitor m = new GridInterruptMonitor();
                wbj.SetInterruptMonitorForLoad(m, 50 * 1000);
                Thread t1 = new Thread(new ParameterizedThreadStart(InterruptMonitor));
                t1.Start(new object[] { m, 90 * 1000 });

             


                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                   /*
                    GridLoadFormat lf = GridJsWorkbook.GetGridLoadFormat(Path.GetExtension(path));
                    if(lf!= GridLoadFormat.Csv&&lf!= GridLoadFormat.Tsv)
                    {
                        lf = GridLoadFormat.Auto;
                    }
                    wbj.ImportExcelFile(fs,lf);
                    */
                    GridLoadFormat lf = GridJsWorkbook.GetGridLoadFormat(Path.GetExtension(path));
                    LoadFormat clf = LoadFormat.Auto;
                    if (lf == GridLoadFormat.Csv  )
                    {
                        clf = LoadFormat.Csv;
                    }else if (lf == GridLoadFormat.Tsv)
                    {
                        clf = LoadFormat.Tsv;
                    }
                    Workbook wb = new Workbook(fs, new LoadOptions(clf));
                    wbj.ImportExcelFile(wb);
                }

            }
            catch (Exception ex)
            {
               
                if (ex is GridCellException)
                {
                    return Content(wbj.ErrorJson(((GridCellException)ex).Message + ((GridCellException)ex).Code), "text/plain", System.Text.Encoding.UTF8);
                }
                return Content(wbj.ErrorJson(ex.Message), "text/plain", System.Text.Encoding.UTF8);
            }
            //return File(stream, "application/octet-stream", "streamfile");
            return Content(wbj.ExportToJson(filename), "text/plain", System.Text.Encoding.UTF8);
        }
        private static void InterruptMonitor(object o)
        {
            object[] os = (object[])o;
            try
            {
                Thread.Sleep((int)os[1]);
               
                ((GridInterruptMonitor)os[0]).Interrupt();
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine("Succeeded for load in give time.");
            }
        }
        [HttpPost]
        // post: /GridJs2/UpdateCell
        public ActionResult UpdateCell( )
        {
            
            string p = HttpContext.Request.Form["p"];
            string uid = HttpContext.Request.Form["uid"];
            GridJsWorkbook gwb = new GridJsWorkbook();
            String ret = gwb.UpdateCell(p, uid);

            return Content(ret, "text/plain", System.Text.Encoding.UTF8);
        }

        [HttpPost]
        public JsonResult AddImage()
        {
            string uid = HttpContext.Request.Form["uid"];
            string p = HttpContext.Request.Form["p"];
            string iscontrol= HttpContext.Request.Form["control"];
           

            string ret = null;
            GridJsWorkbook wb = new GridJsWorkbook();
            if (iscontrol == null)
            {
                if (HttpContext.Request.Form.Files.Count == 0)
                {
                    //for add shape,need to set p.type as one of AutoShapeType
                    ret = wb.InsertImage(uid, p, null, null);
                    return Json(ret);
                }
                else {
                    IFormFile file = HttpContext.Request.Form.Files[0];
            if (file != null)
            {

                try
                {
                   
                        using (var stream = file.OpenReadStream())
                    {
                        ret = wb.InsertImage(uid, p, stream, null);
                    }
                }
                catch (Exception e)
                {

                    return Json(wb.ErrorJson(e.Message));
                }



                return Json(ret);
            }
            else
            {
                        return Json(wb.ErrorJson("no file when add image"));
                    }
                }
               
            }
            else
            {
                try
                {

                    ret = wb.InsertImage(uid, p, null, null);

                }
                catch (Exception e)
                {

                    return Json(wb.ErrorJson(e.Message));
                }



                return Json(ret);
            }




        }

        [HttpPost]
        public JsonResult CopyImage( )
        {

            string uid = HttpContext.Request.Form["uid"];
            string p = HttpContext.Request.Form["p"];
            


            GridJsWorkbook wb = new GridJsWorkbook();
            string ret = wb.CopyImageOrShape(uid, p);

            return Json(ret);

        }
        private static Stream GetStreamFromUrl(string url)
        {
            byte[] imageData = null;

            using (var wc = new System.Net.WebClient())
            {
                imageData = wc.DownloadData(url);
            }

            return new MemoryStream(imageData);
        }
        [HttpPost]
        public JsonResult AddImageByURL()
        {
            string uid = HttpContext.Request.Form["uid"];
            string p = HttpContext.Request.Form["p"];
            string imageurl = HttpContext.Request.Form["imageurl"];
            string ret = null;
            GridJsWorkbook wb = new GridJsWorkbook();
            if (imageurl != null)
            {


                try
                {
                    using (var stream = GetStreamFromUrl(imageurl))
                    {
                        ret = wb.InsertImage(uid, p, stream, imageurl);
                    }
                }
                catch (Exception e)
                {

                    return Json(wb.ErrorJson(e.Message));
                }


                return Json(ret);
            }
            else
            {
                return Json(wb.ErrorJson("image url is null"));
            }




        }
        /// <summary>
        /// get json from uid 
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpGet]
        // post: /GridJs2/Load?uid=
        public ActionResult Load(string uid, string filename)
        {

            GridJsWorkbook gwb = new GridJsWorkbook();

            StringBuilder json = null;
            try
            {

                json = gwb.GetJsonByUid(uid, filename);

            }
            catch (Exception ex)
            {
                // GridCellException eee;
                // eee.Code
                //  return Error(ex.Message);
                if (ex is GridCellException)
                {
                    return Content(gwb.ErrorJson(((GridCellException)ex).Message + ((GridCellException)ex).Code), "text/plain", System.Text.Encoding.UTF8);
                }
                return Content(gwb.ErrorJson(ex.Message), "text/plain", System.Text.Encoding.UTF8);
            }
            if (json == null)
            {
                return Content(gwb.ErrorJson("cannot find the file"), "text/plain", System.Text.Encoding.UTF8);
            }

            Response.ContentType = "text/plain";

            //Response.Write();

            return Content(json.ToString(), "text/plain", System.Text.Encoding.UTF8);


        }

        // GET: /GridJs2/Xspreadtml
        public ActionResult Xspreadtml(String filename)
        {
            return Redirect("~/xspread/index.html?file=" + filename);
        }
        
        // GET: /GridJs2/Uidtml
        public ActionResult Uidtml(String filename)
        {
             
            return Redirect("~/xspread/uidload.html?file=" + filename+"&uid="+ GridJsWorkbook.GetUidForFile(filename));
        }

        // GET: /GridJs2/Image?uid=&id=
        
        public FileResult Image()
        {
            
            string fileid = HttpContext.Request.Query["id"];
            string uid = HttpContext.Request.Query["uid"];
            
            return new FileStreamResult(GridJsWorkbook.GetImageStream(uid, fileid), "image/png");
        }

        //get ole object /GridJs2/Ole
        public ActionResult Ole()
        {
            int oleid = int.Parse(HttpContext.Request.Query["id"]);
            string uid = HttpContext.Request.Query["uid"];
            string sheet = HttpContext.Request.Query["sheet"];
            GridJsWorkbook gwb = new GridJsWorkbook();
              string filename;
            byte[] filebyte = gwb.GetOle(uid, sheet, oleid, out filename);
            if (filename != null)
            {
                FileContentResult ret = new FileContentResult(filebyte, GetMimeType(filename));
                ret.FileDownloadName = filename;
                return ret;
            }
            else
            {
                return NotFound();
            }
        }

        //if use GridCacheForStream you need to set this api
        // GET: /GridJs2/ImageUrl?uid=&id=
        public JsonResult ImageUrl(string id,string uid)
        {
            
            if(GridJsWorkbook.CacheImp!=null)
            { 
            return new JsonResult(GridJsWorkbook.GetImageUrl(uid, id, "."));
            }
            else
            {
                string file = uid + "." + id;
             return new JsonResult("/GridJs2/GetZipFile?f="+ file);
            }
             
        }
        public FileResult GetZipFile(string f)
        {
            //  GridJsWorkbook.getzip
            //GridJsWorkbook.CacheImp.LoadStream(fileid), mimeType, name
            return File(new FileStream(Path.Combine(Config.FileCacheDirectory, f), FileMode.Open), "application/zip",f);
        }

        private string GetMimeType(string FileName)
        {
            string contentType;
            new FileExtensionContentTypeProvider().TryGetContentType(FileName, out contentType);
            return contentType ?? "application/octet-stream";
        }
      
        
        

        // GET: /GridJs2/GetFile?id
        
        public FileResult GetFile(string id,string filename)
        {
            
            string fileid = id;
            string mimeType = filename != null ? GetMimeType(filename) :GetMimeType(fileid);
            string name = filename != null ? filename : fileid.Replace('/', '.');
            return File(GridJsWorkbook.CacheImp.LoadStream(fileid), mimeType, name);
        }
        

      
 



      /// <summary>
      /// down load file
      /// </summary>
      /// <returns></returns>
        [HttpPost]
        
        public JsonResult Download()
        {

            string p = HttpContext.Request.Form["p"];
            string uid = HttpContext.Request.Form["uid"];
            string filename = HttpContext.Request.Form["file"];

            GridJsWorkbook wb = new GridJsWorkbook();
            wb.MergeExcelFileFromJson(uid, p);
           
           

            GridInterruptMonitor m = new GridInterruptMonitor();
            wb.SetInterruptMonitorForSave(m);
            Thread t1 = new Thread(new ParameterizedThreadStart(InterruptMonitor));
            t1.Start(new object[] { m, 30 * 1000 });
            try
            {
                wb.SaveToCacheWithFileName(uid, filename,null);
            }
            catch (Exception ex)
            {

                if (ex is GridCellException)
                {
                    return Json(((GridCellException)ex).Message + ((GridCellException)ex).Code);
                }
            }

            if (Config.SaveHtmlAsZip&&filename.EndsWith(".html"))
            {
                filename += ".zip";
            }
             String fileurl= null;
            if (GridJsWorkbook.CacheImp != null)
            {
                fileurl = GridJsWorkbook.CacheImp.GetFileUrl(uid + "/" + filename);
            }
            else
            {
                fileurl = "/GridJs2/GetFile?id=" + uid + "&filename=" + filename;
            }
            return new JsonResult(fileurl);
        }

        
        
    }
}
