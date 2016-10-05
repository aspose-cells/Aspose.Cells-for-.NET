
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

            ' Comment the working line and Uncomment the line as per your requirement

            ' For "Print no comments" Uncomment below line
            'worksheet.PageSetup.PrintComments = PrintCommentsType.PrintNoComments;

            ' For "Print the comments as displayed on sheet" Uncomment below line
            'worksheet.PageSetup.PrintComments = PrintCommentsType.PrintInPlace;

            ' For "Print the comments at the end of sheet"
            worksheet.PageSetup.PrintComments = PrintCommentsType.PrintSheetEnd

            ' Save workbook in pdf format
            workbook.Save(dataDir & Convert.ToString("PrintCommentWhileSavingToPdf_out_.pdf"))
            ' ExEnd:PrintCommentWhileSavingToPdf
        End Sub
    End Class
End Namespace
