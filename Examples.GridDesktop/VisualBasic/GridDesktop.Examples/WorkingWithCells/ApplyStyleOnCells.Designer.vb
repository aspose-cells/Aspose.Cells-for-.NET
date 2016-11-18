Namespace WorkingWithCells
	Partial Class ApplyStyleOnCells
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
			Me.gridDesktop1 = New Aspose.Cells.GridDesktop.GridDesktop()
			Me.button1 = New System.Windows.Forms.Button()
			Me.button2 = New System.Windows.Forms.Button()
			Me.button3 = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' gridDesktop1
			' 
			Me.gridDesktop1.ActiveSheetIndex = 0
			Me.gridDesktop1.ActiveSheetNameFont = Nothing
			Me.gridDesktop1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.gridDesktop1.CommentDisplayingFont = New System.Drawing.Font("Arial", 9F)
			Me.gridDesktop1.IsHorizontalScrollBarVisible = True
			Me.gridDesktop1.IsVerticalScrollBarVisible = True
			Me.gridDesktop1.Location = New System.Drawing.Point(12, 12)
			Me.gridDesktop1.Name = "gridDesktop1"
			Me.gridDesktop1.SheetNameFont = New System.Drawing.Font("Verdana", 8F)
			Me.gridDesktop1.SheetTabWidth = 400
			Me.gridDesktop1.Size = New System.Drawing.Size(666, 347)
			Me.gridDesktop1.TabIndex = 6
			' 
			' button1
			' 
			Me.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.button1.Location = New System.Drawing.Point(160, 365)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(88, 23)
			Me.button1.TabIndex = 7
			Me.button1.Text = "Apply Style"
			Me.button1.UseVisualStyleBackColor = True
			AddHandler Me.button1.Click, New System.EventHandler(AddressOf Me.button1_Click)
			' 
			' button2
			' 
			Me.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.button2.Location = New System.Drawing.Point(254, 365)
			Me.button2.Name = "button2"
			Me.button2.Size = New System.Drawing.Size(135, 23)
			Me.button2.TabIndex = 8
			Me.button2.Text = "Summing up All Together"
			Me.button2.UseVisualStyleBackColor = True
			AddHandler Me.button2.Click, New System.EventHandler(AddressOf Me.button2_Click)
			' 
			' button3
			' 
			Me.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.button3.Location = New System.Drawing.Point(395, 365)
			Me.button3.Name = "button3"
			Me.button3.Size = New System.Drawing.Size(135, 23)
			Me.button3.TabIndex = 9
			Me.button3.Text = "Setting Number Format"
			Me.button3.UseVisualStyleBackColor = True
			AddHandler Me.button3.Click, New System.EventHandler(AddressOf Me.button3_Click)
			' 
			' ApplyStyleOnCells
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(690, 400)
			Me.Controls.Add(Me.button3)
			Me.Controls.Add(Me.button2)
			Me.Controls.Add(Me.button1)
			Me.Controls.Add(Me.gridDesktop1)
			Me.Name = "ApplyStyleOnCells"
			Me.Text = "Apply Style On Cells"
			Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private gridDesktop1 As Aspose.Cells.GridDesktop.GridDesktop
		Private button1 As System.Windows.Forms.Button
		Private button2 As System.Windows.Forms.Button
		Private button3 As System.Windows.Forms.Button
	End Class
End Namespace
