using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Cells.GridJs;
using Aspose.Cells.GridJsDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 

namespace Aspose.Cells.GridJsDemo.Controllers
{
    public class HomeController : Controller
    {
 
        
        
         public ActionResult Index()
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
            ViewBag.dirstr = TestConfig.ListDir;
            return View("~/Views/Home/list.cshtml");
        }

        [HttpPost]
        public async Task<ActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return Content("No file selected.");
            }

            var filename = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(TestConfig.UploadDir, filename);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            string demotype = HttpContext.Request.Form["demotype"];
            if (demotype == "1")
            {
                return Redirect("~/xspread/uidload.html?fromUpload=1&file=" + filename + "&uid=" + GridJsWorkbook.GetUidForFile(filename));
            }
            else
            {
                return Redirect("~/xspread/index.html?fromUpload=1&file=" + filename);
            }

        }

        // GET: /Xspreadtml
        public ActionResult Xspreadtml(String filename)
        {
            return Redirect("~/xspread/index.html?file=" + filename);
        }

        // GET: /Uidtml
        public ActionResult Uidtml(String filename)
        {

            return Redirect("~/xspread/uidload.html?file=" + filename + "&uid=" + GridJsWorkbook.GetUidForFile(filename));
        }


        public IActionResult Privacy()
        {
            return Redirect("https://about.aspose.app/legal/privacy-policy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
