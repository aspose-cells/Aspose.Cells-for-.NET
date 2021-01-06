using System;

namespace Aspose.Cells.UI.Models
{
    public class UploadFileModel
    {
        public bool AcceptMultipleFiles { get; set; }
        public string FileDropKey { get; set; }
        public string AcceptedExtentions { get; set; }
        public FlexibleResources Resources { get; }
        public string UploadId { get; set; } = $"{Guid.NewGuid()}";

        public UploadFileModel(FlexibleResources resources)
        {
            Resources = resources;
        }
    }
}