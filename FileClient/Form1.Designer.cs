namespace FileClient
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
            this.Txt_filepath = new System.Windows.Forms.TextBox();
            this.Btn_browse = new System.Windows.Forms.Button();
            this.Btn_send = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // Txt_filepath
            // 
            this.Txt_filepath.Location = new System.Drawing.Point(12, 36);
            this.Txt_filepath.Name = "Txt_filepath";
            this.Txt_filepath.Size = new System.Drawing.Size(260, 20);
            this.Txt_filepath.TabIndex = 0;
            // 
            // Btn_browse
            // 
            this.Btn_browse.Location = new System.Drawing.Point(12, 62);
            this.Btn_browse.Name = "Btn_browse";
            this.Btn_browse.Size = new System.Drawing.Size(75, 23);
            this.Btn_browse.TabIndex = 1;
            this.Btn_browse.Text = "Browse";
            this.Btn_browse.UseVisualStyleBackColor = true;
            this.Btn_browse.Click += new System.EventHandler(this.Btn_browse_Click);
            // 
            // Btn_send
            // 
            this.Btn_send.Location = new System.Drawing.Point(93, 62);
            this.Btn_send.Name = "Btn_send";
            this.Btn_send.Size = new System.Drawing.Size(75, 23);
            this.Btn_send.TabIndex = 2;
            this.Btn_send.Text = "Send";
            this.Btn_send.UseVisualStyleBackColor = true;
            this.Btn_send.Click += new System.EventHandler(this.Btn_send_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.Btn_send);
            this.Controls.Add(this.Btn_browse);
            this.Controls.Add(this.Txt_filepath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_filepath;
        private System.Windows.Forms.Button Btn_browse;
        private System.Windows.Forms.Button Btn_send;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

