using System;
using Aspose.Cells;
using Aspose.Cells.ExternalConnections;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageDatabaseConnection
{
    class GetDataConnection
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            Workbook workbook = new Workbook(sourceDir + "sampleGetDataConnection_WebQuery.xlsx");

            ExternalConnection connection = workbook.DataConnections[0];

            if (connection is WebQueryConnection)
            {
                WebQueryConnection webQuery = (WebQueryConnection)connection;
                Console.WriteLine("Web Query URL: " + webQuery.Url);
            }

            Console.WriteLine("GetDataConnection executed successfully.");
        }
    }
}
