Namespace Articles
    Public Class ExportXmlMapFromWorkbook
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Instantiating a Workbook object
            Dim workbook As New Workbook(dataDir & "sample.xlsx")

            ' Export all XML data from all XML Maps from the Workbook
            For i As Integer = 0 To workbook.Worksheets.XmlMaps.Count - 1
                ' Access the XML Map
                Dim map As XmlMap = workbook.Worksheets.XmlMaps(i)

                ' Exports its XML Data to file
                workbook.ExportXml(map.Name, dataDir & map.Name & ".xml")
            Next i
            ' ExEnd:1
        End Sub
    End Class
End Namespace