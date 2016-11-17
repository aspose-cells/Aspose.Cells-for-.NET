Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace WorkingWithWorksheet
	Public Partial Class ZoomingInOut
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub ZoomingInOut_Load(sender As Object, e As EventArgs)
			' ExStart:LoadEvent
			' The path to the documents directory.
			Dim dataDir As String = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

			' Importing the template Excel file to GridDesktop
			gridDesktop1.ImportExcelFile(dataDir & "EmployeeSales.xlsx")

			' Set the default value of the TrackBar control
			trackBar1.Value = 100

			' Set the custom label's text to the trackbar's value for display
			label1.Text = trackBar1.Value.ToString() & "%"
			' ExEnd:LoadEvent
		End Sub

		Private Sub trackBar1_Scroll(sender As Object, e As EventArgs)
			' ExStart:ZoomInOut
			' Set the Zoom factor of the active worksheet to the Trackbar's value
			gridDesktop1.Worksheets(gridDesktop1.GetActiveWorksheet().Index).Zoom = trackBar1.Value

			' Show the percentage value of the specified Zoom
			label1.Text = trackBar1.Value.ToString() & "%"
			' ExEnd:ZoomInOut
		End Sub
	End Class
End Namespace
