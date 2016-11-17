Namespace WorkingWithGrid
	Partial Class ManagingContextMenu
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.button2 = New System.Windows.Forms.Button()
			Me.button1 = New System.Windows.Forms.Button()
			Me.grdDataEntry = New Aspose.Cells.GridDesktop.GridDesktop()
			Me.SuspendLayout()
			' 
			' button2
			' 
			Me.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.button2.Location = New System.Drawing.Point(367, 433)
			Me.button2.Name = "button2"
			Me.button2.Size = New System.Drawing.Size(126, 23)
			Me.button2.TabIndex = 5
			Me.button2.Text = "Add Context Menu Item"
			Me.button2.UseVisualStyleBackColor = True
			AddHandler Me.button2.Click, New System.EventHandler(AddressOf Me.button2_Click)
			' 
			' button1
			' 
			Me.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.button1.Location = New System.Drawing.Point(227, 433)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(134, 23)
			Me.button1.TabIndex = 4
			Me.button1.Text = "Hide Context Menu Item"
			Me.button1.UseVisualStyleBackColor = True
			AddHandler Me.button1.Click, New System.EventHandler(AddressOf Me.button1_Click)
			' 
			' grdDataEntry
			' 
			Me.grdDataEntry.ActiveSheetIndex = 0
			Me.grdDataEntry.ActiveSheetNameFont = Nothing
			Me.grdDataEntry.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.grdDataEntry.CommentDisplayingFont = New System.Drawing.Font("Arial", 9F)
			Me.grdDataEntry.IsHorizontalScrollBarVisible = True
			Me.grdDataEntry.IsVerticalScrollBarVisible = True
			Me.grdDataEntry.Location = New System.Drawing.Point(12, 15)
			Me.grdDataEntry.Name = "grdDataEntry"
			Me.grdDataEntry.SheetNameFont = New System.Drawing.Font("Verdana", 8F)
			Me.grdDataEntry.SheetTabWidth = 400
			Me.grdDataEntry.Size = New System.Drawing.Size(697, 406)
			Me.grdDataEntry.TabIndex = 3
			' 
			' ManagingContextMenu
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(721, 471)
			Me.Controls.Add(Me.button2)
			Me.Controls.Add(Me.button1)
			Me.Controls.Add(Me.grdDataEntry)
			Me.Name = "ManagingContextMenu"
			Me.Text = "Managing Context Menu"
			Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private button2 As System.Windows.Forms.Button
		Private button1 As System.Windows.Forms.Button
		Private grdDataEntry As Aspose.Cells.GridDesktop.GridDesktop
	End Class
End Namespace
