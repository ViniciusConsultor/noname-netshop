using System;
using System.Collections.Generic;
using System.Text;

namespace NoName.NetShop.Common
{
    /// <summary>
    /// SearchPageInfo 的摘要说明。
    /// 分页查询信息
    /// </summary>
    [Serializable]
    public class SearchPageInfo
    {
        /// <summary>
        /// 数据表名（主表），排序和统计都建立在其上
        /// </summary>
        public string TableName;
        /// <summary>
        /// 主表的主键名或标示列名，关联或者排序通过它来进行,
        /// 不能带上表名，如：field1
        /// </summary>
        public string PriKeyName;
        /// <summary>
        /// 要查询的字段名，多表查询时要用 表名.字段名，
        /// 多个字段时通过","分割
        /// 如：table1.field1,table1.field2,table2.field3
        /// </summary>
        public string FieldNames;
        /// <summary>
        /// 参与统计的sql表达式，如：sum(field1) as field1,count(field2) as field2
        /// </summary>
        public string TotalFieldStr;
        /// <summary>
        /// 每页数据量大小，0表示不分页，取得所有数据
        /// </summary>
        public int PageSize;
        /// <summary>
        /// 页序号，从1开始
        /// </summary>
        public int PageIndex;
        /// <summary>
        /// 排序类型,
        /// "":没有排序要求 
        /// "0"：主键升序 
        /// "1"：主键降序 
        /// 字符串：用户自定义排序规则,注意不要加"order by"
        /// </summary>
        public string OrderType;
        /// <summary>
        /// 查询条件,注意不要加"where"
        /// </summary>
        public string StrWhere;
        /// <summary>
        /// 左外连接字符串
        /// 注意建立关联只能在主表和从表之间,从表之间不能建立关联
        /// </summary>
        public string StrJoin;
        /// <summary>
        /// 返回数据,符合查询条件的总的条目数
        /// </summary>
        public int TotalItem;
        /// <summary>
        /// 返回数据,符合条件的总的页数
        /// </summary>
        public int TotalPage;
    }
}
