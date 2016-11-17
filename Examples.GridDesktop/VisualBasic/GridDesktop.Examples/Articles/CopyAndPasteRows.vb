Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace Articles
	Public Partial Class CopyAndPasteRows
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub CopyAndPasteRows_Load(sender As Object, e As EventArgs)
			' ExStart:1
			' Indicates whether to copy/paste based on clipboard, so that it can copy/paste with MS-EXCEL.
            ' It will only copy/paste cell value and will not copy any other setting of the cell like format, border style and so on.
            ' The default value is false.
			gridDesktop1.EnableClipboardCopyPaste = True
			' ExEnd:1
		End Sub
	End Class
End Namespace
