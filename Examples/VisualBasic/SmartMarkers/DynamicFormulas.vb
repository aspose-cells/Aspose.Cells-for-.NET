Imports System.IO

Imports Aspose.Cells

Namespace SmartMarkers
    Public Class DynamicFormulas
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If Not IsExists Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            If designerFile IsNot Nothing Then
                ' Instantiating a WorkbookDesigner object
                Dim designer As New WorkbookDesigner()

                ' Open a designer spreadsheet containing smart markers
                designer.Workbook = New Workbook(designerFile)

                ' Set the data source for the designer spreadsheet
                designer.SetDataSource(dataset)

                ' Process the smart markers
                designer.Process()
            End If
            ' ExEnd:1

        End Sub

        Public Shared Property designerFile() As Stream

        Public Shared Property dataset() As System.Data.SqlClient.SqlConnection
    End Class
End Namespace
