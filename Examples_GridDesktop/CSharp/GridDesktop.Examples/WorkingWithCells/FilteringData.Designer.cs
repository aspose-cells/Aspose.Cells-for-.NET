namespace GridDesktop.Examples.WorkingWithCells
{
    partial class FilteringData
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
            this.gridDesktop1 = new Aspose.Cells.GridDesktop.GridDesktop();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnNotEqualFilter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gridDesktop1
            // 
            this.gridDesktop1.ActiveSheetIndex = 0;
            this.gridDesktop1.ActiveSheetNameFont = null;
            this.gridDesktop1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDesktop1.CommentDisplayingFont = new System.Drawing.Font("Arial", 9F);
            this.gridDesktop1.DefaultCellFont = new System.Drawing.Font("Arial", 10F);
            this.gridDesktop1.DefaultCellFontColor = System.Drawing.Color.Black;
            this.gridDesktop1.IsHorizontalScrollBarVisible = true;
            this.gridDesktop1.IsVerticalScrollBarVisible = true;
            this.gridDesktop1.Location = new System.Drawing.Point(13, 13);
            this.gridDesktop1.Name = "gridDesktop1";
            this.gridDesktop1.PageRows = 0;
            this.gridDesktop1.SheetNameFont = new System.Drawing.Font("Verdana", 8F);
            this.gridDesktop1.SheetTabWidth = 400;
            this.gridDesktop1.Size = new System.Drawing.Size(615, 368);
            this.gridDesktop1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(160, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Auto Filter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.Location = new System.Drawing.Point(241, 387);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Custom Filter";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnNotEqualFilter
            // 
            this.btnNotEqualFilter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNotEqualFilter.Location = new System.Drawing.Point(322, 387);
            this.btnNotEqualFilter.Name = "btnNotEqualFilter";
            this.btnNotEqualFilter.Size = new System.Drawing.Size(140, 23);
            this.btnNotEqualFilter.TabIndex = 3;
            this.btnNotEqualFilter.Text = "Not Equal Custom Filter";
            this.btnNotEqualFilter.UseVisualStyleBackColor = true;
            this.btnNotEqualFilter.Click += new System.EventHandler(this.btnNotEqualFilter_Click);
            // 
            // FilteringData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 422);
            this.Controls.Add(this.btnNotEqualFilter);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gridDesktop1);
            this.Name = "FilteringData";
            this.Text = "Filtering Data";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FilteringData_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Aspose.Cells.GridDesktop.GridDesktop gridDesktop1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnNotEqualFilter;
    }
}