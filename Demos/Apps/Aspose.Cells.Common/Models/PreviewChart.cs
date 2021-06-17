using System.Collections.Generic;

namespace Aspose.Cells.Common.Models
{
    public class PreviewChart
    {
        public int WorkbookHash { get; set; }

        public int SheetIndex { get; set; }

        public int ChartHash { get; set; }

        public string ChartName { get; set; }

        public string ImgFolderName { get; set; }

        public string ImgFileName { get; set; }
    }

    public class PreviewChartsResponse : Response
    {
        public List<PreviewChart> Charts { get; set; }

        public string OutputType { get; set; }
    }
}