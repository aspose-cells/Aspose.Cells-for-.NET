Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Data.Handling.Importing
    Public Class ImportingFromArray
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

            ' Obtaining the reference of the worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Creating an array containing names as string values
            Dim names() As String = {"laurence chen", "roman korchagin", "kyle huang"}

            ' Importing the array of names to 1st row and first column vertically
            worksheet.Cells.ImportArray(names, 0, 0, True)

            ' Saving the Excel file
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1
        End Sub
    End Class
End Namespace