Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports GridDesktop.Examples.WorkingWithGrid
Imports GridDesktop.Examples.Articles
Imports GridDesktop.Examples.WorkingWithWorksheet

Public Partial Class RunExamples
	Inherits Form
	Public Sub New()
		InitializeComponent()
	End Sub

	Private Sub closeAllToolStripMenuItem_Click(sender As Object, e As EventArgs)
		For Each frm As Form In Me.MdiChildren
			If frm IsNot Me Then
				frm.Close()
			End If
		Next
	End Sub

	Private Sub exitToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Application.[Exit]()
	End Sub

	Private Sub copyAndPasteRowsToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmCopyPasteRows As New CopyAndPasteRows()
		frmCopyPasteRows.MdiParent = Me
		frmCopyPasteRows.Show()
	End Sub

	Private Sub dataBindingFeaturesInWorksheetsToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmDataBindingFeatures As New DataBindingFeature()
		frmDataBindingFeatures.MdiParent = Me
		frmDataBindingFeatures.Show()
	End Sub

	Private Sub managingContextMenuToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmManagingContextMenu As New ManagingContextMenu()
		frmManagingContextMenu.MdiParent = Me
		frmManagingContextMenu.Show()
	End Sub

	Private Sub openingExcelFileToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmOpeningExcelFile As New OpeningExcelFile()
		frmOpeningExcelFile.MdiParent = Me
		frmOpeningExcelFile.Show()
	End Sub

	Private Sub savingExcelFileToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmSavingExcelFile As New SavingExcelFile()
		frmSavingExcelFile.MdiParent = Me
		frmSavingExcelFile.Show()
	End Sub

	Private Sub gridDesktopEventsToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmGridDesktopEvents As New GridDesktopEvents()
		frmGridDesktopEvents.MdiParent = Me
		frmGridDesktopEvents.Show()
	End Sub

	Private Sub accessingWorksheetsToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmAccessingWorksheets As New AccessingWorksheets()
		frmAccessingWorksheets.MdiParent = Me
		frmAccessingWorksheets.Show()
	End Sub

	Private Sub addORInsertWorksheetsToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmAddInsertWorksheet As New AddInsertWorksheet()
		frmAddInsertWorksheet.MdiParent = Me
		frmAddInsertWorksheet.Show()
	End Sub

	Private Sub removeAWorksheetToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmRemoveWorksheet As New RemoveWorksheet()
		frmRemoveWorksheet.MdiParent = Me
		frmRemoveWorksheet.Show()
	End Sub

	Private Sub renameAWorksheetToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmRenameWorksheet As New RenameWorksheet()
		frmRenameWorksheet.MdiParent = Me
		frmRenameWorksheet.Show()
	End Sub

	Private Sub importDataFromDataTableToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmImportData As New ImportDataFromDataTable()
		frmImportData.MdiParent = Me
		frmImportData.Show()
	End Sub

	Private Sub exportDataToDataTableToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmExportData As New ExportDataToDataTable()
		frmExportData.MdiParent = Me
		frmExportData.Show()
	End Sub

	Private Sub workingWithValidationsToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmValidations As New ValidationInWorksheets()
		frmValidations.MdiParent = Me
		frmValidations.Show()
	End Sub

	Private Sub sortDataToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmSortData As New SortData()
		frmSortData.MdiParent = Me
		frmSortData.Show()
	End Sub

	Private Sub managingHyperlinksToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmHyperlinks As New ManagingHyperlinks()
		frmHyperlinks.MdiParent = Me
		frmHyperlinks.Show()
	End Sub

	Private Sub managingPicturesToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmManagingPictures As New ManagingPictures()
		frmManagingPictures.MdiParent = Me
		frmManagingPictures.Show()
	End Sub

	Private Sub managingCommentsToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmManagingComments As New ManagingComments()
		frmManagingComments.MdiParent = Me
		frmManagingComments.Show()
	End Sub

	Private Sub addingCellControlsToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmAddingCellControls As New AddingCellControls()
		frmAddingCellControls.MdiParent = Me
		frmAddingCellControls.Show()
	End Sub

	Private Sub managingCellControlsToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmManagingCellControls As New ManagingCellControls()
		frmManagingCellControls.MdiParent = Me
		frmManagingCellControls.Show()
	End Sub

	Private Sub showHideScrolBarsToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmDisplayHideScrols As New DisplayHideScrolBars()
		frmDisplayHideScrols.MdiParent = Me
		frmDisplayHideScrols.Show()
	End Sub

	Private Sub movingWorksheetsToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmMovingWorksheets As New MovingWorksheets()
		frmMovingWorksheets.MdiParent = Me
		frmMovingWorksheets.Show()
	End Sub

	Private Sub readingDataValidationsToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmDataValidations As New ReadingDataValidations()
		frmDataValidations.MdiParent = Me
		frmDataValidations.Show()
	End Sub

	Private Sub zoomingInOrOutToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Dim frmZoomingInOut As New ZoomingInOut()
		frmZoomingInOut.MdiParent = Me
		frmZoomingInOut.Show()
	End Sub
End Class
