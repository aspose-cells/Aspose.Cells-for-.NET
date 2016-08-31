Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Namespace Articles
    Public Class ChangeTextBoxOrShareCharacterSpacing
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load your excel file inside a workbook obect
            Dim wb As New Workbook(dataDir & Convert.ToString("character-spacing.xlsx"))

            ' Access your text box which is also a shape object from shapes collection
            Dim shape As Shape = wb.Worksheets(0).Shapes(0)

            ' Access the first font setting object via GetCharacters() method
            Dim fs As FontSetting = DirectCast(shape.GetCharacters()(0), FontSetting)

            ' Save the workbook in xlsx format
            wb.Save(dataDir & Convert.ToString("ChangeTextBoxOrShareCharacterSpacing_out_.xlsx"), SaveFormat.Xlsx)
            ' ExEnd:1
        End Sub
    End Class
End Namespace
