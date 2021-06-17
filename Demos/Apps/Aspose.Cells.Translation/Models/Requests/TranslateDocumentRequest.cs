namespace Aspose.Cells.Translation.Models.Requests
{
    public class TranslateDocumentRequest
    {
        public TranslateDocumentRequest(string userRequest)
        {
            UserRequest = userRequest;
        }

        public string UserRequest { get; set; }
    }
}