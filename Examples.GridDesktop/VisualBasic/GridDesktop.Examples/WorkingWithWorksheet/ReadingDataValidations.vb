Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace WorkingWithWorksheet
	Public Partial Class ReadingDataValidations
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub ReadingDataValidations_Load(sender As Object, e As EventArgs)
			' ExStart:1
			' The path to the documents directory.
			Dim dataDir As String = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

			' Import sample excel file in GridDesktop
			gridDesktop1.ImportExcelFile(dataDir & "ValidationTesting.xlsx")
			' ExEnd:1
		End Sub
	End Class
End Namespace
