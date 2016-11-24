
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Articles.RenderingAndPrinting
    Public Class PrintCommentWhileSavingToPdf
        Public Shared Sub Run()
            ' ExStart:PrintCommentWhileSavingToPdf
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a workbook from source Excel file
            Dim workbook As New Workbook(dataDir & Convert.ToString("SampleWorkbookWithComments.xlsx"))

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' For print no comments use "PrintCommentsType.PrintNoComments"
            ' and for print the comments as displayed on sheet use "PrintCommentsType.PrintInPlace"
            ' For Print the comments at the end of sheet we use "PrintCommentsType.PrintSheetEnd"
            worksheet.PageSetup.PrintComments = PrintCommentsType.PrintSheetEnd

            ' Save workbook in pdf format
            workbook.Save(dataDir & Convert.ToString("PrintCommentWhileSavingToPdf_out.pdf"))
            ' ExEnd:PrintCommentWhileSavingToPdf
        End Sub
    End Class
End Namespace
