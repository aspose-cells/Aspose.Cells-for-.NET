namespace GridDesktop.Examples.WorkingWithCells
{
    partial class UsingNamedRanges
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._grid = new Aspose.Cells.GridDesktop.GridDesktop();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.ActiveSheetIndex = 0;
            this._grid.ActiveSheetNameFont = null;
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grid.CommentDisplayingFont = new System.Drawing.Font("Arial", 9F);
            this._grid.IsHorizontalScrollBarVisible = true;
            this._grid.IsVerticalScrollBarVisible = true;
            this._grid.Location = new System.Drawing.Point(12, 12);
            this._grid.Name = "_grid";
            this._grid.SheetNameFont = new System.Drawing.Font("Verdana", 8F);
            this._grid.SheetTabWidth = 400;
            this._grid.Size = new System.Drawing.Size(610, 368);
            this._grid.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(12, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UsingNamedRanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 415);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._grid);
            this.Name = "UsingNamedRanges";
            this.Text = "Using Named Ranges";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private Aspose.Cells.GridDesktop.GridDesktop _grid;
        private System.Windows.Forms.Button button1;
    }
}