using System.Collections.Generic;
using System.Data;

namespace Aspose.Cells.UI.Models
{
    public class FileFormat : BaseDataProvider
    {
        private int _id = 0;
        private string _extension = string.Empty;
        private string _name = string.Empty;
        private string _description = string.Empty;
        private string _fileformat_com_url = string.Empty;

        public FileFormat(int ID)
        {
            _id = ID;
        }

        public FileFormat(string extension)
        {
            _extension = extension;
        }

        internal FileFormat(DataRow dr)
        {
            _id = (int) dr["id"];
            _extension = (string) dr["extension"];
            _name = (string) dr["name"];
            _description = (string) dr["description"];
            _fileformat_com_url = (string) dr["fileformat_com_url"];
        }

        public FileFormat(DTO.SEOApi.FileFormat result)
        {
            _extension = result.Extension;
            _name = result.Name;
            _description = result.Description;
            _fileformat_com_url = result.FileFormatComUrl;
        }

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public string Extension
        {
            get => _extension;
            set => _extension = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public string FileFormat_Com_URL
        {
            get => _fileformat_com_url;
            set => _fileformat_com_url = value;
        }

        public FileFormat GetByExtension()
        {
            var result = _FileFormatService.GetCached(Extension);
            if (result != null)
                return new FileFormat(result);

            return null;
        }

        public static FileFormat GetByExtension(string extension)
        {
            return new FileFormat(extension.ToLower()).GetByExtension();
        }
    }

    public class FileFormats : List<FileFormat>
    {
    }
}