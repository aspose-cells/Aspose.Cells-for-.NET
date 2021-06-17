using System.Collections.Generic;
using Aspose.Cells.Common.Config;
using Newtonsoft.Json;

namespace Aspose.Cells.Common.Models
{
    public class JSOptions
    {
        private readonly ViewModel _parent;
        private FlexibleResources Resources => _parent.Resources;

        public string Product => _parent.Product;
        public string AppURL => _parent.AppUrl;
        public string AppName => _parent.AppName;
        public string APIBasePath => $"/{Product.ToLower()}/{AppName.ToLower()}/api/";

        public string ViewerPath => $"/{Product.ToLower()}/{AppName.ToLower()}/view?";
        public string EditorPath => $"/{Product.ToLower()}/{AppName.ToLower()}/edit?";
        public string ComparisonPath => $"/{Product.ToLower()}/{AppName.ToLower()}/compare?";

        public string FileSelectMessage => Resources["cellsFileSelectMessage"];

        public bool ShowViewerButton => _parent.ShowViewerButton;
        public bool ShowDeleteButton => _parent.ShowDeleteButton;
        public int MaximumUploadFiles => ViewModel.MaximumUploadFiles;
        public int MaxsizeUploadFile => ViewModel.MaxsizeUploadFile;

        public string FileAmountMessage => Resources["cellsFileAmountMessageLessTen"];
        public string FileWrongSizeMessage => Resources["FileMaximumUploadSizeReached"];
        public bool IsAsposeCloudApp => Configuration.IsAsposeCloudApp;
        /// <summary>
        /// Apps like Viewer and Editor
        /// </summary>
        public bool UploadAndRedirect => _parent.UploadAndRedirect;

        public bool UseSorting => _parent.UseSorting;

        public string FileWrongTypeMessage { get; }

        public Dictionary<int, string> FileProcessingErrorCodes => new Dictionary<int, string>
        {
            {(int) FileProcessingErrorCode.NoSearchResults, Resources["cellsNoSearchResultsMessage"]},
            {(int) FileProcessingErrorCode.WrongRegExp, Resources["cellsWrongRegExpMessage"]}
        };

        /// <summary>
        /// ['DOCX', 'DOC', ...]
        /// </summary>
        public IEnumerable<string> UploadOptions => _parent.ExtensionsString.Replace(".", "").ToUpper().Split('|');

        #region FileDrop

        public bool Multiple => !UploadAndRedirect;
        public string DropFilesPrompt => Resources["cellsDropOrUploadFiles"];
        public string DropSourceFilePrompt => Resources["cellsDropOrUploadSourceFile"];
        public string DropTargetFilePrompt => Resources["cellsDropOrUploadTargetFile"];
        public string Accept => _parent.ExtensionsString.Replace("|.", ",.");
        public bool CanWorkWithoutFiles => _parent.CanWorkWithoutFiles;
        public bool DefaultFileBlockDisabled => _parent.DefaultFileBlockDisabled;

        #endregion

        public JSOptions(ViewModel model)
        {
            _parent = model;
            if (string.IsNullOrEmpty(model.Extension) || model.IsCanonical)
                FileWrongTypeMessage = Resources["cellsFileWrongTypeMessage"];
            else
                FileWrongTypeMessage = string.Format(Resources["cellsFileWrongTypeMessage2"], $"<a href=\"/{Product.ToLower()}/{AppName.ToLower()}\">{AppName}</a>");
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }
}