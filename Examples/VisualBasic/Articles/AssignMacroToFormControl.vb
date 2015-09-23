Imports Aspose.Cells
Imports Aspose.Cells.Vba
Imports Aspose.Cells.Drawing

Namespace Aspose.Cells.Examples.Articles
    Public Class AssignMacroToFormControl
        Public Shared Sub Main(ByVal args() As String)

            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            If (Not System.IO.Directory.Exists(dataDir)) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            Dim workbook As Workbook = New Workbook()
            Dim sheet As Worksheet = workbook.Worksheets(0)

            Dim moduleIdx As Integer = workbook.VbaProject.Modules.Add(sheet)
            Dim module1 As VbaModule = workbook.VbaProject.Modules(moduleIdx)
            module1.Codes = "Sub ShowMessage()" & "\r\n" _
                & "    MsgBox ""Welcome to Aspose!""" & "\r\n" _
                & "End Sub"

            Dim button As Button = sheet.Shapes.AddButton(2, 0, 2, 0, 28, 80)
            button.Placement = PlacementType.FreeFloating
            button.Font.Name = "Tahoma"
            button.Font.IsBold = True
            button.Font.Color = System.Drawing.Color.Blue
            button.Text = "Aspose"

            workbook.Save(dataDir + "Output1.xlsm")

            Console.WriteLine("File saved")

        End Sub
    End Class
End Namespace
