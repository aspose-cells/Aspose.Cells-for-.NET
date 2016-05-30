Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Cells

Namespace Articles.ApplySuperscriptAndSubscript
    Public Class SettingSubscriptEffect
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

            ' Adding a new worksheet to the Excel object
            workbook.Worksheets.Add()

            ' Obtaining the reference of the newly added worksheet by passing its sheet index
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Accessing the "A1" cell from the worksheet
            Dim cell As Cell = worksheet.Cells("A1")

            ' Adding some value to the "A1" cell
            cell.PutValue("Hello")

            ' Setting the font Subscript
            Dim style As Style = cell.GetStyle()
            style.Font.IsSubscript = True
            cell.SetStyle(style)


            ' Saving the Excel file
            workbook.Save(dataDir & "Subscript.out.xls", SaveFormat.Auto)
            ' ExEnd:1
        End Sub
    End Class
End Namespace