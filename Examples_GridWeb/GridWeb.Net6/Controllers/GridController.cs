using Aspose.Cells.GridWeb.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GridWeb.Demo.Controllers
{
    [Route("grid")]
    public class GridController : Controller
    {
        public class SimpleViewModel
        {
            public string EnteredValue { get; set; }
        }


        [HttpGet("versionp/{type}/{id}")]
        public IActionResult GetV1(string type, string id)
        {
            return new OkObjectResult("Version One home " + type + " " + id);
        }

        [HttpGet("acw/{type}/{id}")]
        [HttpPost("acw/{type}/{id}")]
        public IActionResult Operation(string type, string id)
        {
            /*
            Aspose.Cells.GridWeb.GridWeb  mw = new Aspose.Cells.GridWeb.GridWeb();
            //use this method to restore GridWeb instance and do your job for Cells if you wish
            mw.RestoreBySession(HttpContext.Session);
            string a1v = mw.ActiveSheet.Cells["A1"].StringValue;
            */
            //the default auto predefined post action 
            return Aspose.Cells.GridWeb.AcwController.DoAcwAction(this, type, id);
        }
        
        [HttpPost]  
        public IActionResult ButtonClickUpdateA1(SimpleViewModel model)
        {
            Aspose.Cells.GridWeb.GridWeb mw = new Aspose.Cells.GridWeb.GridWeb();
           
            //use this method to restore GridWeb instance
            mw.RestoreBySession(HttpContext.Session);
            string a1v = mw.ActiveSheet.Cells["A1"].StringValue;
            mw.ActiveSheet.Cells["A1"].PutValue(model.EnteredValue);
            mw.ActiveSheet.Cells["A1"].CreateComment("hello world" + " " + new DateTime(), "peter", true);
            //call update cache to save back the edit result
            mw.UpdateCache();
            //return   Content(mw.ActiveSheet.Cells["A1"].StringValue); ;  
           return  RedirectToAction("Index1", new { value = "fromupdate" });
        }

        [HttpGet] //  get  value from cell c3
        public IActionResult QueryInfo()
        {
            Aspose.Cells.GridWeb.GridWeb mw = new Aspose.Cells.GridWeb.GridWeb();

            //use this method to restore GridWeb instance
            mw.RestoreBySession(HttpContext.Session);
            string a1v = mw.ActiveSheet.Cells["C3"].StringValue;
           
            return Content(a1v);
        }

        [HttpGet("index1")]
        public IActionResult Index1(string value)
        {
            //set a session store path
            Aspose.Cells.GridWeb.GridWeb.SessionStorePath = TestConfig.TempDir;
            Aspose.Cells.GridWeb.GridWeb mw = new Aspose.Cells.GridWeb.GridWeb();
            mw.ID = "gid";
            mw.SetSession(HttpContext.Session);
            //set acw_client path
            mw.ResourceFilePath = "/js/acw_client/";
			 //set the picture cache ,you need to create this directory
            mw.PictureCachePath = TestConfig.PicDir;
            mw.EnableAsync = true;
            mw.ShowCellEditBox = true;
            //load workbook
            //String file = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\wb\test.xlsx");
            String file = TestConfig.File;
            if (value == null)
            {
                mw.ImportExcelFile(file);
            }
            else
            {//fromupdate
                mw.RestoreBySession(HttpContext.Session);
            }
            mw.ActiveSheet.Cells["B1"].PutValue("version:");
            mw.ActiveSheet.Cells["C1"].PutValue(Aspose.Cells.GridWeb.GridWeb.GetVersion());

            //set width height
            mw.Width = Unit.Pixel(800);
            mw.Height = Unit.Pixel(500);
            return View(mw);

        }
    }
}
