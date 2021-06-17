namespace Aspose.Cells.Common.Models
{
    public class AnotherApp
    {
        public string ImageSource { get; set; }
        public string ImageAlt { get; set; }
        public string AppName { get; set; }
        public string Href { get; set; }
        public string DisplayName { get; set; }

        public AnotherApp()
        {
            // Empty for inheritance
        }

        public AnotherApp(string currAppName, string appName)
        {
            string[] parts = appName.Split('-');
            if (parts.Length > 1)
            {
                DisplayName = parts[0];
            }
            else
            {
                DisplayName = appName;
            }
            AppName = appName;
            Href = $"/cells/{appName.ToLower()}";
            ImageSource = $"/cells/{currAppName.ToLower()}/content/img/apps/aspose_{appName.ToLower()}-app.png";
            ImageAlt = $"{AppName}";
        }
    }
}