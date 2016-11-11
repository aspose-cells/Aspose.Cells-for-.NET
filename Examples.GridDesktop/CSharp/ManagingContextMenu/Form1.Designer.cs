namespace ManagingContextMenu
{
    partial class Form1
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
            this.grdDataEntry = new Aspose.Cells.GridDesktop.GridDesktop();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.grdDataEntry.Location = new System.Drawing.Point(12, 12);
            this.grdDataEntry.Name = "grdDataEntry";
            this.grdDataEntry.SheetNameFont = new System.Drawing.Font("Verdana", 8F);
            this.grdDataEntry.SheetTabWidth = 400;
            this.grdDataEntry.Size = new System.Drawing.Size(610, 406);
            this.grdDataEntry.TabIndex = 0;
            this.grdDataEntry.SelectedSheetIndexChanged += new System.EventHandler(this.grdDataEntry_SelectedSheetIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(184, 430);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Hide Context Menu Item";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.Location = new System.Drawing.Point(324, 430);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Add Context Menu Item";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 465);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grdDataEntry);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Aspose.Cells.GridDesktop.GridDesktop grdDataEntry;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

