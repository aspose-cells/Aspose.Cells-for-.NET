namespace Aspose.Cells.Translation.Models.Requests
{
    public class TranslateTextRequest
    {
        public TranslateTextRequest(string userRequest)
        {
            UserRequest = userRequest;
        }

        public string UserRequest { get; set; }
    }
}