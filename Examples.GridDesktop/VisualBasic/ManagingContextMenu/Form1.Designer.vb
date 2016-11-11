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
        Me.button2 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.grdDataEntry = New Aspose.Cells.GridDesktop.GridDesktop()
        Me.SuspendLayout()
        '
        'button2
        '
        Me.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.button2.Location = New System.Drawing.Point(343, 400)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(126, 23)
        Me.button2.TabIndex = 4
        Me.button2.Text = "Add Context Menu Item"
        Me.button2.UseVisualStyleBackColor = True
        '
        'button1
        '
        Me.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.button1.Location = New System.Drawing.Point(203, 400)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(134, 23)
        Me.button1.TabIndex = 3
        Me.button1.Text = "Hide Context Menu Item"
        Me.button1.UseVisualStyleBackColor = True
        '
        'grdDataEntry
        '
        Me.grdDataEntry.ActiveSheetIndex = 0
        Me.grdDataEntry.ActiveSheetNameFont = Nothing
        Me.grdDataEntry.CommentDisplayingFont = New System.Drawing.Font("Arial", 9.0!)
        Me.grdDataEntry.IsHorizontalScrollBarVisible = True
        Me.grdDataEntry.IsVerticalScrollBarVisible = True
        Me.grdDataEntry.Location = New System.Drawing.Point(12, 12)
        Me.grdDataEntry.Name = "grdDataEntry"
        Me.grdDataEntry.SheetNameFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.grdDataEntry.SheetTabWidth = 400
        Me.grdDataEntry.Size = New System.Drawing.Size(654, 382)
        Me.grdDataEntry.TabIndex = 5
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 435)
        Me.Controls.Add(Me.grdDataEntry)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents button1 As System.Windows.Forms.Button
    Friend WithEvents grdDataEntry As Aspose.Cells.GridDesktop.GridDesktop

End Class
