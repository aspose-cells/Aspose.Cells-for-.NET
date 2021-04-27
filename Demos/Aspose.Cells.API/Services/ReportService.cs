using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Aspose.Cells.API.Config;
using Newtonsoft.Json;

namespace Aspose.Cells.API.Services
{
    public class ReportService
    {
        public static ReportResult Submit(ReportModel model)
        {
            Task.Run(() => { UploadFile(model); });
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-FORUM-API-Key", AppSettings.ForumKey);
            var requestData = ForumTopic.GetTopic(model);
            HttpContent content = new StringContent(JsonConvert.SerializeObject(requestData));
            //content.Headers.Add("X-FORUM-API-Key", AppSettings.ForumKey);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = httpClient.PostAsync(AppSettings.ForumUrl, content).Result;

            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<dynamic>(jsonResult);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (data.error != null)
                {
                    throw new Exception("forum bad gateway:" + data.error);
                }

                throw new Exception("forum bad gateway");
            }

            if (data.error != null)
            {
                return new ReportResult
                {
                    StatusCode = 500,
                    Status = data.error,
                };
            }

            if (data.url != null)
            {
                return new ReportResult
                {
                    StatusCode = 200,
                    ForumLink = data.url,
                };
            }

            throw new Exception("forum api result error");
        }

        public static void UploadFile(ReportModel model)
        {
            var sourcePath = Path.Combine(AppSettings.WorkingDirectory, model.ErrorFolderName);
            var reportPath = Path.Combine(AppSettings.ReportDirectory, model.ErrorFolderName);
            if (!Directory.Exists(sourcePath)) return;
            if (!Directory.Exists(reportPath))
            {
                Directory.CreateDirectory(reportPath);
            }

            foreach (var file in Directory.GetFiles(sourcePath))
            {
                var fileInfo = new System.IO.FileInfo(file);
                fileInfo.CopyTo(Path.Combine(reportPath, fileInfo.Name));
            }
        }
    }

    public class ForumRequest
    {
        public ForumTopic topic { get; set; }
    }

    public class CustomFields
    {
        public bool is_private { get; set; }
    }

    public class ForumTopic
    {
        public string title { get; set; }
        public int category_id { get; set; }
        public bool notification { get; set; }
        public ForumUser user { get; set; }
        public Forumposts[] posts { get; set; }
        public CustomFields custom_fields { get; set; }

        public static ForumRequest GetTopic(ReportModel model)
        {
            var user = new ForumUser
            {
                username = model.Email.Replace("@", "_at_"),
                email = model.Email,
            };
            var topic = new ForumTopic
            {
                title = model.ErrorAction.Replace(" ", "-") + "-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"),
                category_id = int.Parse(AppSettings.ForumCategoryId),
                notification = true,
                posts = new[]
                {
                    new Forumposts
                    {
                        user = user,
                        raw = $"SessionId->{model.ErrorFolderName}->{model.ErrorAction}->{model.ErrorMessage}"
                    }
                },
                custom_fields = new CustomFields
                {
                    is_private = model.Private,
                },
                user = user,
            };
            return new ForumRequest {topic = topic};
        }
    }

    public class ForumUser
    {
        public string email { get; set; }
        public string username { get; set; }
    }

    public class Forumposts
    {
        public string raw { get; set; }
        public ForumUser user { get; set; }
    }

    public class ReportModel
    {
        public string Email { get; set; }
        public string ErrorFolderName { get; set; }
        public string ErrorAction { get; set; }
        public string ErrorMessage { get; set; }
        public bool Private { get; set; }
    }

    public class ReportResult
    {
        public int StatusCode { get; set; }
        public string ForumLink { get; set; }
        public string Status { get; set; }
    }
}