namespace GUIClient
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.txt_ImagePath = new System.Windows.Forms.TextBox();
            this.txt_ServerIp = new System.Windows.Forms.TextBox();
            this.pic_ImageBox = new System.Windows.Forms.PictureBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(13, 48);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(75, 23);
            this.btn_Browse.TabIndex = 1;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // txt_ImagePath
            // 
            this.txt_ImagePath.Location = new System.Drawing.Point(95, 50);
            this.txt_ImagePath.Name = "txt_ImagePath";
            this.txt_ImagePath.Size = new System.Drawing.Size(177, 20);
            this.txt_ImagePath.TabIndex = 2;
            // 
            // txt_ServerIp
            // 
            this.txt_ServerIp.Location = new System.Drawing.Point(95, 10);
            this.txt_ServerIp.Name = "txt_ServerIp";
            this.txt_ServerIp.Size = new System.Drawing.Size(177, 20);
            this.txt_ServerIp.TabIndex = 3;
            // 
            // pic_ImageBox
            // 
            this.pic_ImageBox.Location = new System.Drawing.Point(13, 91);
            this.pic_ImageBox.Name = "pic_ImageBox";
            this.pic_ImageBox.Size = new System.Drawing.Size(259, 134);
            this.pic_ImageBox.TabIndex = 4;
            this.pic_ImageBox.TabStop = false;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(13, 226);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 5;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.pic_ImageBox);
            this.Controls.Add(this.txt_ServerIp);
            this.Controls.Add(this.txt_ImagePath);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pic_ImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.TextBox txt_ImagePath;
        private System.Windows.Forms.TextBox txt_ServerIp;
        private System.Windows.Forms.PictureBox pic_ImageBox;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

