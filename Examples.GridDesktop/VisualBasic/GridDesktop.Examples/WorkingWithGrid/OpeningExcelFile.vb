Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.IO

Namespace WorkingWithGrid
	Public Partial Class OpeningExcelFile
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:OpeningExcelFile
			' The path to the documents directory.
			Dim dataDir As String = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

			' Specifying the path of Excel file using ImportExcelFile method of the control
			gridDesktop1.ImportExcelFile(dataDir & "Sample.xlsx")
			' ExEnd:OpeningExcelFile
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:OpeningCSVFile
			' The path to the documents directory.
			Dim dataDir As String = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

			' Specifying the path of Excel file using ImportExcelFile method of the control
			gridDesktop1.ImportExcelFile(dataDir & "SampleCSV1.csv")
			' ExEnd:OpeningCSVFile
		End Sub

		Private Sub button3_Click(sender As Object, e As EventArgs)
			' ExStart:OpeningFromStream
			' The path to the documents directory.
			Dim dataDir As String = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

			' Opening an Excel file as a stream
			Dim fs As FileStream = File.OpenRead(dataDir & "Sample.xlsx")

			' Loading the Excel file contents into the control from a stream
			gridDesktop1.ImportExcelFile(fs)

			' Closing stream
			fs.Close()
			' ExEnd:OpeningFromStream
		End Sub
	End Class
End Namespace
