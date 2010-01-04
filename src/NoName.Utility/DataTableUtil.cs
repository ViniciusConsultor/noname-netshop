using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace NoName.Utility
{
    public class DataTableUtil
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table1"></param>
        /// <param name="table2"></param>
        /// <returns></returns>
        public static DataTable AddTwoTables(DataTable table1, DataTable table2)
        {
            for (int i = 0; i < table2.Rows.Count; i++)
            {
                DataRow row = table1.NewRow();
                row.ItemArray = table2.Rows[i].ItemArray;
                table1.Rows.Add(row);
            }
            return table1;
        }

        /// <summary>
        /// Implements the function like "GROUP BY" sentence in SQL
        /// and returns an array of datatable which is grouped by column name of given datatable
        /// </summary>
        /// <param name="table">DataTable needed to be grouped</param>
        /// <param name="GroupBy">One column name of given datatable</param>
        /// <returns></returns>
        public static DataTable[] GroupDataTable(DataTable table, string GroupBy)
        {
            ArrayList DistinctList = new ArrayList();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                string DistinctName = table.Rows[i][GroupBy].ToString();
                bool has = false;

                for (int j = 0; j < DistinctList.Count; j++)
                {
                    if (DistinctName == DistinctList[j].ToString())
                    {
                        has = true;
                    }
                }
                if (!has)
                {
                    DistinctList.Add(DistinctName);
                }
            }
            DataTable[] TableArray = new DataTable[DistinctList.Count];

            for (int i = 0; i < DistinctList.Count; i++)
            {
                DataRow[] rows;

                if (!String.IsNullOrEmpty(DistinctList[i].ToString()))
                    rows = table.Select(GroupBy + "='" + DistinctList[i].ToString() + "'");
                else
                    rows = table.Select("isnull(" + GroupBy + ",'NaN')='NaN'");

                TableArray[i] = table.Clone();

                for (int j = 0; j < rows.Length; j++)
                {
                    DataRow NewRow = TableArray[i].NewRow();
                    NewRow.ItemArray = rows[j].ItemArray;
                    TableArray[i].Rows.Add(NewRow);
                }
            }
            return TableArray;
        }
        /// <summary>
        /// remove rows of a datatable that do not match the condition that column value equals given value
        /// </summary>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DataTable FilterTable(DataTable table, string column, string value)
        {
            DataTable rtnTable = table.Clone();

            DataRow[] rows = table.Select(column + "='" + value + "'");
            for (int i = 0; i < rows.Length; i++)
            {
                DataRow row = rtnTable.NewRow();
                row.ItemArray = rows[i].ItemArray;
                rtnTable.Rows.Add(row);
            }
            return rtnTable;
        }
        /// <summary>
        /// remove rows of a datatable that do not match the condition that column value equals given values
        /// </summary>
        /// <param name="table"></param>
        /// <param name="ColumnName"></param>
        /// <param name="values">values given by an array of string</param>
        /// <returns></returns>
        public static DataTable FilterTable(DataTable table, string ColumnName, string[] values)
        {
            DataTable rtnTable = table.Clone();

            for (int t = 0; t < values.Length; t++)
            {
                DataRow[] rows = table.Select(ColumnName + "='" + values[t] + "'");
                for (int i = 0; i < rows.Length; i++)
                {
                    DataRow row = rtnTable.NewRow();
                    row.ItemArray = rows[i].ItemArray;
                    rtnTable.Rows.Add(row);
                }
            }

            return rtnTable;
        }

        /// <summary>
        /// returns the row which contains the minmum value of a column
        /// </summary>
        /// <param name="table"></param>
        /// <param name="ColumnName"></param>
        /// <returns></returns>
        public static DataRow DataTableMinRow(DataTable table, string ColumnName)
        {
            DataRow TheRow = table.Rows[0];

            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (decimal.Parse(table.Rows[i][ColumnName].ToString()) < decimal.Parse(TheRow[ColumnName].ToString()))
                {
                    TheRow = table.Rows[i];
                }
            }

            return TheRow;
        }

        /// <summary>
        /// returns the row which contains the maxmum value of a column
        /// </summary>
        /// <param name="table"></param>
        /// <param name="ColumnName"></param>
        /// <returns></returns>
        public static DataRow DataTableMaxRow(DataTable table, string ColumnName)
        {
            DataRow TheRow = table.Rows[0];

            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (decimal.Parse(table.Rows[i][ColumnName].ToString()) > decimal.Parse(TheRow[ColumnName].ToString()))
                {
                    TheRow = table.Rows[i];
                }
            }

            return TheRow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="Select"></param>
        /// <returns></returns>
        public static DataTable Select(DataTable table, string Select)
        {
            DataTable rtnTable = table.Clone();
            DataRow[] rows = table.Select(Select);
            if (rows.Length > 0)
                foreach (DataRow row in rows)
                {
                    DataRow r = rtnTable.NewRow();
                    r.ItemArray = row.ItemArray;
                    rtnTable.Rows.Add(r);
                }
            return rtnTable;
        }

        /// <summary>
        /// 由枚举获取DataTable
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static DataTable GetEnumKeyValue(Type enumType)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("key");
            dt.Columns.Add("value");

            foreach (object code in Enum.GetValues(enumType))
            {
                DataRow row = dt.NewRow();
                row["value"] = (int)code;
                row["key"] = Enum.GetName(enumType, code);
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
