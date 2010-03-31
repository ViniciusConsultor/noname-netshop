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
        /// ��ҳ��ѯ�����������
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
            DbCommand comm = CommDataAccess.DbReader.GetStoredProcCommand(spName);
            CommDataAccess.DbReader.AddInParameter(comm, "@tblName", DbType.String, pageInfo.TableName);
            CommDataAccess.DbReader.AddInParameter(comm, "@priKeyName", DbType.String, pageInfo.PriKeyName);
            CommDataAccess.DbReader.AddInParameter(comm, "@fldNames", DbType.String, pageInfo.FieldNames);
            CommDataAccess.DbReader.AddInParameter(comm, "@PageSize", DbType.Int32, pageInfo.PageSize);
            CommDataAccess.DbReader.AddInParameter(comm, "@PageIndex", DbType.Int32, pageInfo.PageIndex);
            CommDataAccess.DbReader.AddInParameter(comm, "@OrderType", DbType.String, pageInfo.OrderType);
            CommDataAccess.DbReader.AddInParameter(comm, "@strWhere", DbType.String, pageInfo.StrWhere);
            CommDataAccess.DbReader.AddOutParameter(comm, "@TotalItem", DbType.Int32, 4);
            CommDataAccess.DbReader.AddOutParameter(comm, "@TotalPage", DbType.Int32, 4);
            DataSet ds = CommDataAccess.DbReader.ExecuteDataSet(comm);
            pageInfo.TotalItem = Convert.ToInt32(CommDataAccess.DbReader.GetParameterValue(comm, "@TotalItem"));
            pageInfo.TotalPage = Convert.ToInt32(CommDataAccess.DbReader.GetParameterValue(comm, "@TotalPage"));
            return ds;
        }

        /// <summary>
        /// ��ҳ��ѯ����������,����ʹӱ�֮�佨����������,�ӱ�֮��û�й���
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
            DbCommand comm = CommDataAccess.DbReader.GetStoredProcCommand(spName);
            CommDataAccess.DbReader.AddInParameter(comm, "@tblName", DbType.String, pageInfo.TableName);
            CommDataAccess.DbReader.AddInParameter(comm, "@priKeyName", DbType.String, pageInfo.PriKeyName);
            CommDataAccess.DbReader.AddInParameter(comm, "@fldNames", DbType.String, pageInfo.FieldNames);
            CommDataAccess.DbReader.AddInParameter(comm, "@totalflds", DbType.String, pageInfo.TotalFieldStr);
            CommDataAccess.DbReader.AddInParameter(comm, "@PageSize", DbType.Int32, pageInfo.PageSize);
            CommDataAccess.DbReader.AddInParameter(comm, "@PageIndex", DbType.Int32, pageInfo.PageIndex);
            CommDataAccess.DbReader.AddInParameter(comm, "@OrderType", DbType.String, pageInfo.OrderType);
            CommDataAccess.DbReader.AddInParameter(comm, "@strWhere", DbType.String, pageInfo.StrWhere);
            CommDataAccess.DbReader.AddInParameter(comm, "@strJoin", DbType.String, pageInfo.StrJoin);
            CommDataAccess.DbReader.AddOutParameter(comm, "@TotalItem", DbType.Int32, 4);
            CommDataAccess.DbReader.AddOutParameter(comm, "@TotalPage", DbType.Int32, 4);
            DataSet ds = CommDataAccess.DbReader.ExecuteDataSet(comm);
            pageInfo.TotalItem = Convert.ToInt32(CommDataAccess.DbReader.GetParameterValue(comm, "@TotalItem"));
            pageInfo.TotalPage = Convert.ToInt32(CommDataAccess.DbReader.GetParameterValue(comm, "@TotalPage"));
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
            DbCommand comm = CommDataAccess.DbReader.GetStoredProcCommand(spName);

            CommDataAccess.DbReader.AddInParameter(comm, "@appid", DbType.String, appname);
            CommDataAccess.DbReader.AddOutParameter(comm, "@serial", DbType.Int32, 4);

            CommDataAccess.DbReader.ExecuteNonQuery(comm);
            return Convert.ToInt32(CommDataAccess.DbReader.GetParameterValue(comm, "@serial"));
        }

        /// <summary>
        /// ���һ���µ����кţ�����Ϊ����Ӧ���ܹ��ṩһ�����������кţ���ʽΪ��yyMMddAAXXXXXX
        /// </summary>
        /// <param name="appname"></param>
        /// <returns></returns>
        public static string GetNewSerialStr(string appname)
        {
            string spName = "UP_unSerialStr_GetNewSerial";
            DbCommand comm = CommDataAccess.DbReader.GetStoredProcCommand(spName);
            CommDataAccess.DbReader.AddInParameter(comm, "@appid", DbType.String, appname);
            CommDataAccess.DbReader.AddOutParameter(comm, "@serial", DbType.String, 20);
            CommDataAccess.DbReader.ExecuteNonQuery(comm);
            return CommDataAccess.DbReader.GetParameterValue(comm, "@serial").ToString();
        }
    }
}