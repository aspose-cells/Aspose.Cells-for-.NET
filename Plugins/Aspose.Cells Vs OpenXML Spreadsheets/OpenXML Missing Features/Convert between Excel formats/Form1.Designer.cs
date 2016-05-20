namespace Aspose.Plugins.AsposeVSOpenXML
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BTN_FileBrowse = new System.Windows.Forms.Button();
            this.CB_Formats = new System.Windows.Forms.ComboBox();
            this.LBL_FileName = new System.Windows.Forms.Label();
            this.TXBX_OutputFileName = new System.Windows.Forms.TextBox();
            this.BTN_Convert = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // BTN_FileBrowse
            // 
            this.BTN_FileBrowse.Location = new System.Drawing.Point(12, 39);
            this.BTN_FileBrowse.Name = "BTN_FileBrowse";
            this.BTN_FileBrowse.Size = new System.Drawing.Size(136, 23);
            this.BTN_FileBrowse.TabIndex = 0;
            this.BTN_FileBrowse.Text = "Select File To Convert";
            this.BTN_FileBrowse.UseVisualStyleBackColor = true;
            this.BTN_FileBrowse.Click += new System.EventHandler(this.BTN_FileBrowse_Click);
            // 
            // CB_Formats
            // 
            this.CB_Formats.FormattingEnabled = true;
            this.CB_Formats.Items.AddRange(new object[] {
            "CSV",
            "HTML",
            "PDF"});
            this.CB_Formats.Location = new System.Drawing.Point(12, 12);
            this.CB_Formats.Name = "CB_Formats";
            this.CB_Formats.Size = new System.Drawing.Size(199, 21);
            this.CB_Formats.TabIndex = 1;
            // 
            // LBL_FileName
            // 
            this.LBL_FileName.AutoSize = true;
            this.LBL_FileName.Location = new System.Drawing.Point(12, 65);
            this.LBL_FileName.Name = "LBL_FileName";
            this.LBL_FileName.Size = new System.Drawing.Size(0, 13);
            this.LBL_FileName.TabIndex = 2;
            // 
            // TXBX_OutputFileName
            // 
            this.TXBX_OutputFileName.Location = new System.Drawing.Point(12, 81);
            this.TXBX_OutputFileName.Name = "TXBX_OutputFileName";
            this.TXBX_OutputFileName.Size = new System.Drawing.Size(199, 20);
            this.TXBX_OutputFileName.TabIndex = 3;
            // 
            // BTN_Convert
            // 
            this.BTN_Convert.Location = new System.Drawing.Point(12, 107);
            this.BTN_Convert.Name = "BTN_Convert";
            this.BTN_Convert.Size = new System.Drawing.Size(136, 23);
            this.BTN_Convert.TabIndex = 4;
            this.BTN_Convert.Text = "Convert File";
            this.BTN_Convert.UseVisualStyleBackColor = true;
            this.BTN_Convert.Click += new System.EventHandler(this.BTN_Convert_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 302);
            this.Controls.Add(this.BTN_Convert);
            this.Controls.Add(this.TXBX_OutputFileName);
            this.Controls.Add(this.LBL_FileName);
            this.Controls.Add(this.CB_Formats);
            this.Controls.Add(this.BTN_FileBrowse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BTN_FileBrowse;
        private System.Windows.Forms.ComboBox CB_Formats;
        private System.Windows.Forms.Label LBL_FileName;
        private System.Windows.Forms.TextBox TXBX_OutputFileName;
        private System.Windows.Forms.Button BTN_Convert;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

