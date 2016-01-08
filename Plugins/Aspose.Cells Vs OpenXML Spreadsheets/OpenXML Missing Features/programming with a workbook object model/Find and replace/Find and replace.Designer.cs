namespace Find_and_replace
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
            this.BTN_SelectFile = new System.Windows.Forms.Button();
            this.LBL_SelectedFile = new System.Windows.Forms.Label();
            this.TXBX_Find = new System.Windows.Forms.TextBox();
            this.TXBX_Replace = new System.Windows.Forms.TextBox();
            this.BTN_Find = new System.Windows.Forms.Button();
            this.BTN_Replace = new System.Windows.Forms.Button();
            this.BTN_SaveFile = new System.Windows.Forms.Button();
            this.FOD_OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.FSD_SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.LBL_FindResults = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BTN_SelectFile
            // 
            this.BTN_SelectFile.Location = new System.Drawing.Point(12, 12);
            this.BTN_SelectFile.Name = "BTN_SelectFile";
            this.BTN_SelectFile.Size = new System.Drawing.Size(75, 23);
            this.BTN_SelectFile.TabIndex = 0;
            this.BTN_SelectFile.Text = "Select File";
            this.BTN_SelectFile.UseVisualStyleBackColor = true;
            this.BTN_SelectFile.Click += new System.EventHandler(this.BTN_SelectFile_Click);
            // 
            // LBL_SelectedFile
            // 
            this.LBL_SelectedFile.AutoSize = true;
            this.LBL_SelectedFile.Location = new System.Drawing.Point(12, 38);
            this.LBL_SelectedFile.Name = "LBL_SelectedFile";
            this.LBL_SelectedFile.Size = new System.Drawing.Size(68, 13);
            this.LBL_SelectedFile.TabIndex = 1;
            this.LBL_SelectedFile.Text = "Selected File";
            // 
            // TXBX_Find
            // 
            this.TXBX_Find.Location = new System.Drawing.Point(12, 54);
            this.TXBX_Find.Name = "TXBX_Find";
            this.TXBX_Find.Size = new System.Drawing.Size(180, 20);
            this.TXBX_Find.TabIndex = 2;
            // 
            // TXBX_Replace
            // 
            this.TXBX_Replace.Location = new System.Drawing.Point(12, 80);
            this.TXBX_Replace.Name = "TXBX_Replace";
            this.TXBX_Replace.Size = new System.Drawing.Size(180, 20);
            this.TXBX_Replace.TabIndex = 3;
            // 
            // BTN_Find
            // 
            this.BTN_Find.Location = new System.Drawing.Point(207, 54);
            this.BTN_Find.Name = "BTN_Find";
            this.BTN_Find.Size = new System.Drawing.Size(75, 23);
            this.BTN_Find.TabIndex = 4;
            this.BTN_Find.Text = "Find";
            this.BTN_Find.UseVisualStyleBackColor = true;
            this.BTN_Find.Click += new System.EventHandler(this.BTN_Find_Click);
            // 
            // BTN_Replace
            // 
            this.BTN_Replace.Location = new System.Drawing.Point(207, 83);
            this.BTN_Replace.Name = "BTN_Replace";
            this.BTN_Replace.Size = new System.Drawing.Size(75, 23);
            this.BTN_Replace.TabIndex = 5;
            this.BTN_Replace.Text = "Replace All";
            this.BTN_Replace.UseVisualStyleBackColor = true;
            this.BTN_Replace.Click += new System.EventHandler(this.BTN_Replace_Click);
            // 
            // BTN_SaveFile
            // 
            this.BTN_SaveFile.Location = new System.Drawing.Point(12, 106);
            this.BTN_SaveFile.Name = "BTN_SaveFile";
            this.BTN_SaveFile.Size = new System.Drawing.Size(75, 23);
            this.BTN_SaveFile.TabIndex = 6;
            this.BTN_SaveFile.Text = "Save File";
            this.BTN_SaveFile.UseVisualStyleBackColor = true;
            this.BTN_SaveFile.Click += new System.EventHandler(this.BTN_SaveFile_Click);
            // 
            // FOD_OpenFile
            // 
            this.FOD_OpenFile.FileName = "openFileDialog1";
            // 
            // LBL_FindResults
            // 
            this.LBL_FindResults.AutoSize = true;
            this.LBL_FindResults.Location = new System.Drawing.Point(12, 132);
            this.LBL_FindResults.Name = "LBL_FindResults";
            this.LBL_FindResults.Size = new System.Drawing.Size(65, 13);
            this.LBL_FindResults.TabIndex = 7;
            this.LBL_FindResults.Text = "Find Results";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 207);
            this.Controls.Add(this.LBL_FindResults);
            this.Controls.Add(this.BTN_SaveFile);
            this.Controls.Add(this.BTN_Replace);
            this.Controls.Add(this.BTN_Find);
            this.Controls.Add(this.TXBX_Replace);
            this.Controls.Add(this.TXBX_Find);
            this.Controls.Add(this.LBL_SelectedFile);
            this.Controls.Add(this.BTN_SelectFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_SelectFile;
        private System.Windows.Forms.Label LBL_SelectedFile;
        private System.Windows.Forms.TextBox TXBX_Find;
        private System.Windows.Forms.TextBox TXBX_Replace;
        private System.Windows.Forms.Button BTN_Find;
        private System.Windows.Forms.Button BTN_Replace;
        private System.Windows.Forms.Button BTN_SaveFile;
        private System.Windows.Forms.OpenFileDialog FOD_OpenFile;
        private System.Windows.Forms.SaveFileDialog FSD_SaveFile;
        private System.Windows.Forms.Label LBL_FindResults;
    }
}

