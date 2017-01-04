namespace Aspose.Cells.Examples.CSharp.Articles
{
    class ExportXmlMapFromWorkbook
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
            Workbook workbook = new Workbook(dataDir + "sample.xlsx");

            // Export all XML data from all XML Maps from the Workbook
            for (int i = 0; i < workbook.Worksheets.XmlMaps.Count; i++)
            {
                // Access the XML Map
                XmlMap map = workbook.Worksheets.XmlMaps[i];

                // Exports its XML Data to file
                workbook.ExportXml(map.Name, dataDir + map.Name + ".xml");
            }
            // ExEnd:1
        }
    }
}
