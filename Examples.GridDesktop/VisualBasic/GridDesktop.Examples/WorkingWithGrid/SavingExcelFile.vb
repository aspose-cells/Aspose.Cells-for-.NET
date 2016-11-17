Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop
Imports System.IO

Namespace WorkingWithGrid
	Public Partial Class SavingExcelFile
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:SavingAFile
			' The path to the documents directory.
			Dim dataDir As String = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

			' Saving Grid contents to an Excel file
			gridDesktop1.ExportExcelFile(dataDir & "book1_out.xls")

			' Saving Grid contents to MS Excel 2007 Xlsx file format
			gridDesktop1.ExportExcelFile(Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType) & "book1_out.xlsx", FileFormatType.Excel2007Xlsx)
			' ExEnd:SavingAFile
			MessageBox.Show("Files have been created successfully.")
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:SavingUsingStream
			' The path to the documents directory.
			Dim dataDir As String = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

			' Opening an Excel file as a stream
			Dim fs As FileStream = File.Open(dataDir & "book1_out.xls", FileMode.Open, FileAccess.ReadWrite)

			' Saving Grid contents of the control to a stream
			gridDesktop1.ExportExcelFile(fs)

			' Closing stream
			fs.Close()
			' ExEnd:SavingUsingStream
			MessageBox.Show("File has been created successfully.")
		End Sub
	End Class
End Namespace
