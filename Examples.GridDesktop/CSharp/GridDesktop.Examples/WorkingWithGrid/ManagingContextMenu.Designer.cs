namespace GridDesktop.Examples.WorkingWithGrid
{
    partial class ManagingContextMenu
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.grdDataEntry = new Aspose.Cells.GridDesktop.GridDesktop();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.Location = new System.Drawing.Point(367, 433);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Add Context Menu Item";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(227, 433);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Hide Context Menu Item";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grdDataEntry
            // 
            this.grdDataEntry.ActiveSheetIndex = 0;
            this.grdDataEntry.ActiveSheetNameFont = null;
            this.grdDataEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDataEntry.CommentDisplayingFont = new System.Drawing.Font("Arial", 9F);
            this.grdDataEntry.IsHorizontalScrollBarVisible = true;
            this.grdDataEntry.IsVerticalScrollBarVisible = true;
            this.grdDataEntry.Location = new System.Drawing.Point(12, 15);
            this.grdDataEntry.Name = "grdDataEntry";
            this.grdDataEntry.SheetNameFont = new System.Drawing.Font("Verdana", 8F);
            this.grdDataEntry.SheetTabWidth = 400;
            this.grdDataEntry.Size = new System.Drawing.Size(697, 406);
            this.grdDataEntry.TabIndex = 3;
            // 
            // ManagingContextMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 471);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grdDataEntry);
            this.Name = "ManagingContextMenu";
            this.Text = "Managing Context Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private Aspose.Cells.GridDesktop.GridDesktop grdDataEntry;
    }
}