using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TinhThoiGian
{
    public partial class WorkTIme : System.Windows.Forms.Form
    {
        const string COLUMN_SUM = "Tổng thời gian muộn";
        const string COLUMN_LABOR = "Tổng số công";

        string filePath;
        string fileExt;

        bool forcusLabor = false;

        ArrayList listWorkTime;
        ArrayList listWeekEnds;
        ArrayList listTitle;
        ArrayList listExcelDataCheckTime;
        ArrayList listToWithLateTime;
        ArrayList listLackTime;
        ArrayList listMinuteLackTime;

        DataTable dataExcel;
        DataTable dataLackTime;
        DataTable dataCheckinout;

        BindingSource bindingSource;

        ArrayList listEmployee;

        Helper.ExcelHepler excelHepler;
        Helper.ListHelper listHelper;
        public WorkTIme()
        {
            this.filePath = string.Empty;
            this.fileExt = string.Empty;

            this.bindingSource = new BindingSource();

            this.excelHepler = new Helper.ExcelHepler();
            this.listHelper = new Helper.ListHelper();

            InitializeComponent();
        }
        private void WorkTIme_Load(object sender, EventArgs e)
        {

            // kill excel process nếu lớn hơn 10;

            //if (this.excelProcsOld.Length > 10)
            //{
            //    DialogResult dr = MessageBox.Show("Microsoft Excel Process đã hơn 10\nTổng: " + this.excelProcsOld.Length + "\nBạn nên xóa.", "Microsoft Excel Process Kill", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            //    if (dr == DialogResult.Yes)
            //    {
            //        foreach (Process item in this.excelProcsOld)
            //        {
            //            item.Kill();
            //        }
            //    }
            //}


            string dirpath = System.Reflection.Assembly.GetExecutingAssembly().Location
.Replace(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".exe", "");
            string filePath = dirpath + "Document\\" + "employee.xls";

            this.setEmpolyeeData(filePath);

            viewExcel.Enabled = false;
            viewCheckInOut.Enabled = false;
            viewLackTIme.Enabled = false;
            eportToExcel.Enabled = false;
            search.Enabled = false;
        }
        public void enableWorkTimeInportButton()
        {
            this.choise.Enabled = true;
        }
        private void choise_Click(object sender, EventArgs e)
        {

            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                this.filePath = file.FileName; //get the path of the file 

                this.fileExt = Path.GetExtension(this.filePath); //get the file extension  

                this.setData();
            }

        }

        public void setEmpolyeeData(string filePath)
        {
            this.listEmployee = excelHepler.ReadExcelInterop(filePath);

            if (this.listEmployee.Count <= 0)
            {
                this.choise.Enabled = false;
            }
        }
        public void setData()
        {
            if (this.fileExt != "")
            {
                if ((this.fileExt.CompareTo(".xls") == 0 || this.fileExt.CompareTo(".xlsx") == 0))
                {
                    try
                    {
                        //read excel file  
                        ArrayList excelData = excelHepler.ReadExcelInterop(this.filePath);
                        this.dataExcel = listHelper.ArrayListToDataTable(excelData);


                        this.listTitle = (ArrayList)excelData[0];

                        this.listWeekEnds = this.getListWeekends(listTitle);

                        this.listExcelDataCheckTime = this.getCheckTime(excelData);
                        this.dataCheckinout = listHelper.ArrayListToDataTable(this.listExcelDataCheckTime);

                        this.listWorkTime = this.caculateWorkTime(listExcelDataCheckTime);
                        //this.dataWorkTime = this.sumTimes(this.listWorkTime);

                        this.listLackTime = this.caculateLackTime(this.listToWithLateTime);
                        this.dataLackTime = this.sumTimes(this.listLackTime);

                        excelGridView.Visible = true;
                        excelGridView.DataSource = this.dataExcel;

                        viewExcel.Enabled = true;
                        viewCheckInOut.Enabled = true;
                        viewLackTIme.Enabled = true;
                        eportToExcel.Enabled = true;
                        search.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString() + " - " + ex.StackTrace.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }
            }
        }

        private void viewExcelFile_Click(object sender, EventArgs e)
        {
            this.forcusLabor = false;
            this.resetGridView(this.dataExcel);
        }
        private void viewExcel_Click(object sender, EventArgs e)
        {
            this.forcusLabor = false;
            this.resetGridView(this.dataCheckinout);
        }
        private void viewLackTime_Click(object sender, EventArgs e)
        {
            this.resetGridView(this.dataLackTime);
            forcusLabor = true;
        }
        public void resetGridView(DataTable data)
        {

            this.bindingSource.DataSource = data;
            this.bindingSource.Filter = "[Name] like '%" + search.Text + "%'";
            excelGridView.DataSource = this.bindingSource.DataSource;
            if (excelGridView.Columns.Contains(COLUMN_SUM))
            {
                excelGridView.Columns[COLUMN_SUM].DisplayIndex = 3;
            }
            if (excelGridView.Columns.Contains(COLUMN_LABOR))
            {
                excelGridView.Columns[COLUMN_LABOR].DisplayIndex = 4;
            }
        }

        private string[] splipTime(string time)
        {
            time = time.Trim();
            return time.Split('-');
        }

        private string getTimeStart(string[] time)
        {
            foreach (var item in time)
            {
                // nếu time >= 7h thì lấy
                if (this.toMinute(item) >= this.toMinute("07:00"))
                {
                    return item;
                }
            }
            return "";
        }

        private string getTimeStop(string[] time)
        {
            foreach (var item in Enumerable.Reverse(time).ToArray())
            {
                // nếu thời gian <= 9h thì lấy
                if (this.toMinute(item) <= this.toMinute("21:00"))
                {
                    return item;
                }
            }
            return "";
        }
        private ArrayList getListWeekends(ArrayList listTitle)
        {
            int index = 0;
            ArrayList listWeekends = new ArrayList();
            foreach (var item in listTitle)
            {
                try
                {
                    DateTime date = DateTime.Parse((string)item);

                    if ((int)date.DayOfWeek == 6 || (int)date.DayOfWeek == 0)
                    {
                        listWeekends.Add(index);
                    }
                }
                catch
                {

                }
                index++;
            }
            return listWeekends;
        }

        private ArrayList getCheckTime(ArrayList times)
        {
            ArrayList result = new ArrayList();

            foreach (IEnumerable time in times)
            {
                ArrayList resultItem = new ArrayList();
                int flag = 0;
                foreach (var item in time)
                {
                    if (flag >= 3 && item != null && item != System.DBNull.Value)
                    {
                        string[] splipItem = this.splipTime((string)item);

                        if (splipItem.Count() >= 2)
                        {
                            string addItem;

                            if (this.getTimeStop(splipItem) != "")
                            {
                                if (this.getTimeStart(splipItem).Equals(this.getTimeStop(splipItem)))
                                {
                                    addItem = this.getTimeStart(splipItem);
                                }
                                else
                                {
                                    addItem = this.getTimeStart(splipItem) + "-" + this.getTimeStop(splipItem);
                                }
                            }
                            else
                            {
                                addItem = this.getTimeStart(splipItem);
                            }

                            resultItem.Add(addItem);
                        }
                        else if (splipItem.Count() >= 1)
                        {
                            resultItem.Add((string)item);
                        }
                        else
                        {
                            resultItem.Add("");
                        }
                    }
                    else
                    {
                        resultItem.Add(item);
                    }
                    flag++;

                }
                result.Add(resultItem);
            }

            return result;
        }

        private ArrayList caculateWorkTime(ArrayList times)
        {
            //fix header
            ArrayList listHead = (ArrayList)times[0];
            //listHead.Insert(3, "Tổng thời gian làm");
            times.RemoveAt(0);
            ArrayList result = new ArrayList();
            result.Add(listHead);
            this.listToWithLateTime = new ArrayList();
            this.listToWithLateTime.Add(listHead);


            foreach (IEnumerable time in times)
            {
                ArrayList resultItem = new ArrayList();
                ArrayList resultItem2 = new ArrayList();

                int flag = 0;
                var partFultTime = this.getPartFullTimeById(this.listEmployee, getEployeeCodeByENum(time));

                foreach (var item in time)
                {
                    if (flag >= 3 && item != null && item != System.DBNull.Value)
                    {
                        string[] splipItem = this.splipTime((string)item);

                        List<int> arrResultItem = new List<int>();

                        if (splipItem.Count() >= 2)
                        {
                            int timeWorkItem = 0;
                            int timeWorkItem2 = 0;
                            int lateTime;

                            int checkin = this.toMinute(splipItem.First());
                            if (checkin < this.toMinute("08:00"))
                            {
                                checkin = this.toMinute("08 : 00");
                            }

                            int checkout = this.toMinute(splipItem.Last());
                            var aa = this.toHour(checkout);

                            if (checkin <= this.toMinute("11:45") &&
                                checkout >= this.toMinute("13:15")
                                && partFultTime != "Part")
                            {
                                timeWorkItem = checkout - checkin - 90;
                                timeWorkItem2 = timeWorkItem;
                            }

                            if (checkin <= this.toMinute("12:00") &&
                                checkout >= this.toMinute("13:15")
                                && partFultTime == "Part")
                            {
                                timeWorkItem = checkout - checkin - 90;
                                timeWorkItem2 = timeWorkItem;
                            }

                            if (checkin >= this.toMinute("11:45") &&
                               checkin <= this.toMinute("13:15") &&
                               checkout >= this.toMinute("13:15"))
                            {
                                timeWorkItem = checkout - this.toMinute("13:15");
                                timeWorkItem2 = timeWorkItem;
                            }

                            if (checkin <= this.toMinute("11:45") &&
                               checkout <= this.toMinute("13:15")
                               && partFultTime != "Part")
                            {
                                timeWorkItem = this.toMinute("11:45") - checkin;
                                timeWorkItem2 = timeWorkItem;
                            }

                            if (checkin <= this.toMinute("11:45") &&
                               checkout <= this.toMinute("13:15")
                               && partFultTime == "Part")
                            {
                                timeWorkItem = this.toMinute("12:00") - checkin;
                                timeWorkItem2 = timeWorkItem;
                            }

                            if (checkin <= this.toMinute("11:45") &&
                               checkout <= this.toMinute("11:45")
                               && partFultTime != "Part")
                            {
                                timeWorkItem = checkout - checkin;
                                timeWorkItem2 = timeWorkItem;
                            }

                            if (checkin <= this.toMinute("12:00") &&
                               checkout <= this.toMinute("12:00")
                               && partFultTime == "Part")
                            {
                                timeWorkItem = checkout - checkin;
                                timeWorkItem2 = timeWorkItem;
                            }

                            if (checkin >= this.toMinute("13:15") &&
                               checkout >= this.toMinute("13:15"))
                            {
                                timeWorkItem = checkout - checkin;
                                timeWorkItem2 = timeWorkItem;
                            }

                            // nếu quá 9h thì không được làm bù
                            var lamBu = checkout - this.toMinute("17:30");
                            var overtime = lamBu;
                            var qua9h = checkin - this.toMinute("09:00");
                            if (checkin >= this.toMinute("11:45") && checkin <= this.toMinute("13:15"))
                            {
                                qua9h = this.toMinute("11:45") - this.toMinute("09:00");
                            }
                            else if (checkin > this.toMinute("13:15"))
                            {
                                qua9h = checkin - this.toMinute("09:00") - 90;
                            }

                            var abc = this.toHour(qua9h);

                            if (partFultTime != "Part" && checkin > this.toMinute("09:00") && checkin < this.toMinute("17:30"))
                            {
                                if (lamBu > qua9h)
                                {
                                    lamBu = lamBu - qua9h;
                                }
                                else
                                {
                                    lamBu = 0;
                                }



                                lateTime = qua9h;
                                //timeWorkItem = ((this.toMinute("17:30") + lamBu) - (90 + checkin));

                                if (checkout < this.toMinute("18:30"))
                                {
                                    timeWorkItem = checkout - checkin - 90;
                                }else
                                {
                                    timeWorkItem = this.toMinute("18:30") - checkin - 90;
                                }




                                //var e = this.toHour((this.toMinute("17:30") + lamBu));

                                var c = toHour(timeWorkItem);

                                //var d = this.toHour(this.toMinute("18:00") - this.toMinute("09:15") - 90);



                                //timeWorkItem2 = (this.toMinute("17:30") + lamBu - 90 - this.toMinute("09:00"));
                            }
                            else
                            {
                                lateTime = 0;
                            }

                            resultItem.Add(lamBu);

                            //arrResultItem.Add(qua9h);
                            arrResultItem.Add(qua9h);

                            arrResultItem.Add(timeWorkItem);
                            arrResultItem.Add(lateTime);

                            arrResultItem.Add(overtime);


                            resultItem2.Add(arrResultItem);
                        }
                        else
                        {
                            resultItem.Add("");
                            resultItem2.Add("");
                        }
                    }
                    else
                    {
                        resultItem.Add(item);
                        resultItem2.Add(item);
                    }
                    flag++;

                }
                result.Add(resultItem);
                this.listToWithLateTime.Add(resultItem2);
            }
            return result;
        }
        private ArrayList caculateLackTime(ArrayList arrayList)
        {
            arrayList.RemoveAt(0);
            this.listMinuteLackTime = new ArrayList();
            ArrayList result = new ArrayList();

            foreach (IEnumerable items in arrayList)
            {
                ArrayList resultItem = new ArrayList();
                ArrayList resultItemMinute = new ArrayList();
                int count = 0;
                string partFultTime = this.getPartFullTimeById(this.listEmployee, getEployeeCodeByENum(items));

                foreach (var item in items)
                {
                    if (count >= 3)
                    {
                        if (item != System.DBNull.Value && !this.listWeekEnds.Contains(count))
                        {
                            int lamBu = 0;
                            int dataWorkTime = 0;
                            int qua9h = 0;

                            int overtime = 0;
                            if (!item.GetType().FullName.Equals("System.String"))
                            {
                                var checkTime = (List<int>)item;
                                //lamBu = (int)checkTime.First();
                                //qua9h = (int)checkTime[1];
                                dataWorkTime = (int)checkTime[1];
                                //= (int)checkTime[2];
                                overtime = (int)checkTime.Last();
                            }

                            var a = this.toHour(dataWorkTime);

                            if (dataWorkTime < this.toMinute("08 : 00") || qua9h > 0)
                            {
                                int minuteLack;
                                if (partFultTime == "Part")
                                {
                                    minuteLack = this.toMinute("04 : 00") - dataWorkTime;
                                }
                                else
                                {
                                    minuteLack = this.toMinute("08 : 00") - dataWorkTime;
                                }


  
                                //if (lateTime > 0 && lateTime <= overtime)
                                //{
                                //    minuteLack = minuteLack;
                                //}
                                //else if (lateTime > 0 && lateTime > overtime)
                                //{
                                //    minuteLack = lateTime + lateTime;
                                //}
                                //else
                                //{
                                //    minuteLack = lateTime;
                                //}

                                string timeLack = "";
                                if (minuteLack > 0)
                                {
                                    timeLack = this.toHour(minuteLack);
                                }
                                else
                                {
                                    timeLack = "00 : 00";
                                }

                                resultItem.Add(timeLack);
                                resultItemMinute.Add(minuteLack);
                            }
                            else
                            {
                                resultItem.Add("00 : 00");
                                resultItemMinute.Add("");
                            }
                        }
                        else if (this.listWeekEnds.Contains(count))
                        {
                            resultItem.Add("");
                            resultItemMinute.Add("");
                        }
                        else
                        {
                            if (partFultTime == "Part")
                            {
                                resultItem.Add("04 : 00");
                                resultItemMinute.Add(this.toMinute("04:00"));
                            }
                            else
                            {
                                resultItem.Add("08 : 00");
                                resultItemMinute.Add(this.toMinute("08:00"));
                            }
                        }
                    }
                    else
                    {
                        resultItem.Add(item);
                        resultItemMinute.Add(item);
                    }
                    count++;
                }
                result.Add(resultItem);
                this.listMinuteLackTime.Add(resultItemMinute);
            }
            result.Insert(0, this.listTitle);
            this.listMinuteLackTime.Insert(0, this.listTitle);
            return result;
        }
        private DataTable sumTimes(ArrayList listData)
        {
            //bool flagHead = true;
            int countRow = 0;

            foreach (IEnumerable items in listData)
            {
                if (countRow > 0)
                {
                    int total = 0;
                    int countColumn = 0;
                    double countLabor = 0;
                    ArrayList itemClone = (ArrayList)items;


                    //foreach (var item in itemClone)
                    //{
                    //    if (item != System.DBNull.Value)
                    //    {
                    //        if (countColumn >= 3 && (string)item != "")
                    //        {
                    //            int minute = this.toMinute((string)item);
                    //            double labor = 0;
                    //            total += minute;

                    //            if (minute <= this.toMinute("02:00"))
                    //            {

                    //                labor = 1;
                    //            }
                    //            else if(minute > this.toMinute("06:00"))
                    //            {
                    //                labor = 0;
                    //            }
                    //            else if (minute > this.toMinute("02:00"))
                    //            {
                    //                labor = 0.5;
                    //                var item2 = item;
                    //                item2 = item + "/0.5";

                    //            }
                    //            countLabor += labor;
                    //        }

                    //    }
                    //    countColumn++;
                    //}

                    for (int i = 0; i < itemClone.Count; i++)
                    {
                        var abc = itemClone[i];
                        if (itemClone[i] != System.DBNull.Value)
                        {
                            if (countColumn >= 3 && (string)itemClone[i] != "")
                            {
                                int minute = this.toMinute((string)itemClone[i]);
                                double labor = 0;


                                if (minute <= this.toMinute("02:00"))
                                {
                                    total += minute;
                                    labor = 1;
                                }
                                else if (minute > this.toMinute("06:00"))
                                {
                                    labor = 0;
                                    total += minute;
                                }
                                else if (minute > this.toMinute("02:00"))
                                {
                                    labor = 0.5;

                                    var timeWork = this.toMinute("08:00") - this.toMinute(itemClone[i].ToString());


                                    if (timeWork > this.toMinute("04:00"))
                                    {
                                        var overTime = timeWork - this.toMinute("04:00");
                                        itemClone[i] = "0.5";
                                        total += 0;

                                    }
                                    else
                                    {
                                        var lackTime = this.toMinute("04:00") - timeWork;
                                        itemClone[i] = "0.5 - " + this.toHour(lackTime);
                                        total += lackTime;

                                    }


                                }
                                countLabor += labor;
                            }

                        }
                        countColumn++;
                    }



                    itemClone.Insert(3, (total != 0) ? total : 0 );
                    itemClone.Insert(4, countLabor);
                    countRow++;
                }
                else
                {
                    //flagHead = false;
                    countRow++;
                }

            }
            ArrayList listHead = (ArrayList)listData[0];

            if (!listHead.Contains(COLUMN_SUM))
            {
                listHead.Insert(3, COLUMN_SUM);
            }
            if (!listHead.Contains(COLUMN_LABOR))
            {
                listHead.Insert(4, COLUMN_LABOR);
            }
            return listHelper.ArrayListToDataTable(listData);
        }
        private string getEployeeCodeByENum(IEnumerable collection)
        {
            foreach (var item in collection)
            {
                try
                {
                    return (string)item;
                }
                catch
                {
                }
            }
            return "";
        }

        private string getPartFullTimeById(ArrayList arrayList, string employeeCode)
        {

            foreach (ArrayList item in arrayList)
            {
                if (item.Contains(employeeCode))
                {
                    return (string)item[3];
                }
            }
            return "";
        }

        private int toMinute(string time)
        {
            time = time.Trim();
            string[] splipTime = time.Split(':');
            int minute;
            try
            {
                minute = Int32.Parse(splipTime.First()) * 60 + Int32.Parse(splipTime.Last());
            }
            catch
            {
                minute = -1;
            }

            return minute;
        }
        private string toHour(int time)
        {
            if (time < 1)
            {
                return "";
            }

            decimal hour = Math.Floor((decimal)time / 60);
            decimal minute = (decimal)time % 60;

            return hour.ToString("00") + " : " + minute.ToString("00");
        }

        private void eportToExcel_Click(object sender, EventArgs e)
        {
            excelHepler.EportExcel(excelGridView);
        }


        private void search_TextChanged(object sender, EventArgs e)
        {
            this.resetGridView((DataTable)excelGridView.DataSource);
        }

        private void excelGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex != -1)
            {
                tt.SetToolTip(this.excelGridView, this.excelGridView.Columns[e.ColumnIndex].HeaderCell.FormattedValue.ToString());
            }
            else
            {
                tt.Hide(this.excelGridView);

            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void WorkTIme_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void WorkTIme_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void excelGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
    }
}
