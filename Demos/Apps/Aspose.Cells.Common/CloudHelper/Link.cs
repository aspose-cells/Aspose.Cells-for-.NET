namespace Aspose.Cells.Common.CloudHelper
{
    using System.Xml.Serialization;
    /// <summary>
    /// 
    /// </summary>
    public class Link
    {
        /// <summary>
        /// 
        /// </summary>
        public Link()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="href"></param>
        public Link(string href)
        {
            this.Href = href;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="href"></param>
        /// <param name="rel"></param>
        public Link(string href, string rel)
        {
            this.Href = href;
            this.Rel = rel;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="href"></param>
        /// <param name="rel"></param>
        /// <param name="type"></param>
        /// <param name="title"></param>
        public Link(string href, string rel, string type, string title)
        {
            this.Href = href;
            this.Rel = rel;
            this.Type = type;
            this.Title = title;
        }
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "href")]
        public string Href { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "rel")]
        public string Rel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
    }
}
