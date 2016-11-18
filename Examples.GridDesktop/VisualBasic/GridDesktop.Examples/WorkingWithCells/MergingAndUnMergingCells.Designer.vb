Namespace WorkingWithCells
	Partial Class MergingAndUnMergingCells
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
			Me.gridDesktop1 = New Aspose.Cells.GridDesktop.GridDesktop()
			Me.SuspendLayout()
			' 
			' button2
			' 
			Me.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.button2.Location = New System.Drawing.Point(323, 390)
			Me.button2.Name = "button2"
			Me.button2.Size = New System.Drawing.Size(108, 23)
			Me.button2.TabIndex = 15
			Me.button2.Text = "Unmerge Cells"
			Me.button2.UseVisualStyleBackColor = True
			AddHandler Me.button2.Click, New System.EventHandler(AddressOf Me.button2_Click)
			' 
			' button1
			' 
			Me.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.button1.Location = New System.Drawing.Point(215, 390)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(102, 23)
			Me.button1.TabIndex = 14
			Me.button1.Text = "Merge Cells"
			Me.button1.UseVisualStyleBackColor = True
			AddHandler Me.button1.Click, New System.EventHandler(AddressOf Me.button1_Click)
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
			Me.gridDesktop1.Size = New System.Drawing.Size(623, 372)
			Me.gridDesktop1.TabIndex = 13
			' 
			' MergingAndUnMergingCells
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(647, 425)
			Me.Controls.Add(Me.button2)
			Me.Controls.Add(Me.button1)
			Me.Controls.Add(Me.gridDesktop1)
			Me.Name = "MergingAndUnMergingCells"
			Me.Text = "MergingAndUnMergingCells"
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private button2 As System.Windows.Forms.Button
		Private button1 As System.Windows.Forms.Button
		Private gridDesktop1 As Aspose.Cells.GridDesktop.GridDesktop
	End Class
End Namespace
