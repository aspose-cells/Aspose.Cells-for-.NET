using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Aspose.Cells.Common.Config;
using Aspose.Cells.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Common.Controllers
{
    public class UIControllerBase : Controller, ICellsController
    {
        public readonly ILogger logger;
        public IWebHostEnvironment Env { get; }
        public string ContentRootPath { get; }

        private FlexibleResources _resources;

        public virtual IEnumerable<AnotherApp> Applications { get; } = null;

        public UIControllerBase(IWebHostEnvironment env, ILogger<UIControllerBase> logger)
        {
            Env = env;
            ContentRootPath = Env.ContentRootPath;
            this.logger = logger;
        }

        private readonly string[] _feedbackEmails = {"nick.liu@aspose.com"};

        public const string Product = "cells";

        public virtual FlexibleResources Resources => _resources ??= new FlexibleResources(Env, "EN");

        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        [HttpPost]
        public JsonResult SendEmail(string url, string title, string appName, string email)
        {
            try
            {
                if (IsValidEmail(email))
                {
                    Task.Factory.StartNew(() =>
                    {
                        var successMessage = Resources[Product + appName + "SuccessMessage"];
                        var emailBody = EmailManager.PopulateBody(title, url, successMessage);
                        EmailManager.SendEmail(email, Configuration.MailServerUserId, Resources["EmailTitle"], emailBody, "", logger);
                    });
                    return Json(new {message = Resources[Product + appName + "SentEmailSuccessMessage"]});
                }

                HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                return Json(new {message = Resources["ValidateEmailMessage"]});
            }
            catch (Exception ex)
            {
                logger.EmailSendError(ex);
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
                            EmailManager.SendEmail(email, Configuration.MailServerUserId, subject, body, "", logger);
                        }
                        catch (Exception ex)
                        {
                            logger.FeedbackSendError(ex);
                        }
                    }
                });
                return Json(new {message = Resources["FeedbackSuccess"]});
            }
            catch (Exception ex)
            {
                logger.FeedbackSendError(ex);
                HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                return Json(new {message = ex.Message});
            }
        }
    }
}