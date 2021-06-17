namespace Aspose.Cells.Common.Models
{
    public class FileFormat : BaseDataProvider
    {
        public FileFormat(string extension)
        {
            Extension = extension;
        }

        public FileFormat(DTO.SEOApi.FileFormat result)
        {
            Extension = result.Extension;
            Name = result.Name;
            Description = result.Description;
            FileFormatComUrl = result.FileFormatComUrl;
        }

        public int Id { get; set; }

        public string Extension { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string FileFormatComUrl { get; set; } = string.Empty;

        public FileFormat GetByExtension()
        {
            var result = FileFormatService.GetCached(Extension);
            return result != null ? new FileFormat(result) : null;
        }

        public static FileFormat GetByExtension(string extension)
        {
            return new FileFormat(extension.ToLower()).GetByExtension();
        }
    }
}