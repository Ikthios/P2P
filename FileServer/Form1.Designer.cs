namespace FileServer
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
            this.Txt_destpath = new System.Windows.Forms.TextBox();
            this.Btn_filedest = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Txt_destpath
            // 
            this.Txt_destpath.Location = new System.Drawing.Point(13, 49);
            this.Txt_destpath.Name = "Txt_destpath";
            this.Txt_destpath.Size = new System.Drawing.Size(259, 20);
            this.Txt_destpath.TabIndex = 0;
            // 
            // Btn_filedest
            // 
            this.Btn_filedest.Location = new System.Drawing.Point(13, 76);
            this.Btn_filedest.Name = "Btn_filedest";
            this.Btn_filedest.Size = new System.Drawing.Size(75, 23);
            this.Btn_filedest.TabIndex = 1;
            this.Btn_filedest.Text = "Browse";
            this.Btn_filedest.UseVisualStyleBackColor = true;
            this.Btn_filedest.Click += new System.EventHandler(this.Btn_filedest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_filedest);
            this.Controls.Add(this.Txt_destpath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_destpath;
        private System.Windows.Forms.Button Btn_filedest;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
    }
}

