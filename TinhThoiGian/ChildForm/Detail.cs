using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinhThoiGian.ChildForm
{
    public partial class Detail : Form
    {
        public Detail()
        {
            InitializeComponent();
            for (int i = 0; i < 35; i++)
            {
                System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();
                // 
                // date
                // 
                Label lbldate = new Label();
                lbldate.AutoSize = true;
                lbldate.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                lbldate.Location = new Point(-3, 0);
                lbldate.Name = "lbldate" + i;
                lbldate.Size = new Size(75, 13);
                lbldate.TabIndex = 0;
                lbldate.Text = "10/01/2021";
                panel.Controls.Add(lbldate) ;

                // 
                // lblin
                // 
                Label lblin = new Label();
                lblin.AutoSize = true;
                lblin.Location = new System.Drawing.Point(33, 18);
                lblin.Name = "lblin" + i;
                lblin.Size = new System.Drawing.Size(40, 13);
                lblin.TabIndex = 1;
                lblin.Text = "08 : 00";
                panel.Controls.Add(lblin);

                //
                // inTitle
                //
                Label inTitle = new Label();
                inTitle.AutoSize = true;
                inTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                inTitle.Location = new System.Drawing.Point(-1, 18);
                inTitle.Name = "inTitle" + i;
                inTitle.Size = new System.Drawing.Size(25, 12);
                inTitle.TabIndex = 1;
                inTitle.Text = "Đến:";
                inTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                panel.Controls.Add(inTitle);

                //
                // out
                //
                Label lblout = new Label();
                lblout.AutoSize = true;
                lblout.Location = new System.Drawing.Point(33, 31);
                lblout.Name = "lblout" + i;
                lblout.Size = new System.Drawing.Size(40, 13);
                lblout.TabIndex = 2;
                lblout.Text = "08 : 00";
                panel.Controls.Add(lblout);

                // 
                // outTitle
                // 
                Label outTitle = new Label();
                outTitle.AutoSize = true;
                outTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                outTitle.Location = new System.Drawing.Point(-1, 31);
                outTitle.Name = "outTitle" + i;
                outTitle.Size = new System.Drawing.Size(20, 12);
                outTitle.TabIndex = 1;
                outTitle.Text = "Về:";
                outTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                panel.Controls.Add(outTitle);

                // 
                // lblWork
                // 
                Label lblWork = new Label();
                lblWork.AutoSize = true;
                lblWork.Location = new System.Drawing.Point(33, 47);
                lblWork.Name = "lblWork" + i;
                lblWork.Size = new System.Drawing.Size(40, 13);
                lblWork.TabIndex = 5;
                lblWork.Text = "08 : 00";
                panel.Controls.Add(lblWork);

                // 
                // workTitle
                //
                Label workTitle = new Label();
                workTitle.AutoSize = true;
                workTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                workTitle.Location = new System.Drawing.Point(-1, 47);
                workTitle.Name = "workTitle" + i;
                workTitle.Size = new System.Drawing.Size(23, 12);
                workTitle.TabIndex = 4;
                workTitle.Text = "Làm";
                workTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                panel.Controls.Add(workTitle);

                // 
                // lblLack
                //
                Label lblLack = new Label();
                lblLack.AutoSize = true;
                lblLack.Location = new System.Drawing.Point(33, 60);
                lblLack.Name = "lblLack" + i;
                lblLack.Size = new System.Drawing.Size(40, 13);
                lblLack.TabIndex = 6;
                lblLack.Text = "08 : 00";
                panel.Controls.Add(lblLack);

                // 
                // lackTitle
                //
                Label lackTitle = new Label();
                lackTitle.AutoSize = true;
                lackTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lackTitle.Location = new System.Drawing.Point(-1, 60);
                lackTitle.Name = "lackTitle" + i;
                lackTitle.Size = new System.Drawing.Size(27, 12);
                lackTitle.TabIndex = 3;
                lackTitle.Text = "Thiếu";
                lackTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                panel.Controls.Add(lackTitle);

                panel.Location = new Point(0, 0);
                panel.Name = "panel" + i;
                panel.Size = new Size(71, 74);
                panel.TabIndex = 0;
                this.tableLayoutPanel1.Controls.Add(panel);
            }

          
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Detail_Load(object sender, EventArgs e)
        {
           

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
