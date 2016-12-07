using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Controllers
{
    public class GridWebFAQController : Controller
    {
        //
        // GET: /GridWebFAQ/

        public ActionResult Index()
        {
            return View();
        }

        private HttpPostedFileBase postedFile;

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string mode)
        {
            this.postedFile = file;
            Thread newThread = new Thread(Calculate, 1048576);
            newThread.Start();
            newThread.Join();
            return View();
        }

        private void Calculate()
        {
            if (postedFile != null && postedFile.ContentLength > 0)
            {
                var wbkMain = new Workbook(postedFile.InputStream);
                wbkMain.CalculateFormula();
            }
        }
    }
}
