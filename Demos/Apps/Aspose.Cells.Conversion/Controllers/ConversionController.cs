using System.Collections.Generic;
using System.Linq;
using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Conversion.Controllers
{
    public class ConversionController : UIControllerBase
    {
        public ConversionController(IWebHostEnvironment env, ILogger<ConversionController> logger) : base(env, logger)
        {
        }

        public ActionResult Conversion()
        {
            var model = new ViewModel(this, "Conversion")
            {
                SaveAsComponent = true,
                SaveAsOriginal = false,
                ShowViewerButton = false
            };
            var isSupportedExt = IsSupportedConversionExtensions(model.Extension, model.Extension2);
            if (!isSupportedExt)
            {
                return Redirect("/cells/" + model.AppName.ToLower());
            }

            if (string.IsNullOrEmpty(model.Extension)) return View("~/Pages/Conversion.cshtml", model);

            var res = _supportedFormats[model.Extension.ToLower()].Select(x => x.ToUpper()).ToList();
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

            return View("~/Pages/Conversion.cshtml", model);
        }

        private bool IsSupportedConversionExtensions(string extFrom, string extTo)
        {
            if (string.IsNullOrEmpty(extFrom))
            {
                return true;
            }

            extTo = string.IsNullOrEmpty(extTo) ? "" : extTo.ToLower();

            var isValExist = _supportedFormats.TryGetValue(extFrom.ToLower(), out var exToArray);
            if (!isValExist)
                return false;

            return string.IsNullOrEmpty(extTo) || exToArray.Contains(extTo);
        }

        private readonly Dictionary<string, string[]> _supportedFormats = new Dictionary<string, string[]>
        {
            {"excel", new[] {"pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml", "md"}},
            {"xlsx", new[] {"pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml", "md"}},
            {"xls", new[] {"pdf", "docx", "pptx", "xlsx", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml", "md"}},
            {"xlsm", new[] {"pdf", "docx", "pptx", "xlsx", "xls", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml", "md"}},
            {"xlsb", new[] {"pdf", "docx", "pptx", "xlsx", "xls", "xlsm", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml", "md"}},
            {"ods", new[] {"pdf", "docx", "pptx", "xlsx", "xls", "xlsm", "xlsb", "csv", "tsv", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml", "md"}},
            {"csv", new[] {"pdf", "docx", "pptx", "xlsx", "xls", "xlsm", "xlsb", "ods", "tsv", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml", "md"}},
            {"tsv", new[] {"pdf", "docx", "pptx", "xlsx", "xls", "xlsm", "xlsb", "ods", "csv", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml", "md"}},
            {"html", new[] {"pdf", "docx", "pptx", "xlsx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml", "md"}},
            {"mht", new[] {"pdf", "docx", "pptx", "xlsx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "mhtml", "md"}},
            {"mhtml", new[] {"pdf", "docx", "pptx", "xlsx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "svg", "tiff", "xps", "md"}},
            {"jpg", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "html", "bmp", "png", "svg", "tiff", "xps", "mhtml"}},
            {"jpeg", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "html", "bmp", "jpg", "svg", "tiff", "xps", "mhtml"}},
            {"png", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "html", "bmp", "jpg", "svg", "tiff", "xps", "mhtml"}},
        };
    }
}