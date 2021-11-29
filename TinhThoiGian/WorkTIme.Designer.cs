
namespace TinhThoiGian
{
    partial class WorkTIme
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.choise = new System.Windows.Forms.Button();
            this.excelGridView = new System.Windows.Forms.DataGridView();
            this.eportToExcel = new System.Windows.Forms.Button();
            this.viewExcel = new System.Windows.Forms.Button();
            this.viewCheckInOut = new System.Windows.Forms.Button();
            this.viewLackTIme = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.TextBox();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.excelGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // choise
            // 
            this.choise.Cursor = System.Windows.Forms.Cursors.Hand;
            this.choise.Location = new System.Drawing.Point(12, 22);
            this.choise.Name = "choise";
            this.choise.Size = new System.Drawing.Size(127, 42);
            this.choise.TabIndex = 0;
            this.choise.Tag = "0";
            this.choise.Text = "Chọn excel file";
            this.choise.UseVisualStyleBackColor = true;
            this.choise.Click += new System.EventHandler(this.choise_Click);
            // 
            // excelGridView
            // 
            this.excelGridView.AllowUserToAddRows = false;
            this.excelGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.excelGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.excelGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.excelGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.excelGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.excelGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.excelGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.excelGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.excelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3, 0, 10, 3);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.excelGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.excelGridView.EnableHeadersVisualStyles = false;
            this.excelGridView.Location = new System.Drawing.Point(13, 87);
            this.excelGridView.Name = "excelGridView";
            this.excelGridView.ReadOnly = true;
            this.excelGridView.Size = new System.Drawing.Size(1420, 531);
            this.excelGridView.TabIndex = 1;
            this.excelGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.excelGridView_CellMouseEnter);
            this.excelGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.excelGridView_DataBindingComplete);
            // 
            // eportToExcel
            // 
            this.eportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.eportToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eportToExcel.Location = new System.Drawing.Point(1275, 22);
            this.eportToExcel.Name = "eportToExcel";
            this.eportToExcel.Size = new System.Drawing.Size(158, 42);
            this.eportToExcel.TabIndex = 5;
            this.eportToExcel.Tag = "6";
            this.eportToExcel.Text = "Lưu bảng ra Excel";
            this.eportToExcel.UseVisualStyleBackColor = true;
            this.eportToExcel.Click += new System.EventHandler(this.eportToExcel_Click);
            // 
            // viewExcel
            // 
            this.viewExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.viewExcel.Location = new System.Drawing.Point(145, 22);
            this.viewExcel.Name = "viewExcel";
            this.viewExcel.Size = new System.Drawing.Size(127, 42);
            this.viewExcel.TabIndex = 0;
            this.viewExcel.Tag = "1";
            this.viewExcel.Text = "Xem file excel";
            this.viewExcel.UseVisualStyleBackColor = true;
            this.viewExcel.Click += new System.EventHandler(this.viewExcelFile_Click);
            // 
            // viewCheckInOut
            // 
            this.viewCheckInOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.viewCheckInOut.Location = new System.Drawing.Point(278, 22);
            this.viewCheckInOut.Name = "viewCheckInOut";
            this.viewCheckInOut.Size = new System.Drawing.Size(127, 42);
            this.viewCheckInOut.TabIndex = 0;
            this.viewCheckInOut.Tag = "2";
            this.viewCheckInOut.Text = "Xem check in out";
            this.viewCheckInOut.UseVisualStyleBackColor = true;
            this.viewCheckInOut.Click += new System.EventHandler(this.viewExcel_Click);
            // 
            // viewLackTIme
            // 
            this.viewLackTIme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.viewLackTIme.Location = new System.Drawing.Point(411, 22);
            this.viewLackTIme.Name = "viewLackTIme";
            this.viewLackTIme.Size = new System.Drawing.Size(204, 42);
            this.viewLackTIme.TabIndex = 0;
            this.viewLackTIme.Tag = "4";
            this.viewLackTIme.Text = "Tính công và thới gian muộn";
            this.viewLackTIme.UseVisualStyleBackColor = true;
            this.viewLackTIme.Click += new System.EventHandler(this.viewLackTime_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Location = new System.Drawing.Point(1142, 22);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(127, 42);
            this.button5.TabIndex = 0;
            this.button5.Tag = "5";
            this.button5.Text = "Nhân viên";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // search
            // 
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.search.Location = new System.Drawing.Point(734, 26);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(385, 38);
            this.search.TabIndex = 6;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // tt
            // 
            this.tt.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // WorkTIme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1445, 630);
            this.Controls.Add(this.search);
            this.Controls.Add(this.eportToExcel);
            this.Controls.Add(this.excelGridView);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.viewLackTIme);
            this.Controls.Add(this.viewCheckInOut);
            this.Controls.Add(this.viewExcel);
            this.Controls.Add(this.choise);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "WorkTIme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chấm công";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkTIme_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WorkTIme_FormClosed);
            this.Load += new System.EventHandler(this.WorkTIme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.excelGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button choise;
        private System.Windows.Forms.Button eportToExcel;
        private System.Windows.Forms.Button viewExcel;
        private System.Windows.Forms.Button viewCheckInOut;
        private System.Windows.Forms.Button viewLackTIme;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.ToolTip tt;
        public System.Windows.Forms.Button button5;
        public System.Windows.Forms.DataGridView excelGridView;
    }
}

