using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinhThoiGian
{
    public partial class MainForm : Form
    {
       private ChildForm.Employee employee;
       private WorkTIme workTime;
        public MainForm()
        {
            
            this.workTime = new WorkTIme();

            InitializeComponent();
            this.workTime.Show();
            this.workTime.button5.Click += new System.EventHandler(this.button5_Click);        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.employee != null)
            {
                this.employee = new ChildForm.Employee();
                this.employee.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Employee_FormClosed);
                employee.Show();
            }
            else
            {
                this.employee = new ChildForm.Employee();
                this.employee.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Employee_FormClosed);
                employee.Show();
            };

        }

        private void Employee_FormClosed(object sender, FormClosedEventArgs e)
        {
                this.workTime.setEmpolyeeData(this.employee.filePath);
                this.workTime.setData();
                this.workTime.excelGridView.Update();
                this.workTime.excelGridView.Refresh();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
