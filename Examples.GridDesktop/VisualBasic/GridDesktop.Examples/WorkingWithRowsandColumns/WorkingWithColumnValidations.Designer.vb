Namespace WorkingWithRowsandColumns
	Partial Class WorkingWithColumnValidations
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
			Me.button4 = New System.Windows.Forms.Button()
			Me.button3 = New System.Windows.Forms.Button()
			Me.button1 = New System.Windows.Forms.Button()
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
			Me.gridDesktop1.Size = New System.Drawing.Size(675, 369)
			Me.gridDesktop1.TabIndex = 0
			' 
			' button4
			' 
			Me.button4.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.button4.Location = New System.Drawing.Point(426, 387)
			Me.button4.Name = "button4"
			Me.button4.Size = New System.Drawing.Size(141, 23)
			Me.button4.TabIndex = 15
			Me.button4.Text = "Remove Validation"
			Me.button4.UseVisualStyleBackColor = True
			AddHandler Me.button4.Click, New System.EventHandler(AddressOf Me.button4_Click)
			' 
			' button3
			' 
			Me.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.button3.Location = New System.Drawing.Point(279, 387)
			Me.button3.Name = "button3"
			Me.button3.Size = New System.Drawing.Size(141, 23)
			Me.button3.TabIndex = 14
			Me.button3.Text = "Access Validation"
			Me.button3.UseVisualStyleBackColor = True
			AddHandler Me.button3.Click, New System.EventHandler(AddressOf Me.button3_Click)
			' 
			' button1
			' 
			Me.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.button1.Location = New System.Drawing.Point(132, 387)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(141, 23)
			Me.button1.TabIndex = 13
			Me.button1.Text = "Add Validation"
			Me.button1.UseVisualStyleBackColor = True
			AddHandler Me.button1.Click, New System.EventHandler(AddressOf Me.button1_Click)
			' 
			' WorkingWithColumnValidations
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(699, 422)
			Me.Controls.Add(Me.button4)
			Me.Controls.Add(Me.button3)
			Me.Controls.Add(Me.button1)
			Me.Controls.Add(Me.gridDesktop1)
			Me.Name = "WorkingWithColumnValidations"
			Me.Text = "Working With Column Validations"
			Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private gridDesktop1 As Aspose.Cells.GridDesktop.GridDesktop
		Private button4 As System.Windows.Forms.Button
		Private button3 As System.Windows.Forms.Button
		Private button1 As System.Windows.Forms.Button
	End Class
End Namespace
