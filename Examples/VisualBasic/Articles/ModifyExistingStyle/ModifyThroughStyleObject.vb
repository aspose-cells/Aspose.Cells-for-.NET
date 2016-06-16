Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles.ModifyExistingStyle
    Public Class ModifyThroughStyleObject
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Create a workbook.
            Dim workbook As New Workbook()

            ' Create a new style object.
            Dim style As Style = workbook.CreateStyle()

            ' Set the number format.
            style.Number = 14

            ' Set the font color to red color.
            style.Font.Color = System.Drawing.Color.Red

            ' Name the style.
            style.Name = "Date1"

            ' Get the first worksheet cells.
            Dim cells As Global.Aspose.Cells.Cells = workbook.Worksheets(0).Cells

            ' Specify the style (described above) to A1 cell.
            cells("A1").SetStyle(style)

            ' Create a range (B1:D1).
            Dim range As Range = cells.CreateRange("B1", "D1")

            ' Initialize styleflag object.
            Dim flag As New StyleFlag()

            ' Set all formatting attributes on.
            flag.All = True

            ' Apply the style (described above)to the range.
            range.ApplyStyle(style, flag)

            ' Modify the style (described above) and change the font color from red to black.
            style.Font.Color = System.Drawing.Color.Black

            ' Done! Since the named style (described above) has been set to a cell and range, 
            ' The change would be Reflected(new modification is implemented) to cell(A1) and //range (B1:D1).
            style.Update()

            ' Save the excel file. 
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1


        End Sub
    End Class
End Namespace