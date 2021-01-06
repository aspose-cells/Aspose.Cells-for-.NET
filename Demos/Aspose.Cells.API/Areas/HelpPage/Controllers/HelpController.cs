using System.Web.Http;
using System.Web.Mvc;

namespace Aspose.Cells.API.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        private const string ErrorViewName = "Error";

        public HelpController() : this(GlobalConfiguration.Configuration)
        {
        }

        public HelpController(HttpConfiguration config)
        {
            Configuration = config;
        }

        public HttpConfiguration Configuration { get; private set; }

        public ActionResult Index()
        {
            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        public ActionResult Api(string apiId)
        {
            if (string.IsNullOrEmpty(apiId)) return View(ErrorViewName);
            var apiModel = Configuration.GetHelpPageApiModel(apiId);
            return apiModel != null ? View(apiModel) : View(ErrorViewName);
        }

        public ActionResult ResourceModel(string modelName)
        {
            if (string.IsNullOrEmpty(modelName)) return View(ErrorViewName);
            var modelDescriptionGenerator = Configuration.GetModelDescriptionGenerator();
            return modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out var modelDescription) ? View(modelDescription) : View(ErrorViewName);
        }
    }
}