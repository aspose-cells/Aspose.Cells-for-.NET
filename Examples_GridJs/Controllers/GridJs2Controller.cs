using System;
 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aspose.Cells.GridJs;
 
using System.IO;
using System.Threading;
 
using System.Collections;
using Microsoft.AspNetCore.StaticFiles;
using Aspose.Cells.GridJsDemo.Models;
 

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
