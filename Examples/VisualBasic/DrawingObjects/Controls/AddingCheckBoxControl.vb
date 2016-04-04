Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.DrawingObjects.Controls
    Public Class AddingCheckBoxControl
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Instantiate a new Workbook.
            Dim excelbook As New Workbook()

            'Add a checkbox to the first worksheet in the workbook.
            Dim index As Integer = excelbook.Worksheets(0).CheckBoxes.Add(5, 5, 100, 120)

            'Get the checkbox object.
            Dim checkbox As Global.Aspose.Cells.Drawing.CheckBox = excelbook.Worksheets(0).CheckBoxes(index)

            'Set its text string.
            checkbox.Text = "Click it!"

            'Put a value into B1 cell.
            excelbook.Worksheets(0).Cells("B1").PutValue("LnkCell")

            'Set B1 cell as a linked cell for the checkbox.
            checkbox.LinkedCell = "B1"

            'Check the checkbox by default.
            checkbox.Value = True

            'Save the excel file.
            excelbook.Save(dataDir & "output.xls")
            'ExEnd:1
        End Sub
    End Class
End Namespace