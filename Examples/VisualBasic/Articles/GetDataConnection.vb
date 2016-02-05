Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.ExternalConnections

Namespace Aspose.Cells.Examples.Articles
    Public Class GetDataConnection
        Shared Sub Main()
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim inputPath As String = dataDir & "WebQuerySample.xlsx"

            Dim workbook As Workbook = New Workbook(inputPath)

            Dim connection As ExternalConnection = workbook.DataConnections(0)

            If TypeOf connection Is WebQueryConnection Then
                Dim webQuery As WebQueryConnection = DirectCast(connection, WebQueryConnection)
                Console.WriteLine("Web Query URL: " + webQuery.Url)
            End If

        End Sub
    End Class
End Namespace
