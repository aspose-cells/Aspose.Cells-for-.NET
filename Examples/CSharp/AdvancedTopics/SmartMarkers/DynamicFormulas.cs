using System.IO;
using System;
using Aspose.Cells;
namespace CSharp.AdvancedTopics.SmartMarkers
{
    public class DynamicFormulas
    {
        public static void Run()
        {
            try
            {
                //ExStart:DynamicFormulas
                // The path to the documents directory.
                string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

                // Create directory if it is not already present.
                bool IsExists = System.IO.Directory.Exists(dataDir);
                if (!IsExists)
                    System.IO.Directory.CreateDirectory(dataDir);


                // Instantiating a WorkbookDesigner object
                WorkbookDesigner designer = new WorkbookDesigner();

                // Open a designer spreadsheet containing smart markers
                designer.Workbook = new Workbook(designerFile);

                // Set the data source for the designer spreadsheet
                designer.SetDataSource(dataset);

                // Process the smart markers
                designer.Process();
                //ExEnd:DynamicFormulas    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public static Stream designerFile { get; set; }

        public static System.Data.SqlClient.SqlConnection dataset { get; set; }
    }
}