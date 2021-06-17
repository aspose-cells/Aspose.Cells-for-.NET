namespace Aspose.Cells.Common.CloudHelper
{
    /// <summary>
    /// 
    /// </summary>
    public class CellsDocumentProperty 
    {
        /// <summary>
        ///  Returns the name of the property.
        /// </summary>
        public string Name { get; set; }
  
        /// <summary>
        /// Gets or sets the value of the property.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Indicates whether this property is linked to content
        /// </summary>
        public string IsLinkedToContent { get; set; }

        /// <summary>
        /// The linked content source.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        ///  Gets the data type of the property.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///  Returns true if this property does not have a name in the OLE2 storage and a 
        ///   unique name was generated only for the public API.
        /// </summary>
        public string IsGeneratedName { get; set; }
    }
}
