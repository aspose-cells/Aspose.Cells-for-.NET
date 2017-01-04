namespace Aspose.Cells.Examples.CSharp.Articles
{
    class SettingScaleCropAndLinksUpToDateProperties
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Setting ScaleCrop and LinksUpToDate BuiltIn Document Properties
            workbook.BuiltInDocumentProperties.ScaleCrop = true;
            workbook.BuiltInDocumentProperties.LinksUpToDate = true;

            // Saving the Excel file
            workbook.Save(dataDir + "output.xls", SaveFormat.Auto);
            // ExEnd:1


        }
    }
}
