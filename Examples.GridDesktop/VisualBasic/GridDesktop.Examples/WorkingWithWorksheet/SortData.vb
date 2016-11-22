Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithWorksheet
	Public Partial Class SortData
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

        ' ExStart:CheckingCellRange
        ' Creating global variable of CellRange
		Private range As CellRange

		Private Sub gridDesktop1_SelectedCellRangeChanged(sender As Object, e As Aspose.Cells.GridDesktop.CellRangeEventArgs)
			' Checking if the range of cells is not empty
			If (e.CellRange.EndColumn - e.CellRange.StartColumn > 0) OrElse (e.CellRange.EndRow - e.CellRange.StartRow > 0) Then
				' Assigning the updated CellRange to global variable
				range = e.CellRange
			End If
        End Sub
        ' ExEnd:CheckingCellRange

        ' Module to sort data in Ascending order
        Private Sub Ascending_Sort()
            ' ExStart:AscendingSort
            ' Accessing a worksheet that is currently active
            Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

            ' Creating SortRange object
            Dim sr As New SortRange(sheet, range.StartRow, range.StartColumn, range.EndRow - range.StartRow + 1, range.EndColumn - range.StartColumn + 1, SortOrientation.SortTopToBottom, _
             True)

            ' Sorting data in the specified column in ascending order
            sr.Sort(range.StartColumn, Aspose.Cells.GridDesktop.SortOrder.Ascending)

            ' Redrawing cells of the Grid
            gridDesktop1.Invalidate()
            ' ExEnd:AscendingSort
        End Sub

        ' Module to sort data in Descending order
        Private Sub Descending_Sort()
            ' ExStart:DescendingSort
            ' Accessing a worksheet that is currently active
            Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

            ' Creating SortRange object
            Dim sr As New SortRange(sheet, range.StartRow, range.StartColumn, range.EndRow - range.StartRow + 1, range.EndColumn - range.StartColumn + 1, SortOrientation.SortTopToBottom, _
             True)

            ' Sorting data in the specified column in descending order
            sr.Sort(range.StartColumn, Aspose.Cells.GridDesktop.SortOrder.Descending)

            ' Redrawing cells of the Grid
            gridDesktop1.Invalidate()
            ' ExEnd:DescendingSort
        End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			If Not (range Is Nothing) Then
				Ascending_Sort()
			Else
				MessageBox.Show("No Range is selected. Please select range of cells.")
			End If
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			If Not (range Is Nothing) Then
				Descending_Sort()
			Else
				MessageBox.Show("No Range is selected. Please select range of cells.")
			End If
		End Sub
	End Class
End Namespace
