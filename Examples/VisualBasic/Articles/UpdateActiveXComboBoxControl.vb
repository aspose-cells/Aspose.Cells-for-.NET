
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Aspose.Cells.Drawing
Imports Aspose.Cells.Drawing.ActiveXControls

Namespace Articles
    Public Class UpdateActiveXComboBoxControl
        Public Shared Sub Run()
            ' ExStart:UpdateActiveXComboBoxControl
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a workbook
            Dim wb As New Workbook(dataDir & Convert.ToString("SourceFile.xlsx"))

            ' Access first shape from first worksheet
            Dim shape As Shape = wb.Worksheets(0).Shapes(0)

            ' Access ActiveX ComboBox Control and update its value
            If shape.ActiveXControl IsNot Nothing Then
                ' Access Shape ActiveX Control
                Dim c As ActiveXControl = shape.ActiveXControl

                ' Check if ActiveX Control is ComboBox Control
                If c.Type = ControlType.ComboBox Then
                    ' Type cast ActiveXControl into ComboBoxActiveXControl and change its value
                    Dim comboBoxActiveX As ComboBoxActiveXControl = DirectCast(c, ComboBoxActiveXControl)
                    comboBoxActiveX.Value = "This is combo box control with updated value."
                End If
            End If

            ' Save the workbook
            wb.Save(dataDir & Convert.ToString("OutputFile_out.xlsx"))
            ' ExEnd:UpdateActiveXComboBoxControl
        End Sub
    End Class
End Namespace
