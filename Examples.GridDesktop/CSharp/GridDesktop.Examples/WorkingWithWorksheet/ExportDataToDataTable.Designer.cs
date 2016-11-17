namespace GridDesktop.Examples.WorkingWithWorksheet
{
    partial class ExportDataToDataTable
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
            this.gridDesktop1 = new Aspose.Cells.GridDesktop.GridDesktop();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.Location = new System.Drawing.Point(215, 428);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Export To Specific DataTable";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gridDesktop1
            // 
            this.gridDesktop1.ActiveSheetIndex = 0;
            this.gridDesktop1.ActiveSheetNameFont = null;
            this.gridDesktop1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDesktop1.CommentDisplayingFont = new System.Drawing.Font("Arial", 9F);
            this.gridDesktop1.IsHorizontalScrollBarVisible = true;
            this.gridDesktop1.IsVerticalScrollBarVisible = true;
            this.gridDesktop1.Location = new System.Drawing.Point(12, 12);
            this.gridDesktop1.Name = "gridDesktop1";
            this.gridDesktop1.SheetNameFont = new System.Drawing.Font("Verdana", 8F);
            this.gridDesktop1.SheetTabWidth = 400;
            this.gridDesktop1.Size = new System.Drawing.Size(727, 410);
            this.gridDesktop1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(378, 428);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Export To New DataTable";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ExportDataToDataTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 463);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.gridDesktop1);
            this.Name = "ExportDataToDataTable";
            this.Text = "Export Data To DataTable";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ExportDataToDataTable_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private Aspose.Cells.GridDesktop.GridDesktop gridDesktop1;
        private System.Windows.Forms.Button button1;
    }
}