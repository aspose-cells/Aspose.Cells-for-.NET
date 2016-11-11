Imports System.IO

Public Class Form1
    Private Sub button1_Click(sender As System.Object, e As System.EventArgs) Handles button1.Click
        ' ExStart:OpeningExcelFile
        ' Specifying the path of Excel file using ImportExcelFile method of the control
        gridDesktop1.ImportExcelFile(Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType) + "Sample.xlsx")
        ' ExEnd:OpeningExcelFile
    End Sub

    Private Sub button2_Click(sender As System.Object, e As System.EventArgs) Handles button2.Click
        ' ExStart:OpeningCSVFile
        ' Specifying the path of Excel file using ImportExcelFile method of the control
        gridDesktop1.ImportExcelFile(Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType) + "SampleCSV1.csv")
        ' ExEnd:OpeningCSVFile
    End Sub

    Private Sub button3_Click(sender As System.Object, e As System.EventArgs) Handles button3.Click
        ' ExStart:OpeningFromStream
        ' Opening an Excel file as a stream
        Dim fs As FileStream = File.OpenRead(Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType) + "Sample.xlsx")

        ' Loading the Excel file contents into the control from a stream
        gridDesktop1.ImportExcelFile(fs)

        ' Closing stream
        fs.Close()
        ' ExEnd:OpeningFromStream
    End Sub
End Class
