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
        Me.button3 = New System.Windows.Forms.Button()
        Me.button2 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.gridDesktop1 = New Aspose.Cells.GridDesktop.GridDesktop()
        Me.SuspendLayout()
        '
        'button3
        '
        Me.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.button3.Location = New System.Drawing.Point(346, 366)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(114, 23)
        Me.button3.TabIndex = 6
        Me.button3.Text = "Open from Stream"
        Me.button3.UseVisualStyleBackColor = True
        '
        'button2
        '
        Me.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.button2.Location = New System.Drawing.Point(238, 366)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(102, 23)
        Me.button2.TabIndex = 5
        Me.button2.Text = "Open CSV File"
        Me.button2.UseVisualStyleBackColor = True
        '
        'button1
        '
        Me.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.button1.Location = New System.Drawing.Point(138, 366)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(94, 23)
        Me.button1.TabIndex = 4
        Me.button1.Text = "Open Excel File"
        Me.button1.UseVisualStyleBackColor = True
        '
        'gridDesktop1
        '
        Me.gridDesktop1.ActiveSheetIndex = 0
        Me.gridDesktop1.ActiveSheetNameFont = Nothing
        Me.gridDesktop1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridDesktop1.CommentDisplayingFont = New System.Drawing.Font("Arial", 9.0!)
        Me.gridDesktop1.IsHorizontalScrollBarVisible = True
        Me.gridDesktop1.IsVerticalScrollBarVisible = True
        Me.gridDesktop1.Location = New System.Drawing.Point(12, 12)
        Me.gridDesktop1.Name = "gridDesktop1"
        Me.gridDesktop1.SheetNameFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.gridDesktop1.SheetTabWidth = 400
        Me.gridDesktop1.Size = New System.Drawing.Size(537, 336)
        Me.gridDesktop1.TabIndex = 7
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 401)
        Me.Controls.Add(Me.gridDesktop1)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents button3 As System.Windows.Forms.Button
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents button1 As System.Windows.Forms.Button
    Friend WithEvents gridDesktop1 As Aspose.Cells.GridDesktop.GridDesktop

End Class
