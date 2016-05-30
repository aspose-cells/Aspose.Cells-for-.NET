using System;
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Tables;
using Aspose.Cells.ExternalConnections;
using System.Collections;

namespace CSharp.Articles
{
    public class FindQueryTablesAndListObjectsOfExternalDataConnections
    {
        public static void Run()
        {
            // ExStart:FindQueryTablesAndListObjectsOfExternalDataConnections
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load workbook object
            Workbook workbook = new Workbook(dataDir + "sample.xlsm");

            // Check all the connections inside the workbook
            for (int i = 0; i < workbook.DataConnections.Count; i++)
            {
                Aspose.Cells.ExternalConnections.ExternalConnection externalConnection = workbook.DataConnections[i];
                Console.WriteLine("connection: " + externalConnection.Name);
                PrintTables(workbook, externalConnection);
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            // ExEnd:FindQueryTablesAndListObjectsOfExternalDataConnections           

        }

        public static void PrintTables(Workbook workbook, Aspose.Cells.ExternalConnections.ExternalConnection ec)
        {
            // Iterate all the worksheets
            for (int j = 0; j < workbook.Worksheets.Count; j++)
            {
                Worksheet worksheet = workbook.Worksheets[j];

                // Check all the query tables in a worksheet
                for (int k = 0; k < worksheet.QueryTables.Count; k++)
                {
                    Aspose.Cells.QueryTable qt = worksheet.QueryTables[k];

                    // Check if query table is related to this external connection
                    if (ec.Id == qt.ConnectionId
                        && qt.ConnectionId >= 0)
                    {
                        // Print the query table name and print its refersto range
                        Console.WriteLine("querytable " + qt.Name);
                        string n = qt.Name.Replace('+', '_').Replace('=', '_');
                        Name name = workbook.Worksheets.Names["'" + worksheet.Name + "'!" + n];
                        if (name != null)
                        {
                            Range range = name.GetRange();
                            if (range != null)
                            {
                                Console.WriteLine("refersto: " + range.RefersTo);
                            }
                        }
                    }
                }

                // Iterate all the list objects in this worksheet
                for (int k = 0; k < worksheet.ListObjects.Count; k++)
                {
                    ListObject table = worksheet.ListObjects[k];

                    // Check the data source type if it is query table
                    if (table.DataSourceType == Aspose.Cells.Tables.TableDataSourceType.QueryTable)
                    {
                        // Access the query table related to list object
                        QueryTable qt = table.QueryTable;

                        // Check if query table is related to this external connection
                        if (ec.Id == qt.ConnectionId
                        && qt.ConnectionId >= 0)
                        {
                            // Print the query table name and print its refersto range
                            Console.WriteLine("querytable " + qt.Name);
                            Console.WriteLine("Table " + table.DisplayName);
                            Console.WriteLine("refersto: " + worksheet.Name + "!" + CellsHelper.CellIndexToName(table.StartRow, table.StartColumn) + ":" + CellsHelper.CellIndexToName(table.EndRow, table.EndColumn));
                        }
                    }
                }
            }
        }

    }
}
