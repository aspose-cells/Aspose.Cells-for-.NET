using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Aspose.Cells.UI.Config;

namespace Aspose.Cells.UI.Models
{
    public static class FileManager
    {
        public static FileUploadResult UploadFile(string file, string userEmail)
        {
            FileUploadResult uploadResult = null;
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // Read the files                 
                var fileStream = File.Open(file, FileMode.Open);
                var fileInfo = new FileInfo(file);

                var content = new MultipartFormDataContent {{new StreamContent(fileStream), $"\"{fileInfo.Name}\"", $"\"{fileInfo.Name}\""}};

                var taskUpload = httpClient.PostAsync(Configuration.AsposeToolsAPIBasePath + "api/AsposeAppWeb/UploadFile" + "?userEmail=" + userEmail, content).ContinueWith(task =>
                {
                    if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
                    {
                        var response = task.Result;

                        if (response.IsSuccessStatusCode)
                        {
                            uploadResult = response.Content.ReadAsAsync<FileUploadResult>().Result;
                        }
                    }

                    fileStream.Dispose();
                });

                taskUpload.Wait();
                httpClient.Dispose();
                // Delete input file 
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return uploadResult;
        }

        public static Collection<FileUploadResult> UploadFiles(string userEmail, params string[] files)
        {
            Collection<FileUploadResult> uploadResult = null;
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new MultipartFormDataContent();
                var fileStreams = new List<FileStream>();
                foreach (var file in files)
                {
                    var fileStream = File.Open(file, FileMode.Open);
                    var fileInfo = new FileInfo(file);
                    content.Add(new StreamContent(fileStream), "\"file\"", string.Format("\"{0}\"", fileInfo.Name));
                    fileStreams.Add(fileStream);
                }

                var taskUpload = httpClient.PostAsync(Configuration.AsposeToolsAPIBasePath + "api/AsposeAppWeb/UploadFiles" + "?userEmail=" + userEmail,
                    content).ContinueWith(task =>
                {
                    if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
                    {
                        var response = task.Result;
                        if (response.IsSuccessStatusCode)
                            uploadResult = response.Content.ReadAsAsync<Collection<FileUploadResult>>().Result;
                    }

                    foreach (var fileStream in fileStreams)
                        fileStream.Dispose();
                });

                taskUpload.Wait();
                httpClient.Dispose();

                // Delete input files
                foreach (var file in files)
                    if (File.Exists(file))
                        File.Delete(file);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return uploadResult;
        }

        public static HttpResponseMessage DownloadFile(string fileName)
        {
            HttpResponseMessage result;

            using (var httpClient = new HttpClient())
            {
                var url = Configuration.AsposeToolsAPIBasePath + "api/AsposeAppWeb/DownloadFile?outFile=" + System.Web.HttpUtility.UrlEncode(fileName);

                result = httpClient.GetAsync(url).Result;
            }

            return result;
        }

        public static HttpResponseMessage DownloadFile(string fileName, string folderName)
        {
            HttpResponseMessage result;

            using (var httpClient = new HttpClient())
            {
                var url = Configuration.AsposeToolsAPIBasePath + "api/AsposeAppWeb/DownloadFile?outFile=" + System.Web.HttpUtility.UrlEncode(fileName) + "&outFolder=" + folderName;

                result = httpClient.GetAsync(url).Result;
            }

            return result;
        }

        public static string DownloadSave(string fileName)
        {
            HttpResponseMessage result;
            var filePath = Configuration.AssetPath + fileName;
            using (var httpClient = new HttpClient())
            {
                var url = Configuration.AsposeToolsAPIBasePath + "api/AsposeAppWeb/DownloadFile?outFile=" + System.Web.HttpUtility.UrlEncode(fileName);

                result = httpClient.GetAsync(url).Result;
            }

            if (!result.IsSuccessStatusCode) return filePath;
            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var taskDownload = result.Content.CopyToAsync(fs).ContinueWith(task =>
                {
                    if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
                    {
                        if (task.IsCompleted)
                        {
                        }
                    }

                    fs.Dispose();
                });
                taskDownload.Wait();
            }

            return filePath;
        }
    }
}