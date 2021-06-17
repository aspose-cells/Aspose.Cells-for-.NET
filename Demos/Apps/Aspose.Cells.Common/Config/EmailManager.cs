using System;
using System.IO;
using MailKit;
using MailKitClient = MailKit.Net.Smtp.SmtpClient;
using Microsoft.Extensions.Logging;
using MimeKit;
using MailKit.Security;

namespace Aspose.Cells.Common.Config
{
    public static class EmailManager
    {
        public static bool SendEmail(string toEmailAddress, string fromEmailAddress, string subject, string body, string cc, ILogger logger)
        {
            var client = new MailKitClient();

            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(fromEmailAddress));
            message.To.Add(MailboxAddress.Parse(toEmailAddress));
            if (!string.IsNullOrEmpty(cc))
            {
                message.Cc.Add(MailboxAddress.Parse(cc));
            }
            message.Subject = subject;

            var builder = new BodyBuilder
            {
                HtmlBody = body
            };

            message.Body = builder.ToMessageBody();

            client.Timeout = Configuration.MailServerTimeOut;
            client.Connect(Configuration.MailServer, Configuration.MailServerPort, SecureSocketOptions.StartTls);
            client.Authenticate(Configuration.MailServerUserId, Configuration.MailServerUserPassword);

            if (message.To.Count > 0)
            {
                try
                {
                    client.Send(message);
                }
                catch (CommandException ex)
                {
                    logger.EmailSendError(ex);
                    return false;
                }
                catch (ProtocolException ex)
                {
                    logger.EmailSendError(ex);
                    return false;
                }
            }

            return true;
        }

        public static string PopulateBody(string featureTitle, string url, string successMessage)
        {
            string body;
            using (var reader = new StreamReader(Path.Combine(AppContext.BaseDirectory, "App_Data/EmailTemplate.html")!))
                body = reader.ReadToEnd();

            body = body.Replace("{FeatureTitle}", featureTitle);
            body = body.Replace("{Url}", url);
            body = body.Replace("{SuccessMessage}", successMessage);
            return body;
        }
    }
}