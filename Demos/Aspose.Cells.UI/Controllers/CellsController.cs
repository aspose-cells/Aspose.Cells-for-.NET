using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Aspose.Cells.UI.Config;
using Aspose.Cells.UI.Models;

namespace Aspose.Cells.UI.Controllers
{
    public class CellsController : BaseController
    {
        public override string Product => "cells";
        private readonly string[] _feedbackEmails = {"xxxx@xxxx.xxxx"};

        internal readonly Dictionary<string, string[]> SupportedFormats = new Dictionary<string, string[]>
        {
            {"xlsx", new[] {"pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml", "md"}},
            {"xls", new[] {"pdf", "docx", "pptx", "xlsx", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml", "md"}},
            {"xlsm", new[] {"pdf", "docx", "pptx", "xlsx", "xls", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml", "md"}},
            {"xlsb", new[] {"pdf", "docx", "pptx", "xlsx", "xls", "xlsm", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml", "md"}},
            {"ods", new[] {"pdf", "docx", "pptx", "xlsx", "xls", "xlsm", "xlsb", "csv", "tsv", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml", "md"}},
            {"csv", new[] {"pdf", "docx", "pptx", "xlsx", "xls", "xlsm", "xlsb", "ods", "tsv", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml", "md"}},
            {"tsv", new[] {"pdf", "docx", "pptx", "xlsx", "xls", "xlsm", "xlsb", "ods", "csv", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml", "md"}},
            {"html", new[] {"pdf", "docx", "pptx", "xlsx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml", "md"}},
            {"mht", new[] {"pdf", "docx", "pptx", "xlsx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml", "md"}},
            {"mhtml", new[] {"pdf", "docx", "pptx", "xlsx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "md"}},
            {"jpg", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "html", "bmp", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml"}},
            {"png", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "html", "bmp", "jpg", "emf", "wmf", "svg", "tiff", "xps", "mhtml"}}
        };

        internal readonly Dictionary<string, string[]> SupportedMergerFormats = new Dictionary<string, string[]>
        {
            {"xlsx", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml", "md"}},
            {"xls", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml", "md"}},
            {"xlsm", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml", "md"}},
            {"xlsb", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml", "md"}},
            {"ods", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml", "md"}},
            {"csv", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml", "md"}},
            {"tsv", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml", "md"}},
            {"html", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml", "md"}},
            {"mht", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml", "md"}},
            {"mhtml", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "csv", "tsv", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml", "md"}},
            {"jpg", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml"}},
            {"png", new[] {"xlsx", "pdf", "docx", "pptx", "xls", "xlsm", "xlsb", "ods", "html", "bmp", "jpg", "png", "emf", "wmf", "svg", "tiff", "xps", "mhtml"}}
        };

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

            if (string.IsNullOrEmpty(model.Extension)) return View(model);

            var res = SupportedFormats[model.Extension.ToLower()].Select(x => x.ToUpper()).ToList();
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

            return View(model);
        }

        public ActionResult Parser()
        {
            var model = new ViewModel(this, "Parser");
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View(model);
        }

        public ActionResult Metadata()
        {
            var model = new ViewModel(this, "Metadata")
            {
                UploadAndRedirect = true,
                ControlsView = "MetadataControls"
            };
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View(model);
        }

        public ActionResult Viewer()
        {
            var model = new ViewModel(this, "Viewer")
            {
                UploadAndRedirect = true
            };
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View(model);
        }

        public ActionResult Watermark()
        {
            var model = new ViewModel(this, "Watermark");
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View(model);
        }

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
            var res = SupportedMergerFormats[ext.ToLower()].Select(x => x.ToUpper()).ToList();
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
            return View(model);
        }

        public ActionResult Search()
        {
            var model = new ViewModel(this, "Search")
            {
                ControlsView = "SearchControls",
                ShowViewerButton = false
            };
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View(model);
        }

        public ActionResult Assembly()
        {
            var model = new ViewModel(this, "Assembly")
            {
                ShowViewerButton = false
            };
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View(model);
        }

        public ActionResult Annotation()
        {
            var model = new ViewModel(this, "Annotation");
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View(model);
        }

        public ActionResult Unlock()
        {
            var model = new ViewModel(this, "Unlock")
            {
                ControlsView = "UnlockControls",
                ShowViewerButton = false
            };
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View(model);
        }

        public ActionResult Protect()
        {
            var model = new ViewModel(this, "Protect")
            {
                ControlsView = "ProtectControls",
                ShowViewerButton = false
            };
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View(model);
        }

        public ActionResult Editor()
        {
            var model = new ViewModel(this, "Editor");
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View(model);
        }

        public ActionResult Splitter()
        {
            var model = new ViewModel(this, "Splitter")
            {
                SaveAsComponent = true,
                ShowViewerButton = false
            };
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View(model);
        }

        public ActionResult Chart()
        {
            var model = new ViewModel(this, "Chart")
            {
                SaveAsComponent = true,
                ShowViewerButton = false,
                SaveAsOriginal = false,
                ControlsView = "ChartControls"
            };
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View(model);
        }

        #region API

        [HttpPost]
        public JsonResult SendEmail(string url, string title, string appName, string email)
        {
            try
            {
                if (IsValidEmail(email))
                {
                    Task.Factory.StartNew(() =>
                    {
                        var u = HttpUtility.UrlDecode(url);
                        var successMessage = Resources[Product + appName + "SuccessMessage"];
                        var emailBody = EmailManager.PopulateBody(title, u, successMessage);
                        EmailManager.SendEmail(email, Configuration.FromEmailAddress, Resources["EmailTitle"], emailBody, "");
                    });
                    Session["emailTo"] = email;
                    return Json(new {message = Resources[Product + appName + "SentEmailSuccessMessage"]});
                }

                HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                return Json(new {message = Resources["ValidateEmailMessage"]});
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                return Json(new {message = ex.Message});
            }
        }

        [HttpPost]
        public JsonResult SendFeedback(string text, string appName, int score = 0)
        {
            try
            {
                if (text.Length > 1000)
                {
                    HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    return Json(new {message = Resources["FeedbackLengthError"]});
                }

                var subject = $"aspose.app feedback {appName}";
                var body = score == 0
                    ? text
                    : $"Score: {score}{Environment.NewLine}{text}";
                Task.Factory.StartNew(() =>
                {
                    foreach (var email in _feedbackEmails)
                    {
                        try
                        {
                            EmailManager.SendEmail(email, Configuration.FromEmailAddress, subject, body, "");
                        }
                        catch
                        {
                            // ignored
                        }
                    }
                });
                return Json(new {message = Resources["FeedbackSuccess"]});
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                return Json(new {message = ex.Message});
            }
        }

        #endregion

        #region private methods

        private bool IsSupportedConversionExtensions(string extFrom, string extTo)
        {
            if (string.IsNullOrEmpty(extFrom))
            {
                return true;
            }

            extTo = string.IsNullOrEmpty(extTo) ? "" : extTo.ToLower();

            var isValExist = SupportedFormats.TryGetValue(extFrom.ToLower(), out var exToArray);
            if (!isValExist)
                return false;

            return string.IsNullOrEmpty(extTo) || exToArray.Contains(extTo);
        }

        private bool IsSupportedMergerExtensions(string extFrom, string extTo)
        {
            if (string.IsNullOrEmpty(extFrom))
            {
                return true;
            }

            extTo = string.IsNullOrEmpty(extTo) ? "" : extTo.ToLower();

            var isValExist = SupportedMergerFormats.TryGetValue(extFrom.ToLower(), out var exToArray);
            if (!isValExist)
                return false;

            return string.IsNullOrEmpty(extTo) || exToArray.Contains(extTo);
        }

        #endregion
    }
}