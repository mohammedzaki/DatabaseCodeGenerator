using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DatabaseCodeGenrator
{
    public partial class SqlStoredProcedures : Form
    {
        public SqlStoredProcedures()
        {
            InitializeComponent();
        }
        private static string ConnectionString = "Data Source=MOHAMMEDZAKI-PC;Initial Catalog=master;Integrated Security=True";
        private void SqlStoredProcedures_Load(object sender, EventArgs e)
        {
            foreach (string StoredProceduresNames in GetData())
                CBO_STPR.Items.Add(StoredProceduresNames);
            DGV_StoredSQL.DataSource = GetStoredProcedureData();
        }

        public static DataTable GetStoredProcedureData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                connection.Open();
                command = new SqlCommand("select ROUTINE_DEFINITION from ContractingSystem.information_schema.routines where routine_type = 'PROCEDURE'", connection);
                dt.Load(command.ExecuteReader());
            }
            return dt;
        }

        public static List<string> GetData()
        {
            List<string> Data = new List<string>();
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                connection.Open();
                command = new SqlCommand("select ROUTINE_NAME from ContractingSystem.information_schema.routines where routine_type = 'PROCEDURE'", connection);
                dt.Load(command.ExecuteReader());
                foreach (DataRow row in dt.Rows)
                    Data.Add(row[0].ToString());
            }

            return Data;
        }

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
            this.CBO_STPR = new System.Windows.Forms.ComboBox();
            this.lbl_STPR = new System.Windows.Forms.Label();
            this.DGV_StoredSQL = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_StoredSQL)).BeginInit();
            this.SuspendLayout();
            // 
            // CBO_STPR
            // 
            this.CBO_STPR.FormattingEnabled = true;
            this.CBO_STPR.Location = new System.Drawing.Point(152, 12);
            this.CBO_STPR.Name = "CBO_STPR";
            this.CBO_STPR.Size = new System.Drawing.Size(121, 21);
            this.CBO_STPR.TabIndex = 0;
            this.CBO_STPR.SelectedIndexChanged += new System.EventHandler(this.CBO_STPR_SelectedIndexChanged);
            // 
            // lbl_STPR
            // 
            this.lbl_STPR.AutoSize = true;
            this.lbl_STPR.Location = new System.Drawing.Point(12, 15);
            this.lbl_STPR.Name = "lbl_STPR";
            this.lbl_STPR.Size = new System.Drawing.Size(133, 13);
            this.lbl_STPR.TabIndex = 1;
            this.lbl_STPR.Text = "Stored Procedure Names :";
            // 
            // DGV_StoredSQL
            // 
            this.DGV_StoredSQL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_StoredSQL.Location = new System.Drawing.Point(15, 67);
            this.DGV_StoredSQL.Name = "DGV_StoredSQL";
            this.DGV_StoredSQL.Size = new System.Drawing.Size(257, 182);
            this.DGV_StoredSQL.TabIndex = 2;
            this.DGV_StoredSQL.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_StoredSQL_CellContentClick);
            // 
            // SqlStoredProcedures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.DGV_StoredSQL);
            this.Controls.Add(this.lbl_STPR);
            this.Controls.Add(this.CBO_STPR);
            this.Name = "SqlStoredProcedures";
            this.Text = "SqlStoredProcedures";
            this.Load += new System.EventHandler(this.SqlStoredProcedures_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_StoredSQL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBO_STPR;
        private System.Windows.Forms.Label lbl_STPR;
        private System.Windows.Forms.DataGridView DGV_StoredSQL;

        private void CBO_STPR_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DGV_StoredSQL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
