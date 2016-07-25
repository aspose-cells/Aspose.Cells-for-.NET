Imports System
Imports Aspose.Cells
Imports Aspose.Cells.Tables
Imports Aspose.Cells.Drawing

Namespace Articles


    Public Class FindQueryTablesAndListObjectsOfExternalDataConnections
        Public Shared Sub Run()
            ' ExStart:FindQueryTablesAndListObjectsOfExternalDataConnections
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load workbook object
            Dim workbook As New Workbook(dataDir & "sample.xlsm")

            ' Check all the connections inside the workbook
            For i As Integer = 0 To workbook.DataConnections.Count - 1
                Dim externalConnection As Aspose.Cells.ExternalConnections.ExternalConnection = workbook.DataConnections(i)
                Console.WriteLine("connection: " + externalConnection.Name)
                PrintTables(workbook, externalConnection)
                Console.WriteLine()
            Next

            Console.WriteLine("Press any key to continue...")
            Console.ReadKey()
            ' ExEnd:FindQueryTablesAndListObjectsOfExternalDataConnections
        End Sub
        ' ExStart:PrintTables
        Public Shared Sub PrintTables(workbook As Workbook, ec As Aspose.Cells.ExternalConnections.ExternalConnection)
            ' Iterate all the worksheets
            For j As Integer = 0 To workbook.Worksheets.Count - 1
                Dim worksheet As Worksheet = workbook.Worksheets(j)

                ' Check all the query tables in a worksheet
                For k As Integer = 0 To worksheet.QueryTables.Count - 1
                    Dim qt As Aspose.Cells.QueryTable = worksheet.QueryTables(k)

                    ' Check if query table is related to this external connection
                    If ec.Id = qt.ConnectionId AndAlso qt.ConnectionId >= 0 Then
                        ' Print the query table name and print its refersto range
                        Console.WriteLine("querytable " + qt.Name)
                        Dim n As String = qt.Name.Replace("+"c, "_"c).Replace("="c, "_"c)
                        Dim name As Name = workbook.Worksheets.Names("'" + worksheet.Name & "'!" & n)
                        If name IsNot Nothing Then
                            Dim range As Range = name.GetRange()
                            If range IsNot Nothing Then
                                Console.WriteLine("refersto: " + range.RefersTo)
                            End If
                        End If
                    End If
                Next

                ' Iterate all the list objects in this worksheet
                For k As Integer = 0 To worksheet.ListObjects.Count - 1
                    Dim table As ListObject = worksheet.ListObjects(k)

                    ' Check the data source type if it is query table
                    If table.DataSourceType = Aspose.Cells.Tables.TableDataSourceType.QueryTable Then
                        ' Access the query table related to list object
                        Dim qt As QueryTable = table.QueryTable

                        ' Check if query table is related to this external connection
                        If ec.Id = qt.ConnectionId AndAlso qt.ConnectionId >= 0 Then
                            ' Print the query table name and print its refersto range
                            Console.WriteLine("querytable " + qt.Name)
                            Console.WriteLine("Table " + table.DisplayName)
                            Console.WriteLine("refersto: " + worksheet.Name & "!" & CellsHelper.CellIndexToName(table.StartRow, table.StartColumn) & ":" & CellsHelper.CellIndexToName(table.EndRow, table.EndColumn))
                        End If
                    End If
                Next
            Next
        End Sub
        ' ExEnd:PrintTables
    End Class

End Namespace
