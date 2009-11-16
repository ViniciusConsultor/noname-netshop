using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace NoName.NetShop.Common
{
    public class CommDataHelper
    {
       
        /// <summary>
        /// 分页查询单个表的数据
        /// PROCEDURE GetRecordFromSingleTableByPage
        /// @tblName      nvarchar(255),        -- 表名
        /// @priKeyName	  nvarchar(50),		-- 主键列或标示列
        /// @fldNames     nvarchar(1000),       -- 字段名,多个字段通过逗号分割
        /// @PageSize     int = 0,              -- 页尺寸
        /// @PageIndex    int = 1,              -- 页码
        /// @OrderType    nvarchar(200) = '',   -- 设置排序，'':没有排序要求 0：主键升序 1：主键降序 字符串：用户自定义排序规则
        /// @strWhere     nvarchar(2000) = '',  -- 查询条件 (注意: 不要加 where)
        /// @TotalItem int output,	
        /// @TotalPage int output
        /// </summary>
        /// <param name="pageInfo">查询条件</param>
        /// <returns>
        /// 返回查询的结果为DataSet,Tables[0]为分页查询结果查询，
        /// Tables[1]为统计字段结果,当totalflds为空时，没有此数据
        /// </returns>
        public static DataSet GetDataFromSingleTableByPage(SearchPageInfo pageInfo)
        {
            string spName = "UP_GetRecordFromSingleTableByPage";
            DbCommand comm = DBFacroty.DbReader.GetStoredProcCommand(spName);
            DBFacroty.DbReader.AddInParameter(comm, "@tblName", DbType.String, pageInfo.TableName);
            DBFacroty.DbReader.AddInParameter(comm, "@priKeyName", DbType.String, pageInfo.PriKeyName);
            DBFacroty.DbReader.AddInParameter(comm, "@fldNames", DbType.String, pageInfo.FieldNames);
            DBFacroty.DbReader.AddInParameter(comm, "@PageSize", DbType.Int32, pageInfo.PageSize);
            DBFacroty.DbReader.AddInParameter(comm, "@PageIndex", DbType.Int32, pageInfo.PageIndex);
            DBFacroty.DbReader.AddInParameter(comm, "@OrderType", DbType.String, pageInfo.OrderType);
            DBFacroty.DbReader.AddInParameter(comm, "@strWhere", DbType.String, pageInfo.StrWhere);
            DBFacroty.DbReader.AddOutParameter(comm, "@TotalItem", DbType.Int32, 4);
            DBFacroty.DbReader.AddOutParameter(comm, "@TotalPage", DbType.Int32, 4);
            DataSet ds = DBFacroty.DbReader.ExecuteDataSet(comm);
            pageInfo.TotalItem = Convert.ToInt32(DBFacroty.DbReader.GetParameterValue(comm, "@TotalItem"));
            pageInfo.TotalPage = Convert.ToInt32(DBFacroty.DbReader.GetParameterValue(comm, "@TotalPage"));
            return ds;
        }

        /// <summary>
        /// 分页查询多个表的数据,主表和从表之间建立左外连接,从表之间没有关联
        /// PROCEDURE GetRecordFromTableWithSimpleLeftOuterJoinByPage
        /// @tblName      nvarchar(255),        -- 表名
        /// @priKeyName	  nvarchar(50),		-- 主键列或标示列
        /// @fldNames     nvarchar(1000),       -- 字段名,多个字段通过逗号分割
        /// @totalflds    nvarchar(500),	-- 参与统计的字段
        /// @PageSize     int = 0,              -- 页尺寸
        /// @PageIndex    int = 1,              -- 页码
        /// @OrderType    nvarchar(200) = '',   -- 设置排序，'':没有排序要求 0：主键升序 1：主键降序 字符串：用户自定义排序规则
        /// @strWhere     nvarchar(2000) = '',  -- 查询条件 (注意: 不要加 where)
        /// @strJoin	  nvarchar(1000) = '',	-- 连接表
        /// @TotalItem int output,	
        /// @TotalPage int output
        /// </summary>
        /// <param name="pageInfo">查询条件</param>
        /// <returns>
        /// 返回查询的结果为DataSet,Tables[0]为分页查询结果查询，
        /// Tables[1]为统计字段结果,当totalflds为空时，没有此数据
        /// </returns>
        public static DataSet GetDataFromMultiTablesByPage(SearchPageInfo pageInfo)
        {
            string spName = "UP_GetRecordFromTableWithSimpleLeftOuterJoinByPage";
            DbCommand comm = DBFacroty.DbReader.GetStoredProcCommand(spName);
            DBFacroty.DbReader.AddInParameter(comm, "@tblName", DbType.String, pageInfo.TableName);
            DBFacroty.DbReader.AddInParameter(comm, "@priKeyName", DbType.String, pageInfo.PriKeyName);
            DBFacroty.DbReader.AddInParameter(comm, "@fldNames", DbType.String, pageInfo.FieldNames);
            DBFacroty.DbReader.AddInParameter(comm, "@totalflds", DbType.String, pageInfo.TotalFieldStr);
            DBFacroty.DbReader.AddInParameter(comm, "@PageSize", DbType.Int32, pageInfo.PageSize);
            DBFacroty.DbReader.AddInParameter(comm, "@PageIndex", DbType.Int32, pageInfo.PageIndex);
            DBFacroty.DbReader.AddInParameter(comm, "@OrderType", DbType.String, pageInfo.OrderType);
            DBFacroty.DbReader.AddInParameter(comm, "@strWhere", DbType.String, pageInfo.StrWhere);
            DBFacroty.DbReader.AddInParameter(comm, "@strJoin", DbType.String, pageInfo.StrJoin);
            DBFacroty.DbReader.AddOutParameter(comm, "@TotalItem", DbType.Int32, 4);
            DBFacroty.DbReader.AddOutParameter(comm, "@TotalPage", DbType.Int32, 4);
            DataSet ds = DBFacroty.DbReader.ExecuteDataSet(comm);
            pageInfo.TotalItem = Convert.ToInt32(DBFacroty.DbReader.GetParameterValue(comm, "@TotalItem"));
            pageInfo.TotalPage = Convert.ToInt32(DBFacroty.DbReader.GetParameterValue(comm, "@TotalPage"));
            return ds;
        }

        /// <summary>
        /// 获得一个新的序列号，用于为各个应用能够提供一个独立的序列号
        /// </summary>
        /// <param name="appname"></param>
        /// <returns></returns>
        public static int GetNewSerialNum(string appname)
        {
            string spName = "UP_unSerialNum_GetNewSerial";
            DbCommand comm = DBFacroty.DbReader.GetStoredProcCommand(spName);
            DBFacroty.DbReader.AddInParameter(comm, "@appid", DbType.String, appname);
            DBFacroty.DbReader.AddOutParameter(comm, "@serial", DbType.Int32, 4);
            DBFacroty.DbReader.ExecuteNonQuery(comm);
            return Convert.ToInt32(DBFacroty.DbReader.GetParameterValue(comm, "@serial"));
        }
        
        /// <summary>
        /// 获得一个新的序列号，用于为各个应用能够提供一个独立的序列号，格式为：yyyyMMddAAXXXXXXXX
        /// </summary>
        /// <param name="appname"></param>
        /// <returns></returns>
        public static int GetNewSerialStr(string appname)
        {
            string spName = "UP_unSerialStr_GetNewSerial";
            DbCommand comm = DBFacroty.DbReader.GetStoredProcCommand(spName);
            DBFacroty.DbReader.AddInParameter(comm, "@appid", DbType.String, appname);
            DBFacroty.DbReader.AddOutParameter(comm, "@serial", DbType.String, 20);
            DBFacroty.DbReader.ExecuteNonQuery(comm);
            return Convert.ToInt32(DBFacroty.DbReader.GetParameterValue(comm, "@serial"));
        }    
        
        }
} 
