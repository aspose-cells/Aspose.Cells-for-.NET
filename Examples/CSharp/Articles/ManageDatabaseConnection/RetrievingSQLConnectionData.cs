using System.IO;

using Aspose.Cells;
using Aspose.Cells.ExternalConnections;
using System;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageDatabaseConnection
{
    public class RetrievingSQLConnectionData
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Create a workbook object from source file
            Workbook workbook = new Workbook(sourceDir + "sampleRetrievingSQLConnectionData.xlsx");

            // Access the external collections
            ExternalConnectionCollection connections = workbook.DataConnections;

            int connectionCount = connections.Count;

            ExternalConnection connection = null;

            for (int i = 0; i < connectionCount; i++)
            {
                connection = connections[i];

                // Check if the Connection is DBConnection, then retrieve its various properties
                if (connection is DBConnection)
                {

                    DBConnection dbConn = (DBConnection)connection;

                    // Retrieve DB Connection Command
                    Console.WriteLine("Command: " + dbConn.Command);

                    // Retrieve DB Connection Command Type
                    Console.WriteLine("Command Type: " + dbConn.CommandType);

                    // Retrieve DB Connection Description
                    Console.WriteLine("Description: " + dbConn.ConnectionDescription);

                    // Retrieve DB Connection ID
                    Console.WriteLine("Id: " + dbConn.ConnectionId);

                    // Retrieve DB Connection Info
                    Console.WriteLine("Info: " + dbConn.ConnectionInfo);

                    // Retrieve DB Connection Credentials
                    Console.WriteLine("Credentials: " + dbConn.CredentialsMethodType);

                    // Retrieve DB Connection Name
                    Console.WriteLine("Name: " + dbConn.Name);

                    // Retrieve DB Connection ODC File
                    Console.WriteLine("OdcFile: " + dbConn.OdcFile);

                    // Retrieve DB Connection Source File
                    Console.WriteLine("Source file: " + dbConn.SourceFile);

                    // Retrieve DB Connection Type
                    Console.WriteLine("Type: " + dbConn.Type);

                    // Retrieve DB Connection Parameters Collection
                    ConnectionParameterCollection paramCollection = dbConn.Parameters;

                    int paramCount = paramCollection.Count;

                    // Iterate the Parameter Collection
                    for (int j = 0; j < paramCount; j++)
                    {
                        ConnectionParameter param = paramCollection[j];

                        // Retrieve Parameter Cell Reference
                        Console.WriteLine("Cell reference: " + param.CellReference);

                        // Retrieve Parameter Name
                        Console.WriteLine("Parameter name: " + param.Name);

                        // Retrieve Parameter Prompt
                        Console.WriteLine("Prompt: " + param.Prompt);

                        // Retrieve Parameter SQL Type
                        Console.WriteLine("SQL Type: " + param.SqlType);

                        // Retrieve Parameter Type
                        Console.WriteLine("Param Type: " + param.Type);

                        // Retrieve Parameter Value
                        Console.WriteLine("Param Value: " + param.Value);

                    }// End for
                }// End if
            }// End for

            Console.WriteLine("RetrievingSQLConnectionData executed successfully.");
        }
    }
}