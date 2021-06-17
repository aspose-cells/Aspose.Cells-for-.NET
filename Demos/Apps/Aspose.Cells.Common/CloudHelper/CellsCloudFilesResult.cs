
namespace Aspose.Cells.Common.CloudHelper
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public class CellsCloudFilesResult
    {
        /// <summary>
        /// 
        /// </summary>
        public CellsCloudFilesResult()
        {
            Files = new List<CellsCloudFileInfo>();
        }
        /// <summary>
        /// 
        /// </summary>
        public IList<CellsCloudFileInfo> Files { get; set; }
    }
}
