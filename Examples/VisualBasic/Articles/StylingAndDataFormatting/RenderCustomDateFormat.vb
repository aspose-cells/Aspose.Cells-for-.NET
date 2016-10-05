
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Articles.StylingAndDataFormatting
    Public Class RenderCustomDateFormat
        Public Shared Sub Run()
            ' ExStart:RenderCustomDateFormatPatterngandgemmdd
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim workbook As New Workbook(dataDir & Convert.ToString("SourceFile.xlsx"))
            workbook.Save(dataDir & Convert.ToString("CustomDateFormat_out_.pdf"))
            ' ExEnd:RenderCustomDateFormatPatterngandgemmdd
        End Sub
    End Class
End Namespace
