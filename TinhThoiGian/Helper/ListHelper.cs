using System;
using System.Collections;
using System.Data;
namespace TinhThoiGian.Helper
{
    class ListHelper
    {
        public System.Data.DataTable ArrayListToDataTable(ArrayList arrayList)
        {
            System.Data.DataTable table = new System.Data.DataTable("table");
            DataColumn column;
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");

            foreach (IEnumerable items in arrayList)
            {
                foreach (var item in items)
                {
                    column = new DataColumn();
                    column.DataType = Type.GetType("System.String");
                    if (item != System.DBNull.Value)
                    {
                        column.ColumnName = (string)item;
                    }
                    else
                    {
                        column.ColumnName = ""; ;
                    }
                    try
                    {
                        table.Columns.Add(column);
                    }
                    catch
                    {
                    }

                }
                break;
            }
            bool flag = false;
            foreach (ArrayList item in arrayList)
            {
                if (flag)
                {
                    var stringArray = item.ToArray();
                    table.Rows.Add(stringArray);
                }
                flag = true;
            }
            return table;
        }
    }
}
