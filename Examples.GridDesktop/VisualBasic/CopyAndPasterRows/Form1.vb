Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' ExStart:CopyAndPasteRowsInGridDesktop
        ' Indicates whether to copy/paste based on clipboard, so that it can copy/paste with MS-EXCEL.
        ' It will only copy/paste cell value and will not copy any other setting of the cell like format, border style and so on.
        ' The default value is false.
        GridDesktop1.EnableClipboardCopyPaste = True
        ' ExEnd:CopyAndPasteRowsInGridDesktop
    End Sub
End Class
