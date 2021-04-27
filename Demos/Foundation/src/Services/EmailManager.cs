using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Timers;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace Tools.Foundation.Services
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class BaseEmailManager
	{
		protected abstract string GetMailServer();
		protected abstract int GetMailServerPort();
		protected abstract int GetMailServerTimeOut();
		protected abstract string GetMailServerUserId();
		protected abstract string GetMailServerUserPassword();

		// TODO: refactor this copypasting.
		public bool SendEmail(string toEmailAddress, string fromEmailAddress, string subject, string body, string CC)
		{
			SmtpClient smtp = new SmtpClient();
			MailMessage message = new MailMessage();
			try
			{
				message.To.Add(toEmailAddress);
				message.From = new MailAddress(fromEmailAddress);
				if (CC != "")
				{
					message.CC.Add(CC);
				}
				message.Subject = subject;
				message.Body = body;
				message.IsBodyHtml = true;
				smtp.UseDefaultCredentials = false;
				smtp.Host = GetMailServer();
				smtp.Port = GetMailServerPort();
				smtp.Timeout = GetMailServerTimeOut();

				smtp.EnableSsl = true;

				smtp.Credentials = new NetworkCredential(GetMailServerUserId(), GetMailServerUserPassword());
				if (message.To.Count > 0)
				{
					smtp.Send(message);
				}

			}
			finally
			{
				message.Dispose();
			}

			return true;
		}
		public bool SendEmailWithAttachment(string toEmailAddress, string fromEmailAddress, string subject, string body, string CC, string Certificates)
		{
			SmtpClient smtp = new SmtpClient();
			MailMessage message = new MailMessage();
			try
			{
				message.To.Add(toEmailAddress);
				message.From = new MailAddress(fromEmailAddress);
				if (CC != "")
				{
					message.CC.Add(CC);
				}
				message.Subject = subject;
				message.Body = body;
				message.IsBodyHtml = true;
				smtp.UseDefaultCredentials = false;
				smtp.Host = GetMailServer();
				smtp.Port = GetMailServerPort();
				smtp.Timeout = GetMailServerTimeOut();
				smtp.EnableSsl = true;

				if (Certificates != "")
				{
					message.Attachments.Add(new Attachment(Certificates));
				}

				smtp.Credentials = new NetworkCredential(GetMailServerUserId(), GetMailServerUserPassword());
				if (message.To.Count > 0)
				{
					smtp.Send(message);
				}

			}
			finally
			{
				message.Dispose();
			}
			return true;
		}

		public string PopulateBody(string featureTitle, string url, string successMessage)
		{
			string body = string.Empty;
			using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/EmailTemplate.html")))
			{
				body = reader.ReadToEnd();
			}
			body = body.Replace("{FeatureTitle}", featureTitle);
			body = body.Replace("{Url}", url);
			body = body.Replace("{SuccessMessage}", successMessage);
			return body;
		}
	}
}
