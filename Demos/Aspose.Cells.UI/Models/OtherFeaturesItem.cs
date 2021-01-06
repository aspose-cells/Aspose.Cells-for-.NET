namespace Aspose.Cells.UI.Models
{
    public class OtherFeaturesItem
    {
        /// <summary>
        /// Url for anchor
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// TitleSub
        /// </summary>
        public string TitleSub { get; set; }

        public OtherFeaturesItem(GeneratedPage page)
        {
            URL = page.URL;
            Title = page.Name;
            TitleSub = $"({page.MainHeadline})";
        }
    }
}