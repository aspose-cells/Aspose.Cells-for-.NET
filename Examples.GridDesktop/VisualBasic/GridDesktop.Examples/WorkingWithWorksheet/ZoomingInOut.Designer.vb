Namespace WorkingWithWorksheet
	Partial Class ZoomingInOut
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
			Me.trackBar1 = New System.Windows.Forms.TrackBar()
			Me.label1 = New System.Windows.Forms.Label()
			DirectCast(Me.trackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
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
			Me.gridDesktop1.Size = New System.Drawing.Size(633, 342)
			Me.gridDesktop1.TabIndex = 2
			' 
			' trackBar1
			' 
			Me.trackBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.trackBar1.AutoSize = False
			Me.trackBar1.Location = New System.Drawing.Point(437, 360)
			Me.trackBar1.Maximum = 200
			Me.trackBar1.Name = "trackBar1"
			Me.trackBar1.Size = New System.Drawing.Size(208, 31)
			Me.trackBar1.TabIndex = 3
			AddHandler Me.trackBar1.Scroll, New System.EventHandler(AddressOf Me.trackBar1_Scroll)
			' 
			' label1
			' 
			Me.label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(398, 367)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(33, 13)
			Me.label1.TabIndex = 4
			Me.label1.Text = "100%"
			' 
			' ZoomingInOut
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(657, 403)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.trackBar1)
			Me.Controls.Add(Me.gridDesktop1)
			Me.Name = "ZoomingInOut"
			Me.Text = "ZoomingInOut"
			AddHandler Me.Load, New System.EventHandler(AddressOf Me.ZoomingInOut_Load)
			DirectCast(Me.trackBar1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private gridDesktop1 As Aspose.Cells.GridDesktop.GridDesktop
		Private trackBar1 As System.Windows.Forms.TrackBar
		Private label1 As System.Windows.Forms.Label
	End Class
End Namespace
