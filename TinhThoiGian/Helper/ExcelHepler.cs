using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace TinhThoiGian.Helper
{
  
    class ExcelHepler
    {
        public ArrayList ReadExcelInterop(string pathOfExcelFile, int columnCount = -1)
        {
            Process[] excelProcsOld = Process.GetProcessesByName("EXCEL");
            if (!File.Exists(pathOfExcelFile))
            {
                System.Windows.Forms.MessageBox.Show("File "+ pathOfExcelFile+ "\nKhông tồn tại\nVui lòng -> Nhập file");
                return new ArrayList();
            }

            ArrayList arrayList = new ArrayList();

            try
            {
                Application xlApp = new Application();

                Workbook xlWorkbook = xlApp.Workbooks.Open(pathOfExcelFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing); //This opens the file

                Worksheet xlWorksheet = (Worksheet)xlWorkbook.Sheets.get_Item(1); //Get the first sheet in the file

                int lastRow = xlWorksheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, Type.Missing).Row;
                int lastColumn = xlWorksheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, Type.Missing).Column;

                Range xlRange = xlWorksheet.UsedRange;//("A1",lastColumnIndex + lastRow.ToString());


                xlRange.EntireColumn.AutoFit();

                object[,] cellValues = (object[,])xlRange.Value2;
                object[] values = new object[lastColumn];

                if (columnCount <= 0)
                {
                    columnCount = lastColumn;
                }

                for (int i = 1; i <= lastRow; i++)
                {
                    ArrayList item = new ArrayList();
                    for (int j = 1; j <= columnCount; j++)
                    {
                        var cell = cellValues[i, j];

                        if (cell != null)
                        {
                            item.Add(cell.ToString());
                        }
                        else
                        {
                            item.Add("");
                        }

                    }

                    arrayList.Add(item);
                }

                xlWorkbook.Close(false, Type.Missing, Type.Missing);

                Marshal.FinalReleaseComObject(xlRange);
                Marshal.FinalReleaseComObject(xlWorksheet);
                Marshal.FinalReleaseComObject(xlWorkbook);

                xlRange = null;
                xlWorksheet = null;
                xlWorkbook = null;
                xlApp.Quit();
                Marshal.FinalReleaseComObject(xlApp);
                xlApp = null;
            }
            catch (Exception ex)
            {
                this.KillExcelProcess(excelProcsOld);
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.KillExcelProcess(excelProcsOld);
            }

            return arrayList;

        }

        public void EportExcel(System.Windows.Forms.DataGridView dataExcelGridView, List<string> listExceptColumn = null)
        {
            Process[] excelProcsOld = Process.GetProcessesByName("EXCEL");
            ChildForm.ProgressBar progressBar = null;
            try
            {
                System.Windows.Forms.DataGridView excelGridView = dataExcelGridView;

                progressBar = new ChildForm.ProgressBar();
                progressBar.Show();

                // creating Excel Application  
                _Application xlApp = new Application();

                xlApp.ScreenUpdating = false;
                xlApp.DisplayAlerts = false;

                xlApp.AutomationSecurity = Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityByUI;
                xlApp.AskToUpdateLinks = false;
                // creating new WorkBook within Excel application  
                _Workbook xlWorkbook = (_Workbook)(xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet));

                // creating new Excelsheet in workbook  
                _Worksheet xlWorksheet = null;
                // see the excel sheet behind the program  

                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                xlWorksheet = xlWorkbook.Sheets["Sheet1"];
                // changing the name of active sheet  
                xlWorksheet.Name = "Exported file";

                // storing header part in Excel

                if (listExceptColumn != null)
                {
                    foreach (string removeColumn in listExceptColumn)
                    {
                        excelGridView.Columns.Remove(removeColumn);
                    }
                }

                for (int i = 1; i < excelGridView.Columns.Count + 1; i++)
                {
                    xlWorksheet.Cells[1, i] = excelGridView.Columns[i - 1].HeaderText;
                }

                var def = excelGridView.ColumnCount * (excelGridView.RowCount - 1);
                // storing Each row and column value to excel sheet  
                int abc = 1;
                for (int i = 0; i < excelGridView.RowCount - 1; i++)
                {
                    for (int j = 0; j < excelGridView.ColumnCount; j++)
                    {
                        xlWorksheet.Cells[i + 2, j + 1] = excelGridView.Rows[i].Cells[j].Value.ToString();
                        int percents = (abc * 100) / def;
                        progressBar.progress.Value = percents;
                        abc++;
                    }
                }
                xlApp.ScreenUpdating = true;
                xlApp.DisplayAlerts = true;
                xlApp.AskToUpdateLinks = true;

                xlApp.Visible = true;
                xlApp.Quit();

            }
            catch (Exception ex)
            {
                this.KillExcelProcess(excelProcsOld);
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {

                if (progressBar != null)
                {
                    progressBar.Dispose();
                }
                System.Windows.Forms.MessageBox.Show("Ok");
                this.KillExcelProcess(excelProcsOld);
            }

        }
        public List<KeyValuePair<int, string>> UpdateExcel(string path, string rowIndex, List<KeyValuePair<int, string>> listValue)
        {
            Process[] excelProcsOld = Process.GetProcessesByName("EXCEL");
            try
            {
                Application xlApp = new Application();

                xlApp.ScreenUpdating = false;


                xlApp.AutomationSecurity = Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityByUI;
                xlApp.AskToUpdateLinks = false;

                Workbook xlWorkbook = xlApp.Workbooks.Open(path);
                Worksheet xlWorksheet = (Worksheet)xlWorkbook.Sheets.get_Item(1); //Get the first sheet in the file

                Range xlRange = xlWorksheet.UsedRange;//("A1",lastColumnIndex + lastRow.ToString());

                foreach (KeyValuePair<int, string> item in listValue)
                {
                    xlRange[rowIndex, item.Key].Value = item.Value;
                }

                xlWorkbook.Save();
                xlWorkbook.Close();

                Marshal.FinalReleaseComObject(xlRange);
                Marshal.FinalReleaseComObject(xlWorksheet);
                Marshal.FinalReleaseComObject(xlWorkbook);

                xlRange = null;
                xlWorksheet = null;
                xlWorkbook = null;
                xlApp.Quit();
                Marshal.FinalReleaseComObject(xlApp);
                xlApp = null;
            }
            catch (Exception ex)
            {
                this.KillExcelProcess(excelProcsOld);
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.KillExcelProcess(excelProcsOld);
            }

            return this.GetValueChanged(rowIndex, path, listValue);
        }


        public List<KeyValuePair<int, string>> GetValueChanged(string row, string path, List<KeyValuePair<int, string>> listValue)
        {
            Process[] excelProcsOld = Process.GetProcessesByName("EXCEL");
            List<KeyValuePair<int, string>> listValueChanged = new List<KeyValuePair<int, string>>();
            try
            {
                Application xlApp = new Application();
                Workbook xlWorkbook = xlApp.Workbooks.Open(path);
                Worksheet xlWorksheet = (Worksheet)xlWorkbook.Sheets.get_Item(1); //Get the first sheet in the file

                Range xlRange = xlWorksheet.UsedRange;//("A1",lastColumnIndex + lastRow.ToString());

                foreach (KeyValuePair<int, string> item in listValue)
                {
                    KeyValuePair<int, string> valueChanged = new KeyValuePair<int, string>(
                    item.Key, xlRange[row, item.Key].Value != null ? xlRange[row, item.Key].Value.ToString() : ""
                    );
                    listValueChanged.Add(valueChanged);
                }
                xlWorkbook.Close();

                Marshal.FinalReleaseComObject(xlRange);
                Marshal.FinalReleaseComObject(xlWorksheet);
                Marshal.FinalReleaseComObject(xlWorkbook);

                xlRange = null;
                xlWorksheet = null;
                xlWorkbook = null;
                xlApp.Quit();
                Marshal.FinalReleaseComObject(xlApp);
                xlApp = null;
            }
            catch (Exception ex)
            {
                this.KillExcelProcess(excelProcsOld);
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.KillExcelProcess(excelProcsOld);
            }
            return listValueChanged;
        }

        //private System.Windows.Forms.DataGridView copyDataGridView(System.Windows.Forms.DataGridView dgv_org)
        //{
        //    Process[] excelProcsOld = Process.GetProcessesByName("EXCEL");
        //    System.Windows.Forms.DataGridView dgv_copy = new System.Windows.Forms.DataGridView();
        //    try
        //    {
        //        if (dgv_copy.Columns.Count == 0)
        //        {
        //            foreach (System.Windows.Forms.DataGridViewColumn dgvc in dgv_org.Columns)
        //            {
        //                dgv_copy.Columns.Add(dgvc.Clone() as System.Windows.Forms.DataGridViewColumn);
        //            }
        //        }

        //        System.Windows.Forms.DataGridViewRow row = new System.Windows.Forms.DataGridViewRow();

        //        for (int i = 0; i < dgv_org.Rows.Count; i++)
        //        {
        //            row = (System.Windows.Forms.DataGridViewRow)dgv_org.Rows[i].Clone();
        //            int intColIndex = 0;
        //            foreach (System.Windows.Forms.DataGridViewCell cell in dgv_org.Rows[i].Cells)
        //            {
        //                row.Cells[intColIndex].Value = cell.Value;
        //                intColIndex++;
        //            }
        //            dgv_copy.Rows.Add(row);
        //        }
        //        dgv_copy.AllowUserToAddRows = false;
        //        dgv_copy.Refresh();

        //    }
        //    catch
        //    {

        //    }
        //    return dgv_copy;
        //}
        public void KillExcelProcess(Process[] procOlds)
        {
                //Compare the EXCEL ID and Kill it 
                Process[] excelProcsNew = Process.GetProcessesByName("EXCEL");
                foreach (Process procNew in excelProcsNew)
                {
                    int exist = 0;
                    foreach (Process procOld in procOlds)
                    {
                        if (procNew.Id == procOld.Id)
                        {
                            exist++;
                        }
                    }
                    if (exist == 0)
                    {
                        procNew.Kill();
                    }
                }
        }
    }
}
