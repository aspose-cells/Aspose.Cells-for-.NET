namespace Aspose.Cells.Common.CloudHelper
{
    using Aspose.Cells.Common.Config;
    using Invoker;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    public class CellsCloudClient
    {
        private ApiInvoker apiInvoker;

        private string token;

        //private string clientId = "91A2FD07-BBA1-4B32-9112-ABFB1FE8AEBD";
        //private string clientSecret = "0fbf678c5ecabdb5caca48452a736dd0";
        //private string  baseUri = "https://api-qa.aspose.cloud";
        public CellsCloudClient()
        {
            var requestHandlers = new List<IRequestHandler>
            {
                new ApiExceptionRequestHandler()
            };

            apiInvoker  = new ApiInvoker(requestHandlers, 30000);
            token = GetJwtTokenUsingClientCredentialsAsync(Configuration.CellsCloudBaseUrl, Configuration.CellsCloudClientId, Configuration.CellsCloudClientSecret);
        }


        public async Task<Stream> Convert(string filename ,Stream stream ,string format)
        {
            var requestUrl = string.Format( "{0}/v3.0/cells/convert?format={1}", Configuration.CellsCloudBaseUrl, format);

            var headerParams = new Dictionary<string, string>();
            headerParams.Add("Authorization", "Bearer " + token);

            Dictionary<string, object> formParams = new Dictionary<string, object>();
            formParams.Add("File", new FormFileInfo
            {
                Name = filename,
                MimeType = format,
                FileContent = stream.ReadAll()
            });

            try
            {
                return await apiInvoker.InvokeApiAsync<Stream>(
                    requestUrl, "PUT", null,headerParams,
                    formParams, "application/octet-stream");
            }
            catch (Exception webException)
            {
               
                throw webException;
            }
        }

        public async Task<CellsCloudFileInfo> Merge(IDictionary<string ,Stream> files, string format,string mergeToOneSheet)
        {
            var requestUrl = string.Format("{0}/v3.0/cells/merge?format={1}&mergeToOneSheet={2}", Configuration.CellsCloudBaseUrl, format, mergeToOneSheet);

            var headerParams = new Dictionary<string, string>();
            headerParams.Add("Authorization", "Bearer " + token);

            Dictionary<string, object> formParams = new Dictionary<string, object>();
            foreach (var file in files)
            {
                formParams.Add(file.Key, new FormFileInfo
                {
                    Name = file.Key,
                    MimeType = format,
                    FileContent = file.Value.ReadAll()
                });
            }

            try
            {
                return await apiInvoker.InvokeApiAsync<CellsCloudFileInfo>(
                    requestUrl, "POST", null, headerParams,
                    formParams, "application/octet-stream");
            }
            catch (Exception webException)
            {

                throw webException;
            }
        }

        public async Task<CellsCloudFilesResult> Split(IDictionary<string, Stream> files, string format)
        {
            var requestUrl = string.Format("{0}/v3.0/cells/split?format={1}", Configuration.CellsCloudBaseUrl, format);

            var headerParams = new Dictionary<string, string>();
            headerParams.Add("Authorization", "Bearer " + token);

            Dictionary<string, object> formParams = new Dictionary<string, object>();
            foreach (var file in files)
            {
                formParams.Add(file.Key, new FormFileInfo
                {
                    Name = file.Key,
                    MimeType = format,
                    FileContent = file.Value.ReadAll()
                });
            }

            try
            {
                return await apiInvoker.InvokeApiAsync<CellsCloudFilesResult>(
                    requestUrl, "POST", null, headerParams,
                    formParams, "application/octet-stream");
            }
            catch (Exception webException)
            {

                throw webException;
            }
        }

        public async Task<CellsCloudFilesResult> WaterMarker(IDictionary<string, Stream> files, string watermarkText, string watermarkColor)
        {
            var requestUrl = string.Format("{0}/v3.0/cells/watermark?text={1}&color={2}",  Configuration.CellsCloudBaseUrl, watermarkText, watermarkColor);

            var headerParams = new Dictionary<string, string>();
            headerParams.Add("Authorization", "Bearer " + token);

            Dictionary<string, object> formParams = new Dictionary<string, object>();
            foreach (var file in files)
            {
                formParams.Add(file.Key, new FormFileInfo
                {
                    Name = file.Key,
                    MimeType =ExportData.GetFileMimeType(file.Key),
                    FileContent = file.Value.ReadAll()
                });
            }

            try
            {
                return await apiInvoker.InvokeApiAsync<CellsCloudFilesResult>(
                    requestUrl, "POST", null, headerParams,
                    formParams, "application/octet-stream");
            }
            catch (Exception webException)
            {

                throw webException;
            }
        }
        public async Task<CellsCloudFilesResult> Export(IDictionary<string, Stream> files, string format,string objectType)
        {
            var requestUrl = string.Format("{0}/v3.0/cells/export?format={1}&objectType={2}",  Configuration.CellsCloudBaseUrl, format, objectType);

            var headerParams = new Dictionary<string, string>();
            headerParams.Add("Authorization", "Bearer " + token);

            Dictionary<string, object> formParams = new Dictionary<string, object>();
            foreach (var file in files)
            {
                formParams.Add(file.Key, new FormFileInfo
                {
                    Name = file.Key,
                    MimeType = format,
                    FileContent = file.Value.ReadAll()
                });
            }

            try
            {
                return await apiInvoker.InvokeApiAsync<CellsCloudFilesResult>(
                    requestUrl, "POST", null, headerParams,
                    formParams, "application/octet-stream");
            }
            catch (Exception webException)
            {

                throw webException;
            }
        }

        public async Task<CellsCloudFilesResult> ClearObjects(IDictionary<string, Stream> files, string objectType)
        {
            var requestUrl = string.Format("{0}/v3.0/cells/clearobjects?objecttype={1}",  Configuration.CellsCloudBaseUrl,  objectType);

            var headerParams = new Dictionary<string, string>();
            headerParams.Add("Authorization", "Bearer " + token);

            Dictionary<string, object> formParams = new Dictionary<string, object>();
            foreach (var file in files)
            {
                formParams.Add(file.Key, new FormFileInfo
                {
                    Name = file.Key,
                    MimeType = ExportData.GetFileMimeType(file.Key),
                    FileContent = file.Value.ReadAll()
                });
            }

            try
            {
                return await apiInvoker.InvokeApiAsync<CellsCloudFilesResult>(
                    requestUrl, "POST", null, headerParams,
                    formParams, "application/octet-stream");
            }
            catch (Exception webException)
            {

                throw webException;
            }
        }

        public async Task<CellsCloudFilesResult> Assembly(IDictionary<string, Stream> files, string datasource)
        {
            var requestUrl = string.Format("{0}/v3.0/cells/assemble?datasource={1}",  Configuration.CellsCloudBaseUrl, datasource);

            var headerParams = new Dictionary<string, string>();
            headerParams.Add("Authorization", "Bearer " + token);

            Dictionary<string, object> formParams = new Dictionary<string, object>();
            foreach (var file in files)
            {
                formParams.Add(file.Key, new FormFileInfo
                {
                    Name = file.Key,
                    MimeType = ExportData.GetFileMimeType(file.Key),
                    FileContent = file.Value.ReadAll()
                });
            }

            try
            {
                return await apiInvoker.InvokeApiAsync<CellsCloudFilesResult>(
                    requestUrl, "POST", null, headerParams,
                    formParams, "application/octet-stream");
            }
            catch (Exception webException)
            {

                throw webException;
            }
        }

        public async Task<CellsCloudFilesResult> Unlock(IDictionary<string, Stream> files,string password)
        {
            var requestUrl = string.Format("{0}/v3.0/cells/unlock?password={1}",  Configuration.CellsCloudBaseUrl, password);

            var headerParams = new Dictionary<string, string>();
            headerParams.Add("Authorization", "Bearer " + token);

            Dictionary<string, object> formParams = new Dictionary<string, object>();
            foreach (var file in files)
            {
                formParams.Add(file.Key, new FormFileInfo
                {
                    Name = file.Key,
                    MimeType = ExportData.GetFileMimeType(file.Key),
                    FileContent = file.Value.ReadAll()
                });
            }

            try
            {
                return await apiInvoker.InvokeApiAsync<CellsCloudFilesResult>(
                    requestUrl, "POST", null, headerParams,
                    formParams, "application/octet-stream");
            }
            catch (Exception webException)
            {

                throw webException;
            }
        }
        public async Task<CellsCloudFilesResult> PostMetadata(IDictionary<string, Stream> files,string type ,IList<CellsDocumentProperty> cellsDocumentProperties)
        {
            var requestUrl = string.Format("{0}/v3.0/cells/metadata/update",  Configuration.CellsCloudBaseUrl);

            var headerParams = new Dictionary<string, string>();
            headerParams.Add("Authorization", "Bearer " + token);

            Dictionary<string, object> formParams = new Dictionary<string, object>();
            foreach (var file in files)
            {
                formParams.Add(file.Key, new FormFileInfo
                {
                    Name = file.Key,
                    MimeType = ExportData.GetFileMimeType(file.Key),
                    FileContent = file.Value.ReadAll()
                });
            }
            var jsonArray = JsonSerializationHelper.Serialize(cellsDocumentProperties);
            formParams.Add("DocumentProperties", new FormFileInfo
            {
                Name = "DocumentProperties", 
                MimeType = "application/json",
                FileContent = Encoding.ASCII.GetBytes(jsonArray)
            });
            try
            {
                return await apiInvoker.InvokeApiAsync<CellsCloudFilesResult>(
                    requestUrl, "POST", null, headerParams,
                    formParams, "application/octet-stream");
            }
            catch (Exception webException)
            {

                throw webException;
            }
        }
        public async Task<CellsCloudFilesResult> DeleteMetadata(IDictionary<string, Stream> files, string type)
        {
            var requestUrl = string.Format("{0}/v3.0/cells/metadata/delete?type={1}",  Configuration.CellsCloudBaseUrl, type);

            var headerParams = new Dictionary<string, string>();
            headerParams.Add("Authorization", "Bearer " + token);

            Dictionary<string, object> formParams = new Dictionary<string, object>();
            foreach (var file in files)
            {
                formParams.Add(file.Key, new FormFileInfo
                {
                    Name = file.Key,
                    MimeType = ExportData.GetFileMimeType(file.Key),
                    FileContent = file.Value.ReadAll()
                });
            }
           
            try
            {
                return await apiInvoker.InvokeApiAsync<CellsCloudFilesResult>(
                    requestUrl, "POST", null, headerParams,
                    formParams, "application/octet-stream");
            }
            catch (Exception webException)
            {

                throw webException;
            }
        }

        public async Task<IList<CellsDocumentProperty>> GetMetadata(IDictionary<string, Stream> files, string type)
        {
            var requestUrl = string.Format("{0}/v3.0/cells/metadata/get?type={1}",  Configuration.CellsCloudBaseUrl, type);

            var headerParams = new Dictionary<string, string>();
            headerParams.Add("Authorization", "Bearer " + token);

            Dictionary<string, object> formParams = new Dictionary<string, object>();
            foreach (var file in files)
            {
                formParams.Add(file.Key, new FormFileInfo
                {
                    Name = file.Key,
                    MimeType = ExportData.GetFileMimeType(file.Key),
                    FileContent = file.Value.ReadAll()
                });
            }

            try
            {
                return await apiInvoker.InvokeApiAsync<IList<CellsDocumentProperty>>(
                    requestUrl, "POST", null, headerParams,
                    formParams);
            }
            catch (Exception webException)
            {

                throw webException;
            }
        }

        public async Task<IList<TextItem>> Search(IDictionary<string, Stream> files, string query)
        {
            var requestUrl = string.Format("{0}/v3.0/cells/search?text={1}",  Configuration.CellsCloudBaseUrl, query);

            var headerParams = new Dictionary<string, string>();
            headerParams.Add("Authorization", "Bearer " + token);

            Dictionary<string, object> formParams = new Dictionary<string, object>();
            foreach (var file in files)
            {
                formParams.Add(file.Key, new FormFileInfo
                {
                    Name = file.Key,
                    MimeType = ExportData.GetFileMimeType(file.Key),
                    FileContent = file.Value.ReadAll()
                });
            }

            try
            {
                return await apiInvoker.InvokeApiAsync<IList<TextItem>>(
                    requestUrl, "POST", null, headerParams,
                    formParams, "application/octet-stream");
            }
            catch (Exception webException)
            {

                throw webException;
            }
        }

        public async Task<CellsCloudFilesResult> Protect(IDictionary<string, Stream> files, string password)
        {
            var requestUrl = string.Format("{0}/v3.0/cells/protect?password={1}",  Configuration.CellsCloudBaseUrl, password);

            var headerParams = new Dictionary<string, string>();
            headerParams.Add("Authorization", "Bearer " + token);

            Dictionary<string, object> formParams = new Dictionary<string, object>();
            foreach (var file in files)
            {
                formParams.Add(file.Key, new FormFileInfo
                {
                    Name = file.Key,
                    MimeType = ExportData.GetFileMimeType(file.Key),
                    FileContent = file.Value.ReadAll()
                });
            }

            try
            {
                return await apiInvoker.InvokeApiAsync<CellsCloudFilesResult>(
                    requestUrl, "POST", null, headerParams,
                    formParams, "application/octet-stream");
            }
            catch (Exception webException)
            {

                throw webException;
            }
        }
        private string GetJwtTokenUsingClientCredentialsAsync( string apiBaseUrl, string clientId, string clientSecret)
        {
            try
            {
                var requestUrl = string.Format("{0}/connect/token", apiBaseUrl);

                var postData = "grant_type=client_credentials";
                postData += "&client_id=" + clientId;
                postData += "&client_secret=" + clientSecret;

                return apiInvoker.InvokeApiAsync<JwtTokenResource>(requestUrl, "POST", postData, contentType: "application/x-www-form-urlencoded").Result.AccessToken;
            }
            catch( Exception e)
            {
                throw e;
            }
        }
       

    }
}
