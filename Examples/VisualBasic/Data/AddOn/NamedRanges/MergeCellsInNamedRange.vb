Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Data.AddOn.NamedRanges
    Public Class MergeCellsInNamedRange
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Instantiate a new Workbook.
            Dim wb1 As New Workbook()

            'Get the first worksheet in the workbook.
            Dim worksheet1 As Worksheet = wb1.Worksheets(0)

            'Create a range.
            Dim mrange As Range = worksheet1.Cells.CreateRange("A18", "J18")

            'Name the range.
            mrange.Name = "Details"

            'Merge the cells of the range.
            mrange.Merge()

            'Get the range.
            Dim range1 As Range = wb1.Worksheets.GetRangeByName("Details")

            'Add a style object to the collection.
            Dim i As Integer = wb1.Styles.Add()

            'Define a style object.
            Dim style As Style = wb1.Styles(i)

            'Set the alignment.
            style.HorizontalAlignment = TextAlignmentType.Center

            'Create a StyleFlag object.
            Dim flag As New StyleFlag()
            'Make the relative style attribute ON.
            flag.HorizontalAlignment = True

            'Apply the style to the range.
            range1.ApplyStyle(style, flag)

            'Input data into range.
            range1(0, 0).PutValue("Aspose")

            'Save the excel file.
            wb1.Save(dataDir & "mergingrange.out.xls")
        End Sub
    End Class
End Namespace