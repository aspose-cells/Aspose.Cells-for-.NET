Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Drawing

Namespace DrawingObjects.Controls
    Public Class AddingListBoxControl
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Create a new Workbook.
            Dim workbook As New Workbook()

            ' Get the first worksheet.
            Dim sheet As Worksheet = workbook.Worksheets(0)

            ' Get the worksheet cells collection.
            Dim cells As Global.Aspose.Cells.Cells = sheet.Cells

            ' Input a value.
            cells("B3").PutValue("Choose Dept:")

            ' Set it bold.
            cells("B3").GetStyle().Font.IsBold = True

            ' Input some values that denote the input range
            ' For the list box.
            cells("A2").PutValue("Sales")
            cells("A3").PutValue("Finance")
            cells("A4").PutValue("MIS")
            cells("A5").PutValue("R&D")
            cells("A6").PutValue("Marketing")
            cells("A7").PutValue("HRA")

            ' Add a new list box.
            Dim listBox As Global.Aspose.Cells.Drawing.ListBox = sheet.Shapes.AddListBox(2, 0, 3, 0, 122, 100)

            ' Set the placement type.
            listBox.Placement = PlacementType.FreeFloating

            ' Set the linked cell.
            listBox.LinkedCell = "A1"

            ' Set the input range.
            listBox.InputRange = "A2:A7"

            ' Set the selection tyle.
            listBox.SelectionType = SelectionType.Single

            ' Set the list box with 3-D shading.
            listBox.Shadow = True

            ' Saves the file.
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1
        End Sub
    End Class
End Namespace