namespace Aspose.Cells.Common.Models
{
    public class Options
    {
        ///<Summary>
        /// AppName
        ///</Summary>
        public string AppName;

        ///<Summary>
        /// FolderName
        ///</Summary>
        public string FolderName;

        ///<Summary>
        /// FileName
        ///</Summary>
        public string FileName;

        private string _outputType;

        /// <summary>
        /// By default, it is the extension of FileName
        /// </summary>
        public string OutputType
        {
            get => _outputType;
            set
            {
                if (!value.StartsWith("."))
                    value = "." + value;
                _outputType = value;
            }
        }

        /// <summary>
        /// Check if OutputType is a picture extension
        /// </summary>
        public bool IsPicture
        {
            get
            {
                return _outputType.ToLower() switch
                {
                    ".bmp" => true,
                    ".png" => true,
                    ".jpg" => true,
                    ".jpeg" => true,
                    ".tiff" => true,
                    ".svg" => true,
                    _ => false
                };
            }
        }

        ///<Summary>
        /// ResultFileName
        ///</Summary>
        public string ResultFileName;

        ///<Summary>
        /// MethodName
        ///</Summary>
        public string MethodName;

        ///<Summary>
        /// ControllerName
        ///</Summary>
        public string ControllerName;

        ///<Summary>
        /// CreateZip
        ///</Summary>
        public bool CreateZip;

        ///<Summary>
        /// CheckNumberOfPages
        ///</Summary>
        public bool CheckNumberOfPages = false;

        ///<Summary>
        /// DeleteSourceFolder
        ///</Summary>
        public bool DeleteSourceFolder = false;

        ///<Summary>
        /// CalculateZipFileName
        ///</Summary>
        public bool CalculateZipFileName = true;

        /// <summary>
        /// Output zip filename (without '.zip'), if CreateZip property is true
        /// By default, FileName + AppName
        /// </summary>
        public string ZipFileName;
    }
}