Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingWorkbooksWorksheets
    Public Class ImportXmlData
        Public Shared Sub Run()
            ' ExStart:ImportXmlDataIntoWorkbook
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a workbook
            Dim workbook As New Workbook()

            ' URL that contains your XML data for mapping
            Dim XML As String = "http://www.aspose.com/docs/download/attachments/434475650/sampleXML.txt"

            ' Import your XML Map data starting from cell A1
            workbook.ImportXml(XML, "Sheet1", 0, 0)

            ' Save workbook
            workbook.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:ImportXmlDataIntoWorkbook
        End Sub
    End Class
End Namespace