Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Imports Aspose.Cells.Drawing.ActiveXControls
Imports Aspose.Cells.Vba
Namespace Articles
    Public Class AddingCustomPropertiesVisible
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object
            Dim workbook As New Workbook(FileFormatType.Xlsx)

            ' Add simple property without any type
            workbook.ContentTypeProperties.Add("MK31", "Simple Data")

            ' Add date time property with type
            workbook.ContentTypeProperties.Add("MK32", "04-Mar-2015", "DateTime")

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("AddingCustomPropertiesVisible_out.xlsx"))
            ' ExEnd:1            
        End Sub
    End Class
End Namespace
