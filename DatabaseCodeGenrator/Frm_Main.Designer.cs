namespace DatabaseCodeGenrator
{
    partial class Frm_Main
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
            this.txt_PassWord = new System.Windows.Forms.TextBox();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.txt_ServerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rdo_WindowsAuthentication = new System.Windows.Forms.RadioButton();
            this.rdo_SQLAuthentication = new System.Windows.Forms.RadioButton();
            this.btn_TestConnection = new System.Windows.Forms.Button();
            this.btn_DatabaseSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_DatabaseName = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Generate = new System.Windows.Forms.Button();
            this.rdo_WithDAL = new System.Windows.Forms.RadioButton();
            this.rdo_OL = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fromMySqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_PassWord
            // 
            this.txt_PassWord.Location = new System.Drawing.Point(91, 134);
            this.txt_PassWord.Name = "txt_PassWord";
            this.txt_PassWord.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_PassWord.Size = new System.Drawing.Size(238, 20);
            this.txt_PassWord.TabIndex = 6;
            this.txt_PassWord.Text = "M0hammed@Zak1";
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(91, 108);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_UserName.Size = new System.Drawing.Size(238, 20);
            this.txt_UserName.TabIndex = 5;
            this.txt_UserName.Text = "sa";
            // 
            // txt_ServerName
            // 
            this.txt_ServerName.Location = new System.Drawing.Point(91, 33);
            this.txt_ServerName.Name = "txt_ServerName";
            this.txt_ServerName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_ServerName.Size = new System.Drawing.Size(238, 20);
            this.txt_ServerName.TabIndex = 4;
            this.txt_ServerName.Text = "MohammedZaki-PC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 111);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "User Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 36);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Server Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 137);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Password :";
            // 
            // rdo_WindowsAuthentication
            // 
            this.rdo_WindowsAuthentication.AutoSize = true;
            this.rdo_WindowsAuthentication.Location = new System.Drawing.Point(12, 59);
            this.rdo_WindowsAuthentication.Name = "rdo_WindowsAuthentication";
            this.rdo_WindowsAuthentication.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rdo_WindowsAuthentication.Size = new System.Drawing.Size(162, 17);
            this.rdo_WindowsAuthentication.TabIndex = 9;
            this.rdo_WindowsAuthentication.TabStop = true;
            this.rdo_WindowsAuthentication.Text = "Use Windows Authentication";
            this.rdo_WindowsAuthentication.UseVisualStyleBackColor = true;
            this.rdo_WindowsAuthentication.CheckedChanged += new System.EventHandler(this.rdo_WindowsAuthentication_CheckedChanged);
            // 
            // rdo_SQLAuthentication
            // 
            this.rdo_SQLAuthentication.AutoSize = true;
            this.rdo_SQLAuthentication.Location = new System.Drawing.Point(12, 82);
            this.rdo_SQLAuthentication.Name = "rdo_SQLAuthentication";
            this.rdo_SQLAuthentication.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rdo_SQLAuthentication.Size = new System.Drawing.Size(173, 17);
            this.rdo_SQLAuthentication.TabIndex = 9;
            this.rdo_SQLAuthentication.TabStop = true;
            this.rdo_SQLAuthentication.Text = "Use SQL Server Authentication";
            this.rdo_SQLAuthentication.UseVisualStyleBackColor = true;
            // 
            // btn_TestConnection
            // 
            this.btn_TestConnection.Location = new System.Drawing.Point(22, 160);
            this.btn_TestConnection.Name = "btn_TestConnection";
            this.btn_TestConnection.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_TestConnection.Size = new System.Drawing.Size(105, 23);
            this.btn_TestConnection.TabIndex = 10;
            this.btn_TestConnection.Text = "Test Connection";
            this.btn_TestConnection.UseVisualStyleBackColor = true;
            this.btn_TestConnection.Click += new System.EventHandler(this.btn_TestConnection_Click);
            // 
            // btn_DatabaseSearch
            // 
            this.btn_DatabaseSearch.Location = new System.Drawing.Point(133, 160);
            this.btn_DatabaseSearch.Name = "btn_DatabaseSearch";
            this.btn_DatabaseSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_DatabaseSearch.Size = new System.Drawing.Size(137, 23);
            this.btn_DatabaseSearch.TabIndex = 10;
            this.btn_DatabaseSearch.Text = "Search For Databases";
            this.btn_DatabaseSearch.UseVisualStyleBackColor = true;
            this.btn_DatabaseSearch.Click += new System.EventHandler(this.btn_DatabaseSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 202);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Database Name :";
            // 
            // cbo_DatabaseName
            // 
            this.cbo_DatabaseName.FormattingEnabled = true;
            this.cbo_DatabaseName.Location = new System.Drawing.Point(105, 199);
            this.cbo_DatabaseName.Name = "cbo_DatabaseName";
            this.cbo_DatabaseName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbo_DatabaseName.Size = new System.Drawing.Size(224, 21);
            this.cbo_DatabaseName.TabIndex = 11;
            this.cbo_DatabaseName.SelectedIndexChanged += new System.EventHandler(this.cbo_DatabaseName_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Generate);
            this.groupBox1.Controls.Add(this.rdo_WithDAL);
            this.groupBox1.Controls.Add(this.rdo_OL);
            this.groupBox1.Location = new System.Drawing.Point(22, 226);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(225, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Genrate Code Type ";
            // 
            // btn_Generate
            // 
            this.btn_Generate.Location = new System.Drawing.Point(10, 65);
            this.btn_Generate.Name = "btn_Generate";
            this.btn_Generate.Size = new System.Drawing.Size(201, 23);
            this.btn_Generate.TabIndex = 10;
            this.btn_Generate.Text = "Generate Database Code ";
            this.btn_Generate.UseVisualStyleBackColor = true;
            this.btn_Generate.Click += new System.EventHandler(this.btn_Generate_Click);
            // 
            // rdo_WithDAL
            // 
            this.rdo_WithDAL.AutoSize = true;
            this.rdo_WithDAL.Location = new System.Drawing.Point(10, 19);
            this.rdo_WithDAL.Name = "rdo_WithDAL";
            this.rdo_WithDAL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rdo_WithDAL.Size = new System.Drawing.Size(203, 17);
            this.rdo_WithDAL.TabIndex = 9;
            this.rdo_WithDAL.TabStop = true;
            this.rdo_WithDAL.Text = "Genrate Code With DataAccessLayer";
            this.rdo_WithDAL.UseVisualStyleBackColor = true;
            // 
            // rdo_OL
            // 
            this.rdo_OL.AutoSize = true;
            this.rdo_OL.Location = new System.Drawing.Point(10, 42);
            this.rdo_OL.Name = "rdo_OL";
            this.rdo_OL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rdo_OL.Size = new System.Drawing.Size(201, 17);
            this.rdo_OL.TabIndex = 9;
            this.rdo_OL.TabStop = true;
            this.rdo_OL.Text = "Genrate Code For Object Layer Only";
            this.rdo_OL.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 334);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(317, 20);
            this.progressBar1.TabIndex = 13;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromMySqlToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(348, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fromMySqlToolStripMenuItem
            // 
            this.fromMySqlToolStripMenuItem.Name = "fromMySqlToolStripMenuItem";
            this.fromMySqlToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.fromMySqlToolStripMenuItem.Text = "From MySql";
            this.fromMySqlToolStripMenuItem.Click += new System.EventHandler(this.fromMySqlToolStripMenuItem_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 366);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbo_DatabaseName);
            this.Controls.Add(this.btn_DatabaseSearch);
            this.Controls.Add(this.btn_TestConnection);
            this.Controls.Add(this.rdo_SQLAuthentication);
            this.Controls.Add(this.rdo_WindowsAuthentication);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_PassWord);
            this.Controls.Add(this.txt_UserName);
            this.Controls.Add(this.txt_ServerName);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frm_Main";
            this.Text = "Database Object Layer Code Genrator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_PassWord;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.TextBox txt_ServerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdo_WindowsAuthentication;
        private System.Windows.Forms.RadioButton rdo_SQLAuthentication;
        private System.Windows.Forms.Button btn_TestConnection;
        private System.Windows.Forms.Button btn_DatabaseSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbo_DatabaseName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdo_WithDAL;
        private System.Windows.Forms.RadioButton rdo_OL;
        private System.Windows.Forms.Button btn_Generate;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fromMySqlToolStripMenuItem;
    }
}

