namespace Aspose.Cells.Common.Models
{
    public class OtherFeaturesItem
    {
        /// <summary>
        /// Url for anchor
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        public OtherFeaturesItem(GeneratedPage page)
        {
            Url = page.Url;
            Title = page.Name;
        }
    }
}