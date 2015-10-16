namespace Client
{
    partial class ClientForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.coreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startInternalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fileSearchBtn = new System.Windows.Forms.Button();
            this.fileSearchBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.peerListBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.connTabPage = new System.Windows.Forms.TabPage();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.connStatBtn = new System.Windows.Forms.Button();
            this.portComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorTabPage = new System.Windows.Forms.TabPage();
            this.errorTextBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.downMonBtn = new System.Windows.Forms.Button();
            this.localhostAddressTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.connTabPage.SuspendLayout();
            this.errorTabPage.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coreToolStripMenuItem,
            this.serverToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // coreToolStripMenuItem
            // 
            this.coreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newClientToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.coreToolStripMenuItem.Name = "coreToolStripMenuItem";
            this.coreToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.coreToolStripMenuItem.Text = "Client";
            // 
            // newClientToolStripMenuItem
            // 
            this.newClientToolStripMenuItem.Name = "newClientToolStripMenuItem";
            this.newClientToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newClientToolStripMenuItem.Text = "New Client";
            this.newClientToolStripMenuItem.Click += new System.EventHandler(this.newClientToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startInternalToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.serverToolStripMenuItem.Text = "Server";
            // 
            // startInternalToolStripMenuItem
            // 
            this.startInternalToolStripMenuItem.Name = "startInternalToolStripMenuItem";
            this.startInternalToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.startInternalToolStripMenuItem.Text = "Start Internal";
            this.startInternalToolStripMenuItem.Click += new System.EventHandler(this.startInternalToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.06612F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.93388F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.60641F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.39359F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(484, 437);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Tan;
            this.groupBox1.Controls.Add(this.fileSearchBtn);
            this.groupBox1.Controls.Add(this.fileSearchBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Search";
            // 
            // fileSearchBtn
            // 
            this.fileSearchBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.fileSearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fileSearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileSearchBtn.Location = new System.Drawing.Point(138, 16);
            this.fileSearchBtn.Name = "fileSearchBtn";
            this.fileSearchBtn.Size = new System.Drawing.Size(102, 26);
            this.fileSearchBtn.TabIndex = 1;
            this.fileSearchBtn.Text = "Search";
            this.fileSearchBtn.UseVisualStyleBackColor = false;
            this.fileSearchBtn.Click += new System.EventHandler(this.fileSearchBtn_Click);
            // 
            // fileSearchBox
            // 
            this.fileSearchBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.fileSearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileSearchBox.Location = new System.Drawing.Point(3, 16);
            this.fileSearchBox.Name = "fileSearchBox";
            this.fileSearchBox.Size = new System.Drawing.Size(132, 26);
            this.fileSearchBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Tan;
            this.groupBox2.Controls.Add(this.peerListBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(255, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 236);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Peer Listing";
            // 
            // peerListBox
            // 
            this.peerListBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.peerListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.peerListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.peerListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peerListBox.Location = new System.Drawing.Point(3, 16);
            this.peerListBox.Multiline = true;
            this.peerListBox.Name = "peerListBox";
            this.peerListBox.ReadOnly = true;
            this.peerListBox.Size = new System.Drawing.Size(220, 217);
            this.peerListBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Tan;
            this.groupBox3.Controls.Add(this.tabControl1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 245);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(246, 189);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server Connection Status";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.connTabPage);
            this.tabControl1.Controls.Add(this.errorTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 170);
            this.tabControl1.TabIndex = 0;
            // 
            // connTabPage
            // 
            this.connTabPage.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.connTabPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.connTabPage.Controls.Add(this.localhostAddressTextBox);
            this.connTabPage.Controls.Add(this.addressTextBox);
            this.connTabPage.Controls.Add(this.label2);
            this.connTabPage.Controls.Add(this.connStatBtn);
            this.connTabPage.Controls.Add(this.portComboBox);
            this.connTabPage.Controls.Add(this.label1);
            this.connTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connTabPage.Location = new System.Drawing.Point(4, 22);
            this.connTabPage.Name = "connTabPage";
            this.connTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.connTabPage.Size = new System.Drawing.Size(232, 144);
            this.connTabPage.TabIndex = 0;
            this.connTabPage.Text = "Connections";
            // 
            // addressTextBox
            // 
            this.addressTextBox.AllowDrop = true;
            this.addressTextBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.addressTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addressTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressTextBox.Location = new System.Drawing.Point(6, 37);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(121, 22);
            this.addressTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(130, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // connStatBtn
            // 
            this.connStatBtn.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.connStatBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.connStatBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connStatBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connStatBtn.Location = new System.Drawing.Point(3, 3);
            this.connStatBtn.Name = "connStatBtn";
            this.connStatBtn.Size = new System.Drawing.Size(224, 28);
            this.connStatBtn.TabIndex = 0;
            this.connStatBtn.Text = "Connect to Server";
            this.connStatBtn.UseVisualStyleBackColor = false;
            this.connStatBtn.Click += new System.EventHandler(this.connStatBtn_Click);
            // 
            // portComboBox
            // 
            this.portComboBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.portComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portComboBox.FormattingEnabled = true;
            this.portComboBox.Items.AddRange(new object[] {
            "6000",
            "6500",
            "7000",
            "7500",
            "8000",
            "8500",
            "9000",
            "9500"});
            this.portComboBox.Location = new System.Drawing.Point(6, 62);
            this.portComboBox.Name = "portComboBox";
            this.portComboBox.Size = new System.Drawing.Size(121, 24);
            this.portComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(130, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP Address";
            // 
            // errorTabPage
            // 
            this.errorTabPage.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.errorTabPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.errorTabPage.Controls.Add(this.errorTextBox);
            this.errorTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorTabPage.Location = new System.Drawing.Point(4, 22);
            this.errorTabPage.Name = "errorTabPage";
            this.errorTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.errorTabPage.Size = new System.Drawing.Size(232, 105);
            this.errorTabPage.TabIndex = 1;
            this.errorTabPage.Text = "Errors";
            // 
            // errorTextBox
            // 
            this.errorTextBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.errorTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorTextBox.Location = new System.Drawing.Point(3, 3);
            this.errorTextBox.Multiline = true;
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.ReadOnly = true;
            this.errorTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.errorTextBox.Size = new System.Drawing.Size(224, 97);
            this.errorTextBox.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Tan;
            this.groupBox4.Controls.Add(this.downMonBtn);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(255, 245);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(226, 189);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Download Manager";
            // 
            // downMonBtn
            // 
            this.downMonBtn.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.downMonBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.downMonBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downMonBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downMonBtn.Location = new System.Drawing.Point(3, 16);
            this.downMonBtn.Name = "downMonBtn";
            this.downMonBtn.Size = new System.Drawing.Size(220, 28);
            this.downMonBtn.TabIndex = 0;
            this.downMonBtn.Text = "Download Monitor";
            this.downMonBtn.UseVisualStyleBackColor = false;
            // 
            // localhostAddressTextBox
            // 
            this.localhostAddressTextBox.AllowDrop = true;
            this.localhostAddressTextBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.localhostAddressTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.localhostAddressTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localhostAddressTextBox.Location = new System.Drawing.Point(6, 92);
            this.localhostAddressTextBox.Name = "localhostAddressTextBox";
            this.localhostAddressTextBox.Size = new System.Drawing.Size(121, 22);
            this.localhostAddressTextBox.TabIndex = 6;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clinet P2P";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.connTabPage.ResumeLayout(false);
            this.connTabPage.PerformLayout();
            this.errorTabPage.ResumeLayout(false);
            this.errorTabPage.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem coreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox fileSearchBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox peerListBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button connStatBtn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button downMonBtn;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox portComboBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage connTabPage;
        private System.Windows.Forms.TabPage errorTabPage;
        private System.Windows.Forms.TextBox errorTextBox;
        private System.Windows.Forms.Button fileSearchBtn;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startInternalToolStripMenuItem;
        private System.Windows.Forms.TextBox localhostAddressTextBox;
    }
}

