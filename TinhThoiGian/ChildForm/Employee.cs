using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace TinhThoiGian.ChildForm
{
    public partial class Employee : System.Windows.Forms.Form
    {
        private Helper.ExcelHepler excelHepler;
        private Helper.ListHelper listHelper;
        private Process[] excelProcsOld;
        public string filePath = "";
        public string dirPath = "";

        public Employee()
        {
            excelHepler = new Helper.ExcelHepler();
            listHelper = new Helper.ListHelper();

            this.excelProcsOld = Process.GetProcessesByName("EXCEL");
            this.dirPath = System.Reflection.Assembly.GetExecutingAssembly().Location
                                .Replace(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".exe", "");
            this.filePath = this.dirPath + "Document\\" + "employee.xls";

            InitializeComponent();


        }
        private void Employee_Load(object sender, EventArgs e)
        {
            if (File.Exists(this.dirPath + "Document\\" + "employee.xls"))
            {
                this.ShowData();
            }

        }


        private void importExcel_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;

            OpenFileDialog file = new OpenFileDialog();

            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = file.FileName;

                if (File.Exists(this.filePath))
                {
                    File.SetAttributes(this.filePath, FileAttributes.Normal);

                    File.Delete(Path.Combine(this.filePath));
                    File.Copy(filePath, this.dirPath + "Document\\" + "employee.xls");
                }
                else
                {
                    File.Copy(filePath, this.dirPath + "Document\\" + "employee.xls");

                }

                this.ShowData();
            }
        }


        private void excelGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewCellCollection cells = excelGridView.CurrentRow.Cells;

                string code = cells["Employee code"].Value.ToString();
                string name = cells["Name"].Value.ToString();
                string area = cells["Area"].Value.ToString();
                string time = cells["Time"].Value.ToString();
                string excelRowIndex = cells["ExcelRowIndex"].Value.ToString();

                ChildForm.UpdateEmployee updateEmployeeForm = new ChildForm.UpdateEmployee();

                updateEmployeeForm.EmpCode = code;
                updateEmployeeForm.EmpName = name;
                updateEmployeeForm.EmpArea = area;
                updateEmployeeForm.EmpTime = time;

                updateEmployeeForm.ShowDialog();

                if (updateEmployeeForm.EmpTime != "" && updateEmployeeForm.DialogResult == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;

                    var listValue = new List<KeyValuePair<int, string>>() {
                new KeyValuePair<int, string>(1, updateEmployeeForm.EmpCode),
                new KeyValuePair<int, string>(2, updateEmployeeForm.EmpName),
                new KeyValuePair<int, string>(3, updateEmployeeForm.EmpArea),
                new KeyValuePair<int, string>(4, updateEmployeeForm.EmpTime)
                    };

                    List<KeyValuePair<int, string>> listValueChanged = excelHepler.UpdateExcel(this.filePath, excelRowIndex, listValue);
                    foreach (var item in listValueChanged)
                    {
                        excelGridView.Rows[e.RowIndex].Cells[item.Key - 1].Value = item.Value;
                    }

                    //this.ShowData();
                }
            }
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = excelGridView.DataSource;
            bs.Filter = "[Name] like '%" + search.Text + "%'";
            excelGridView.DataSource = bs;
        }

        private void eportToExcel_Click(object sender, EventArgs e)
        {
            List<string> listRemoveColumn = new List<string>()
            {
                "ExcelRowIndex"
            };

            excelHepler.EportExcel(excelGridView, listRemoveColumn);
        }



        private void openFile_Click(object sender, EventArgs e)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location
.Replace(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".exe", "");
            string location = path + "Document";

            if (Directory.Exists(location))
            {
                Process.Start(location);
            }
        }

        private void ShowData()
        {
            try
            {
                ArrayList listData = excelHepler.ReadExcelInterop(this.filePath);

                if (listData.Count > 0)
                {
                    ArrayList addListFirst = (ArrayList)listData[0];
                    addListFirst.Add("ExcelRowIndex");

                    for (int i = 1; i < listData.Count; i++)
                    {
                        ArrayList listAdd = (ArrayList)listData[i];
                        listAdd.Add(i + 1);
                    }

                    DataTable data = listHelper.ArrayListToDataTable(listData);

                    excelGridView.Visible = true;
                    excelGridView.DataSource = data;
                    excelGridView.Columns["ExcelRowIndex"].Visible = false;
                    excelGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    excelGridView.Update();
                    excelGridView.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + ex.StackTrace.ToString() + ex.ToString());
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

