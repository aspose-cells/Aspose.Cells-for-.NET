Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Data.AddOn.Hyperlinks
    Public Class AddingLinkToAnotherCell
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
            Dim workbook As New Workbook()

            ' Adding a new worksheet to the Workbook object
            workbook.Worksheets.Add()

            ' Obtaining the reference of the first (default) worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Adding an internal hyperlink to the "B9" cell of the other worksheet "Sheet2" in
            ' The same Excel file
            worksheet.Hyperlinks.Add("B3", 1, 1, "Sheet2!B9")

            ' Saving the Excel file
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1

        End Sub
    End Class
End Namespace