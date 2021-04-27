namespace Aspose.Cells.UI.Models
{
    /// <summary>
    /// Prepares Extension and HowTo sections
    /// Changes Title and TitleSub in ViewModel
    /// </summary>
    public class ExtensionInfoModel
    {
        public ViewModel Parent;

        /// <summary>
        /// File extension without dot received by "fileformat" value in RouteData (e.g. docx)
        /// </summary>
        public string Extension { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public string AppName => Parent.AppName;

        public GeneratedPage GeneratedPage => Parent.GeneratedPage;

        public ExtensionInfoModel(ViewModel parent, string extension)
        {
            Parent = parent;
            Extension = extension;
            if (Extension.Equals("excel"))
            {
                Extension = "xlsx";
            }

            var fileformat = FileFormat.GetByExtension(Extension.ToLower());
            Name = fileformat.Name;
            Description = fileformat.Description;
            Url = fileformat.FileFormatComUrl;
        }
    }
}