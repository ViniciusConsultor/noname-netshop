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
        /// ��ҳ��ѯ������������
        /// PROCEDURE GetRecordFromSingleTableByPage
        /// @tblName      nvarchar(255),        -- ����
        /// @priKeyName	  nvarchar(50),		-- �����л��ʾ��
        /// @fldNames     nvarchar(1000),       -- �ֶ���,����ֶ�ͨ�����ŷָ�
        /// @PageSize     int = 0,              -- ҳ�ߴ�
        /// @PageIndex    int = 1,              -- ҳ��
        /// @OrderType    nvarchar(200) = '',   -- ��������'':û������Ҫ�� 0���������� 1���������� �ַ������û��Զ����������
        /// @strWhere     nvarchar(2000) = '',  -- ��ѯ���� (ע��: ��Ҫ�� where)
        /// @TotalItem int output,	
        /// @TotalPage int output
        /// </summary>
        /// <param name="pageInfo">��ѯ����</param>
        /// <returns>
        /// ���ز�ѯ�Ľ��ΪDataSet,Tables[0]Ϊ��ҳ��ѯ�����ѯ��
        /// Tables[1]Ϊͳ���ֶν��,��totalfldsΪ��ʱ��û�д�����
        /// </returns>
        public static DataSet GetDataFromSingleTableByPage(SearchPageInfo pageInfo)
        {
            string spName = "UP_GetRecordFromSingleTableByPage";
            DbCommand comm = DBFacotry.DbReader.GetStoredProcCommand(spName);
            DBFacotry.DbReader.AddInParameter(comm, "@tblName", DbType.String, pageInfo.TableName);
            DBFacotry.DbReader.AddInParameter(comm, "@priKeyName", DbType.String, pageInfo.PriKeyName);
            DBFacotry.DbReader.AddInParameter(comm, "@fldNames", DbType.String, pageInfo.FieldNames);
            DBFacotry.DbReader.AddInParameter(comm, "@PageSize", DbType.Int32, pageInfo.PageSize);
            DBFacotry.DbReader.AddInParameter(comm, "@PageIndex", DbType.Int32, pageInfo.PageIndex);
            DBFacotry.DbReader.AddInParameter(comm, "@OrderType", DbType.String, pageInfo.OrderType);
            DBFacotry.DbReader.AddInParameter(comm, "@strWhere", DbType.String, pageInfo.StrWhere);
            DBFacotry.DbReader.AddOutParameter(comm, "@TotalItem", DbType.Int32, 4);
            DBFacotry.DbReader.AddOutParameter(comm, "@TotalPage", DbType.Int32, 4);
            DataSet ds = DBFacotry.DbReader.ExecuteDataSet(comm);
            pageInfo.TotalItem = Convert.ToInt32(DBFacotry.DbReader.GetParameterValue(comm, "@TotalItem"));
            pageInfo.TotalPage = Convert.ToInt32(DBFacotry.DbReader.GetParameterValue(comm, "@TotalPage"));
            return ds;
        }

        /// <summary>
        /// ��ҳ��ѯ�����������,�����ʹӱ�֮�佨����������,�ӱ�֮��û�й���
        /// PROCEDURE GetRecordFromTableWithSimpleLeftOuterJoinByPage
        /// @tblName      nvarchar(255),        -- ����
        /// @priKeyName	  nvarchar(50),		-- �����л��ʾ��
        /// @fldNames     nvarchar(1000),       -- �ֶ���,����ֶ�ͨ�����ŷָ�
        /// @totalflds    nvarchar(500),	-- ����ͳ�Ƶ��ֶ�
        /// @PageSize     int = 0,              -- ҳ�ߴ�
        /// @PageIndex    int = 1,              -- ҳ��
        /// @OrderType    nvarchar(200) = '',   -- ��������'':û������Ҫ�� 0���������� 1���������� �ַ������û��Զ����������
        /// @strWhere     nvarchar(2000) = '',  -- ��ѯ���� (ע��: ��Ҫ�� where)
        /// @strJoin	  nvarchar(1000) = '',	-- ���ӱ�
        /// @TotalItem int output,	
        /// @TotalPage int output
        /// </summary>
        /// <param name="pageInfo">��ѯ����</param>
        /// <returns>
        /// ���ز�ѯ�Ľ��ΪDataSet,Tables[0]Ϊ��ҳ��ѯ�����ѯ��
        /// Tables[1]Ϊͳ���ֶν��,��totalfldsΪ��ʱ��û�д�����
        /// </returns>
        public static DataSet GetDataFromMultiTablesByPage(SearchPageInfo pageInfo)
        {
            string spName = "UP_GetRecordFromTableWithSimpleLeftOuterJoinByPage";
            DbCommand comm = DBFacotry.DbReader.GetStoredProcCommand(spName);
            DBFacotry.DbReader.AddInParameter(comm, "@tblName", DbType.String, pageInfo.TableName);
            DBFacotry.DbReader.AddInParameter(comm, "@priKeyName", DbType.String, pageInfo.PriKeyName);
            DBFacotry.DbReader.AddInParameter(comm, "@fldNames", DbType.String, pageInfo.FieldNames);
            DBFacotry.DbReader.AddInParameter(comm, "@totalflds", DbType.String, pageInfo.TotalFieldStr);
            DBFacotry.DbReader.AddInParameter(comm, "@PageSize", DbType.Int32, pageInfo.PageSize);
            DBFacotry.DbReader.AddInParameter(comm, "@PageIndex", DbType.Int32, pageInfo.PageIndex);
            DBFacotry.DbReader.AddInParameter(comm, "@OrderType", DbType.String, pageInfo.OrderType);
            DBFacotry.DbReader.AddInParameter(comm, "@strWhere", DbType.String, pageInfo.StrWhere);
            DBFacotry.DbReader.AddInParameter(comm, "@strJoin", DbType.String, pageInfo.StrJoin);
            DBFacotry.DbReader.AddOutParameter(comm, "@TotalItem", DbType.Int32, 4);
            DBFacotry.DbReader.AddOutParameter(comm, "@TotalPage", DbType.Int32, 4);
            DataSet ds = DBFacotry.DbReader.ExecuteDataSet(comm);
            pageInfo.TotalItem = Convert.ToInt32(DBFacotry.DbReader.GetParameterValue(comm, "@TotalItem"));
            pageInfo.TotalPage = Convert.ToInt32(DBFacotry.DbReader.GetParameterValue(comm, "@TotalPage"));
            return ds;
        }

        /// <summary>
        /// ���һ���µ����кţ�����Ϊ����Ӧ���ܹ��ṩһ�����������к�
        /// </summary>
        /// <param name="appname"></param>
        /// <returns></returns>
        public static int GetNewSerialNum(string appname)
        {
            string spName = "UP_unSerialNum_GetNewSerial";
            DbCommand comm = DBFacotry.DbReader.GetStoredProcCommand(spName);
            DBFacotry.DbReader.AddInParameter(comm, "@appid", DbType.String, appname);
            DBFacotry.DbReader.AddOutParameter(comm, "@serial", DbType.Int32, 4);
            DBFacotry.DbReader.ExecuteNonQuery(comm);
            return Convert.ToInt32(DBFacotry.DbReader.GetParameterValue(comm, "@serial"));
        }
        
        /// <summary>
        /// ���һ���µ����кţ�����Ϊ����Ӧ���ܹ��ṩһ�����������кţ���ʽΪ��yyMMddAAXXXXXX
        /// </summary>
        /// <param name="appname"></param>
        /// <returns></returns>
        public static string GetNewSerialStr(string appname)
        {
            string spName = "UP_unSerialStr_GetNewSerial";
            DbCommand comm = DBFacotry.DbReader.GetStoredProcCommand(spName);
            DBFacotry.DbReader.AddInParameter(comm, "@appid", DbType.String, appname);
            DBFacotry.DbReader.AddOutParameter(comm, "@serial", DbType.String, 20);
            DBFacotry.DbReader.ExecuteNonQuery(comm);
            return DBFacotry.DbReader.GetParameterValue(comm, "@serial").ToString();
        }    
        
        }
} 