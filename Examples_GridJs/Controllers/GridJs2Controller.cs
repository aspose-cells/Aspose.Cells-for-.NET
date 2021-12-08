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



        private ActionResult DetailJson(string path)
        {
            GridJsWorkbook wbj = new GridJsWorkbook();

            
            try
            {
                GridInterruptMonitor m = new GridInterruptMonitor();
                wbj.SetInterruptMonitorForLoad(m, 50 * 1000);
                Thread t1 = new Thread(new ParameterizedThreadStart(InterruptMonitor));
                t1.Start(new object[] { m, 90 * 1000 });

             


                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    wbj.ImportExcelFile(fs, GridJsWorkbook.GetGridLoadFormat(Path.GetExtension(path)));
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
            return Content(wbj.ExportToJson(), "text/plain", System.Text.Encoding.UTF8);
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
            IFormFile file = HttpContext.Request.Form.Files[0];

            string ret = null;
            GridJsWorkbook wb = new GridJsWorkbook();
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
                return Json(wb.ErrorJson("image is null"));
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
        
        // GET: /GridJs2/Image?uid=&id=
        
        public FileResult Image()
        {
            
            string fileid = HttpContext.Request.Query["id"];
            string uid = HttpContext.Request.Query["uid"];
            
            return new FileStreamResult(GridJsWorkbook.GetImageStream(uid, fileid), "image/png");
        }

        //if use GridCacheForStream you need to set this api
        // GET: /GridJs2/ImageUrl?uid=&id=
        public JsonResult ImageUrl(string id,string uid)
        {
            

            return new JsonResult(GridJsWorkbook.GetImageUrl(uid, id, "."));
             
        }
        private string GetMimeType(string FileName)
        {
            string contentType;
            new FileExtensionContentTypeProvider().TryGetContentType(FileName, out contentType);
            return contentType ?? "application/octet-stream";
        }
      
        
        

        // GET: /GridJs2/GetFile?id
        
        public FileResult GetFile(string id)
        {
            
            string fileid = id;
            string mimeType = GetMimeType(fileid);
           
            return File(GridJsWorkbook.CacheImp.LoadStream(fileid), mimeType, fileid.Replace('/', '.'));
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
            string filename = "123.xlsx";

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
            if (filename.EndsWith(".html"))
            {
                filename += ".zip";
            }
            String fileurl= GridJsWorkbook.CacheImp.GetFileUrl(uid + "/" + filename);
            return new JsonResult(fileurl);
        }

        
        
    }
}
