Imports System.Drawing

Namespace Articles
    Public Class UsingCellsFactory
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a Style object using CellsFactory class
            Dim cf As New CellsFactory()
            Dim st As Style = cf.CreateStyle()

            ' Set the Style fill color to Yellow
            st.Pattern = BackgroundType.Solid
            st.ForegroundColor = Color.Yellow

            ' Create a workbook and set its default style using the created Style object
            Dim wb As New Workbook()
            wb.DefaultStyle = st

            ' Save the workbook
            wb.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:1
        End Sub

    End Class
End Namespace