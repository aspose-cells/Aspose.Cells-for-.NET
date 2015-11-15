using System;
using Aspose.Cells;
using Aspose.Cells.ExternalConnections;

namespace Aspose.Cells.Examples.Articles
{
    class GetDataConnection
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Workbook workbook = new Workbook(dataDir + "WebQuerySample.xlsx");

            ExternalConnection connection = workbook.DataConnections[0];

            if (connection is WebQueryConnection)
            {
                WebQueryConnection webQuery = (WebQueryConnection)connection;
                Console.WriteLine("Web Query URL: " + webQuery.Url);
            }
        }
    }
}
