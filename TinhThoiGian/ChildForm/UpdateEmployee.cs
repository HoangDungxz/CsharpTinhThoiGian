using System;

using System.Windows.Forms;

namespace TinhThoiGian.ChildForm
{
    public partial class UpdateEmployee : Form
    {
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string EmpArea { get; set; }
        public string EmpTime { get; set; }

        public UpdateEmployee()
        {
            InitializeComponent();
 
        }
        private void UpdateEmployee_Load(object sender, EventArgs e)
        {
            textEmpCode.Text = this.EmpCode;
            textEmpName.Text = this.EmpName;
            textEmpArea.Text = this.EmpArea;

            cboEmpTime.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEmpTime.Items.Add("Part");
            cboEmpTime.Items.Add("Full");
            if (EmpTime == "")
            {
                cboEmpTime.SelectedIndex = cboEmpTime.FindStringExact("Full");
            }else
            {
                cboEmpTime.SelectedIndex = cboEmpTime.FindStringExact(EmpTime);
            }
            
        }

        private void submit_Click(object sender, EventArgs e)
        {
            this.EmpTime = cboEmpTime.Text;
            this.EmpCode = textEmpCode.Text;
            this.EmpName = textEmpName.Text;
            this.EmpArea = textEmpArea.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
