
namespace TinhThoiGian.ChildForm
{
    partial class UpdateEmployee
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textEmpArea = new System.Windows.Forms.TextBox();
            this.textEmpName = new System.Windows.Forms.TextBox();
            this.textEmpCode = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.cboEmpTime = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textEmpArea);
            this.panel1.Controls.Add(this.textEmpName);
            this.panel1.Controls.Add(this.textEmpCode);
            this.panel1.Controls.Add(this.submit);
            this.panel1.Controls.Add(this.cboEmpTime);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 249);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ca làm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Vị trí:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tên:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Mã:";
            // 
            // textEmpArea
            // 
            this.textEmpArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textEmpArea.Location = new System.Drawing.Point(138, 98);
            this.textEmpArea.Name = "textEmpArea";
            this.textEmpArea.Size = new System.Drawing.Size(248, 23);
            this.textEmpArea.TabIndex = 6;
            // 
            // textEmpName
            // 
            this.textEmpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textEmpName.Location = new System.Drawing.Point(138, 60);
            this.textEmpName.Name = "textEmpName";
            this.textEmpName.Size = new System.Drawing.Size(248, 23);
            this.textEmpName.TabIndex = 7;
            // 
            // textEmpCode
            // 
            this.textEmpCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textEmpCode.Location = new System.Drawing.Point(138, 26);
            this.textEmpCode.Name = "textEmpCode";
            this.textEmpCode.Size = new System.Drawing.Size(248, 23);
            this.textEmpCode.TabIndex = 8;
            // 
            // submit
            // 
            this.submit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submit.Location = new System.Drawing.Point(138, 184);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(145, 40);
            this.submit.TabIndex = 5;
            this.submit.Text = "Đồng ý";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // cboEmpTime
            // 
            this.cboEmpTime.AllowDrop = true;
            this.cboEmpTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboEmpTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboEmpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cboEmpTime.Location = new System.Drawing.Point(138, 141);
            this.cboEmpTime.Name = "cboEmpTime";
            this.cboEmpTime.Size = new System.Drawing.Size(248, 25);
            this.cboEmpTime.TabIndex = 4;
            // 
            // UpdateEmployee
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(413, 249);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UpdateEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UpdateEmployee";
            this.Load += new System.EventHandler(this.UpdateEmployee_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textEmpArea;
        private System.Windows.Forms.TextBox textEmpName;
        private System.Windows.Forms.TextBox textEmpCode;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.ComboBox cboEmpTime;
    }
}