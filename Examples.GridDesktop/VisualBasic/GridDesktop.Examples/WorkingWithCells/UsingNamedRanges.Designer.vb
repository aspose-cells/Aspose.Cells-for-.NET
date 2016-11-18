Namespace WorkingWithCells
	Partial Class UsingNamedRanges
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
			Me._grid = New Aspose.Cells.GridDesktop.GridDesktop()
			Me.button1 = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' _grid
			' 
			Me._grid.ActiveSheetIndex = 0
			Me._grid.ActiveSheetNameFont = Nothing
			Me._grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me._grid.CommentDisplayingFont = New System.Drawing.Font("Arial", 9F)
			Me._grid.IsHorizontalScrollBarVisible = True
			Me._grid.IsVerticalScrollBarVisible = True
			Me._grid.Location = New System.Drawing.Point(12, 12)
			Me._grid.Name = "_grid"
			Me._grid.SheetNameFont = New System.Drawing.Font("Verdana", 8F)
			Me._grid.SheetTabWidth = 400
			Me._grid.Size = New System.Drawing.Size(610, 368)
			Me._grid.TabIndex = 1
			' 
			' button1
			' 
			Me.button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
			Me.button1.Location = New System.Drawing.Point(12, 386)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(75, 23)
			Me.button1.TabIndex = 2
			Me.button1.Text = "Run"
			Me.button1.UseVisualStyleBackColor = True
			AddHandler Me.button1.Click, New System.EventHandler(AddressOf Me.button1_Click)
			' 
			' UsingNamedRanges
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(634, 415)
			Me.Controls.Add(Me.button1)
			Me.Controls.Add(Me._grid)
			Me.Name = "UsingNamedRanges"
			Me.Text = "Using Named Ranges"
			Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private _grid As Aspose.Cells.GridDesktop.GridDesktop
		Private button1 As System.Windows.Forms.Button
	End Class
End Namespace
