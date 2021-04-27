using System.Web;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace Aspose.Cells.UI.Config
{
    /// <summary>
    /// ///////////////This class is for managing sending emails to users on completion of any aspose app
    /// </summary>
    public class EmailManager
    {
        public EmailManager()
        {
            //
            // TODO: Add constructor logic here
            //
        }                     
        public  static bool SendEmail(string toEmailAddress, string fromEmailAddress,  string subject, string body, string CC)
        {            
            SmtpClient smtp = new SmtpClient();
            MailMessage message = new MailMessage();
            try
            {                
                message.To.Add(toEmailAddress);
                message.From = new MailAddress(fromEmailAddress);    
                if(CC != "")
                {
                    message.CC.Add(CC);    
                }
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;
                smtp.UseDefaultCredentials = false;
                smtp.Host = Configuration.MailServer;
                smtp.Port = Configuration.MailServerPort;
                smtp.Timeout = Configuration.MailServerTimeOut;
                
                smtp.EnableSsl = true;
               
                smtp.Credentials = new NetworkCredential(Configuration.MailServerUserId, Configuration.MailServerUserPassword);                
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
        public static bool SendEmailWithAttachment(string toEmailAddress, string fromEmailAddress, string subject, string body, string CC, string Certificates)
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
                smtp.Host = Configuration.MailServer;
                smtp.Port = Configuration.MailServerPort;
                smtp.Timeout = Configuration.MailServerTimeOut;
                smtp.EnableSsl = true;

                if (Certificates != "")
                {
                    message.Attachments.Add(new Attachment(Certificates));
                }

                smtp.Credentials = new NetworkCredential(Configuration.MailServerUserId, Configuration.MailServerUserPassword);
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

        public static string PopulateBody(string featureTitle, string url, string successMessage)
        {
          if (url.Contains(HttpUtility.UrlEncode("://")))
            url = HttpUtility.UrlDecode(url);

          string body;
          using (var reader = new StreamReader(Path.Combine(HttpRuntime.AppDomainAppPath, "App_Data/EmailTemplate.html"))) // HttpContext.Current.Server.MapPath("~/App_Data/EmailTemplate.html"))
            body = reader.ReadToEnd();
            
          body = body.Replace("{FeatureTitle}", featureTitle);
          body = body.Replace("{Url}", url);
          body = body.Replace("{SuccessMessage}", successMessage);
          return body;
        }

    }

}
