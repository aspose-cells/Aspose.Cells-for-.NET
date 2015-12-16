namespace Export_frm_Worksheet
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BTN_Export = new System.Windows.Forms.Button();
            this.BTN_Select = new System.Windows.Forms.Button();
            this.LBL_SelectedFile = new System.Windows.Forms.Label();
            this.FOD_OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.BTN_NonStronglyExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // BTN_Export
            // 
            this.BTN_Export.Location = new System.Drawing.Point(12, 193);
            this.BTN_Export.Name = "BTN_Export";
            this.BTN_Export.Size = new System.Drawing.Size(207, 23);
            this.BTN_Export.TabIndex = 1;
            this.BTN_Export.Text = "Export Strongly Typed Data";
            this.BTN_Export.UseVisualStyleBackColor = true;
            this.BTN_Export.Click += new System.EventHandler(this.BTN_Export_Click);
            // 
            // BTN_Select
            // 
            this.BTN_Select.Location = new System.Drawing.Point(276, 3);
            this.BTN_Select.Name = "BTN_Select";
            this.BTN_Select.Size = new System.Drawing.Size(75, 23);
            this.BTN_Select.TabIndex = 2;
            this.BTN_Select.Text = "Select File";
            this.BTN_Select.UseVisualStyleBackColor = true;
            this.BTN_Select.Click += new System.EventHandler(this.BTN_Select_Click);
            // 
            // LBL_SelectedFile
            // 
            this.LBL_SelectedFile.AutoSize = true;
            this.LBL_SelectedFile.Location = new System.Drawing.Point(110, 236);
            this.LBL_SelectedFile.Name = "LBL_SelectedFile";
            this.LBL_SelectedFile.Size = new System.Drawing.Size(0, 13);
            this.LBL_SelectedFile.TabIndex = 3;
            // 
            // FOD_OpenFile
            // 
            this.FOD_OpenFile.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Columns Containing Strongly Typed Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(398, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Columns Containing Non Strongly Typed Data";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(391, 37);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(240, 150);
            this.dataGridView2.TabIndex = 6;
            // 
            // BTN_NonStronglyExport
            // 
            this.BTN_NonStronglyExport.Location = new System.Drawing.Point(391, 193);
            this.BTN_NonStronglyExport.Name = "BTN_NonStronglyExport";
            this.BTN_NonStronglyExport.Size = new System.Drawing.Size(172, 23);
            this.BTN_NonStronglyExport.TabIndex = 7;
            this.BTN_NonStronglyExport.Text = "Export Non Strongly Typed Data";
            this.BTN_NonStronglyExport.UseVisualStyleBackColor = true;
            this.BTN_NonStronglyExport.Click += new System.EventHandler(this.BTN_NonStronglyExport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 274);
            this.Controls.Add(this.BTN_NonStronglyExport);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBL_SelectedFile);
            this.Controls.Add(this.BTN_Select);
            this.Controls.Add(this.BTN_Export);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BTN_Export;
        private System.Windows.Forms.Button BTN_Select;
        private System.Windows.Forms.Label LBL_SelectedFile;
        private System.Windows.Forms.OpenFileDialog FOD_OpenFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button BTN_NonStronglyExport;
      
    }
}

