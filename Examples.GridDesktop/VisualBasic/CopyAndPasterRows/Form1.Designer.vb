<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GridDesktop1 = New Aspose.Cells.GridDesktop.GridDesktop()
        Me.SuspendLayout()
        '
        'GridDesktop1
        '
        Me.GridDesktop1.ActiveSheetIndex = 0
        Me.GridDesktop1.ActiveSheetNameFont = Nothing
        Me.GridDesktop1.CommentDisplayingFont = New System.Drawing.Font("Arial", 9.0!)
        Me.GridDesktop1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridDesktop1.IsHorizontalScrollBarVisible = True
        Me.GridDesktop1.IsVerticalScrollBarVisible = True
        Me.GridDesktop1.Location = New System.Drawing.Point(0, 0)
        Me.GridDesktop1.Name = "GridDesktop1"
        Me.GridDesktop1.SheetNameFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.GridDesktop1.SheetTabWidth = 400
        Me.GridDesktop1.Size = New System.Drawing.Size(617, 456)
        Me.GridDesktop1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 456)
        Me.Controls.Add(Me.GridDesktop1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridDesktop1 As Aspose.Cells.GridDesktop.GridDesktop

End Class
