namespace DatabaseCodeGenrator
{
    partial class Frm_MySql
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Generate = new System.Windows.Forms.Button();
            this.rdo_WithDAL = new System.Windows.Forms.RadioButton();
            this.rdo_OL = new System.Windows.Forms.RadioButton();
            this.cbo_DatabaseName = new System.Windows.Forms.ComboBox();
            this.btn_DatabaseSearch = new System.Windows.Forms.Button();
            this.btn_TestConnection = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_PassWord = new System.Windows.Forms.TextBox();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.txt_ServerName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 254);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(317, 20);
            this.progressBar1.TabIndex = 28;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Generate);
            this.groupBox1.Controls.Add(this.rdo_WithDAL);
            this.groupBox1.Controls.Add(this.rdo_OL);
            this.groupBox1.Location = new System.Drawing.Point(21, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(225, 100);
            this.groupBox1.TabIndex = 27;
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
            // cbo_DatabaseName
            // 
            this.cbo_DatabaseName.FormattingEnabled = true;
            this.cbo_DatabaseName.Location = new System.Drawing.Point(104, 119);
            this.cbo_DatabaseName.Name = "cbo_DatabaseName";
            this.cbo_DatabaseName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbo_DatabaseName.Size = new System.Drawing.Size(224, 21);
            this.cbo_DatabaseName.TabIndex = 26;
            // 
            // btn_DatabaseSearch
            // 
            this.btn_DatabaseSearch.Location = new System.Drawing.Point(132, 90);
            this.btn_DatabaseSearch.Name = "btn_DatabaseSearch";
            this.btn_DatabaseSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_DatabaseSearch.Size = new System.Drawing.Size(137, 23);
            this.btn_DatabaseSearch.TabIndex = 24;
            this.btn_DatabaseSearch.Text = "Search For Databases";
            this.btn_DatabaseSearch.UseVisualStyleBackColor = true;
            // 
            // btn_TestConnection
            // 
            this.btn_TestConnection.Location = new System.Drawing.Point(21, 90);
            this.btn_TestConnection.Name = "btn_TestConnection";
            this.btn_TestConnection.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_TestConnection.Size = new System.Drawing.Size(105, 23);
            this.btn_TestConnection.TabIndex = 25;
            this.btn_TestConnection.Text = "Test Connection";
            this.btn_TestConnection.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 67);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Password :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 15);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Server Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 122);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Database Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 41);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "User Name :";
            // 
            // txt_PassWord
            // 
            this.txt_PassWord.Location = new System.Drawing.Point(90, 64);
            this.txt_PassWord.Name = "txt_PassWord";
            this.txt_PassWord.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_PassWord.Size = new System.Drawing.Size(238, 20);
            this.txt_PassWord.TabIndex = 17;
            this.txt_PassWord.Text = "M0hammed@Zak1";
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(90, 38);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_UserName.Size = new System.Drawing.Size(238, 20);
            this.txt_UserName.TabIndex = 16;
            this.txt_UserName.Text = "root";
            // 
            // txt_ServerName
            // 
            this.txt_ServerName.Location = new System.Drawing.Point(90, 12);
            this.txt_ServerName.Name = "txt_ServerName";
            this.txt_ServerName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_ServerName.Size = new System.Drawing.Size(238, 20);
            this.txt_ServerName.TabIndex = 15;
            this.txt_ServerName.Text = "localhost";
            // 
            // Frm_MySql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 291);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbo_DatabaseName);
            this.Controls.Add(this.btn_DatabaseSearch);
            this.Controls.Add(this.btn_TestConnection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_PassWord);
            this.Controls.Add(this.txt_UserName);
            this.Controls.Add(this.txt_ServerName);
            this.Name = "Frm_MySql";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Generate;
        private System.Windows.Forms.RadioButton rdo_WithDAL;
        private System.Windows.Forms.RadioButton rdo_OL;
        private System.Windows.Forms.ComboBox cbo_DatabaseName;
        private System.Windows.Forms.Button btn_DatabaseSearch;
        private System.Windows.Forms.Button btn_TestConnection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_PassWord;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.TextBox txt_ServerName;
    }
}