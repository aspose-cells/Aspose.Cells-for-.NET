Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.ExternalConnections

Namespace Articles
    Public Class GetDataConnection
        Shared Sub Run()
            ' ExStart:1
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim inputPath As String = dataDir & "WebQuerySample.xlsx"

            Dim workbook As Workbook = New Workbook(inputPath)

            Dim connection As ExternalConnection = workbook.DataConnections(0)

            If TypeOf connection Is WebQueryConnection Then
                Dim webQuery As WebQueryConnection = DirectCast(connection, WebQueryConnection)
                Console.WriteLine("Web Query URL: " + webQuery.Url)
                ' ExEnd:1
            End If

        End Sub
    End Class
End Namespace
