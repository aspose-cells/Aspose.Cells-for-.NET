namespace Aspose.Cells.API.Models
{
    ///<Summary>
    /// License class to set apose products license
    ///</Summary>
    public static class License
    {
        ///<Summary>
        /// SetAsposeCellsLicense method to Aspose.Cells License
        ///</Summary>
        public static void SetCellsLicense()
        {
            var acLic = new Aspose.Cells.License();
            acLic.SetLicense("Aspose.Total.lic");
        }
    }
}