
namespace TinhThoiGian.ChildForm
{
    partial class Employee
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.excelGridView = new System.Windows.Forms.DataGridView();
            this.openFile = new System.Windows.Forms.Button();
            this.eportToExcel = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.TextBox();
            this.importExcel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.excelGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.excelGridView);
            this.panel1.Location = new System.Drawing.Point(-8, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(599, 499);
            this.panel1.TabIndex = 0;
            // 
            // excelGridView
            // 
            this.excelGridView.AllowUserToAddRows = false;
            this.excelGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.excelGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.excelGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.excelGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.excelGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.excelGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.excelGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.excelGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.excelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.excelGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.excelGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.excelGridView.EnableHeadersVisualStyles = false;
            this.excelGridView.Location = new System.Drawing.Point(19, 16);
            this.excelGridView.Name = "excelGridView";
            this.excelGridView.ReadOnly = true;
            this.excelGridView.Size = new System.Drawing.Size(560, 466);
            this.excelGridView.TabIndex = 6;
            this.excelGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.excelGridView_CellClick);
            // 
            // openFile
            // 
            this.openFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.openFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openFile.Location = new System.Drawing.Point(12, 12);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(97, 35);
            this.openFile.TabIndex = 7;
            this.openFile.Text = "Mở thư mục file";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // eportToExcel
            // 
            this.eportToExcel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.eportToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eportToExcel.Location = new System.Drawing.Point(219, 12);
            this.eportToExcel.Name = "eportToExcel";
            this.eportToExcel.Size = new System.Drawing.Size(97, 35);
            this.eportToExcel.TabIndex = 8;
            this.eportToExcel.Text = "Xuất file excel";
            this.eportToExcel.UseVisualStyleBackColor = true;
            this.eportToExcel.Click += new System.EventHandler(this.eportToExcel_Click);
            // 
            // search
            // 
            this.search.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.search.Location = new System.Drawing.Point(322, 12);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(249, 35);
            this.search.TabIndex = 5;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // importExcel
            // 
            this.importExcel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.importExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.importExcel.Location = new System.Drawing.Point(115, 12);
            this.importExcel.Name = "importExcel";
            this.importExcel.Size = new System.Drawing.Size(98, 35);
            this.importExcel.TabIndex = 8;
            this.importExcel.Text = "Nhập file excel";
            this.importExcel.UseVisualStyleBackColor = true;
            this.importExcel.Click += new System.EventHandler(this.importExcel_Click);
            // 
            // Employee
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(584, 542);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.importExcel);
            this.Controls.Add(this.eportToExcel);
            this.Controls.Add(this.search);
            this.Name = "Employee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee";
            this.Load += new System.EventHandler(this.Employee_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.excelGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Button eportToExcel;
        private System.Windows.Forms.DataGridView excelGridView;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.Button importExcel;
    }
}