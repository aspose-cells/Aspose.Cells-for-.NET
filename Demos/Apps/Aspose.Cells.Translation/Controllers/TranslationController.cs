using System.Linq;
using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Translation.Controllers
{
    public class TranslationController : UIControllerBase
    {
        public TranslationController(IWebHostEnvironment env, ILogger<TranslationController> logger) : base(env, logger)
        {
        }

        public ActionResult Translation()
        {
            var languagesCode = Resources["LanguagesCode"].Split(',');
            var languages = Resources["Languages"].Split(',');
            var languagesList = languagesCode.Select((t, i) => new Languages {Code = t, Language = languages[i]}).ToList();

            var model = new ViewModel(this, "Translation")
            {
                SaveAsComponent = true,
                SaveAsOriginal = false,
                ShowViewerButton = false,
                Languages = languagesList
            };
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View("~/Pages/Translation.cshtml", model);
        }
    }
}