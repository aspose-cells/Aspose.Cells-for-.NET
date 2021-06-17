using System.Collections.Generic;
using System.Linq;
using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Merger.Controllers
{
    public class MergerController : UIControllerBase
    {
        public MergerController(IWebHostEnvironment env, ILogger<MergerController> logger) : base(env, logger)
        {
        }

        private readonly Dictionary<string, string[]> _supportedMergerFormats = new Dictionary<string, string[]>
        {
            {"xlsx", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml", "md"}},
            {"xls", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml", "md"}},
            {"xlsm", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml", "md"}},
            {"xlsb", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml", "md"}},
            {"ods", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml", "md"}},
            {"csv", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml", "md"}},
            {"tsv", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml", "md"}},
            {"html", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml", "md"}},
            {"mht", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml", "md"}},
            {"mhtml", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml", "md"}},
            {"jpg", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml"}},
            {"png", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml"}}
        };

        public ActionResult Merger()
        {
            var model = new ViewModel(this, "Merger")
            {
                UseSorting = true,
                SaveAsComponent = true,
                SaveAsOriginal = false,
                ShowViewerButton = false,
                ShowDeleteButton = true
            };
            var isSupportedExt = IsSupportedMergerExtensions(model.Extension, model.Extension2);
            if (!isSupportedExt)
            {
                return Redirect("/cells/" + model.AppName.ToLower());
            }

            var ext = string.IsNullOrEmpty(model.Extension) ? "xlsx" : model.Extension;
            var res = _supportedMergerFormats[ext.ToLower()].Select(x => x.ToUpper()).ToList();
            if (!string.IsNullOrEmpty(model.Extension2))
            {
                var index = res.FindIndex(x => x == model.Extension2.ToUpper());
                if (index >= 0)
                {
                    res.RemoveAt(index);
                    res.Insert(0, model.Extension2.ToUpper());
                }
            }

            model.SaveAsOptions = res.ToArray();
            return View("~/Pages/Merger.cshtml", model);
        }

        private bool IsSupportedMergerExtensions(string extFrom, string extTo)
        {
            if (string.IsNullOrEmpty(extFrom))
            {
                return true;
            }

            extTo = string.IsNullOrEmpty(extTo) ? "" : extTo.ToLower();

            var isValExist = _supportedMergerFormats.TryGetValue(extFrom.ToLower(), out var exToArray);
            if (!isValExist)
                return false;

            return string.IsNullOrEmpty(extTo) || exToArray.Contains(extTo);
        }
    }
}