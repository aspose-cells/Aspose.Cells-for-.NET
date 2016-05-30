using System;
using Aspose.Cells;
using Aspose.Cells.ExternalConnections;

namespace CSharp.Articles
{
    class GetDataConnection
    {
        public static void Run()
        {
                // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Workbook workbook = new Workbook(dataDir + "WebQuerySample.xlsx");

            ExternalConnection connection = workbook.DataConnections[0];

            if (connection is WebQueryConnection)
            {
                WebQueryConnection webQuery = (WebQueryConnection)connection;
                Console.WriteLine("Web Query URL: " + webQuery.Url);
            }
        }
            // ExEnd:1
    }
}
