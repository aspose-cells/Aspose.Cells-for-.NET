Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithCells
	Public Partial Class UndoRedoFeature
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:Undo
			' Enable the Undo operation
			gridDesktop1.EnableUndo = True

			' Create the UndoManager object
			Dim um As UndoManager = gridDesktop1.UndoManager

			' Perform Undo operation
			um.Undo()
			' ExEnd:Undo
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:Redo
			' Create the UndoManager object
			Dim um As UndoManager = gridDesktop1.UndoManager

			' Perform Redo operation
			um.Redo()
			' ExEnd:Redo
		End Sub
	End Class
End Namespace
