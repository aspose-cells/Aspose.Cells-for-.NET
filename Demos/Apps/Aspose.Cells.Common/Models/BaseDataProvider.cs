using Aspose.Cells.Common.Services;

namespace Aspose.Cells.Common.Models
{
    /// <summary>
    /// Base class to be used for all the database access and provider design, Uses and forces database calls
    /// </summary>
    public abstract class BaseDataProvider
    {
        protected static GeneratedPagesService GeneratedPagesService = new GeneratedPagesService();
        protected static FileFormatService FileFormatService = new FileFormatService();
    }
}