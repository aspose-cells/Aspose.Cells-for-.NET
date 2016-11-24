Namespace Articles
    Public Class AddXmlMapInsideWorkbook
        Public Shared Sub Run()
            ' ExStart:AddXmlMapInsideWorkbook
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object
            Dim wb As New Workbook()

            ' Add xml map found inside the sample.xml inside the workbook
            wb.Worksheets.XmlMaps.Add(dataDir & Convert.ToString("sample.xml"))

            ' Save the workbook in xlsx format
            wb.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:AddXmlMapInsideWorkbook
        End Sub
    End Class
End Namespace