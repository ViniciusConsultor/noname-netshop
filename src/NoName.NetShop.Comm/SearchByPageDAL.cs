using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace NoName.NetShop.Common
{
    public class CommDataHelper:CommDataAccess
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
            DbCommand comm = DbReader.GetStoredProcCommand(spName);
            DbReader.AddInParameter(comm, "@tblName", DbType.String, pageInfo.TableName);
            DbReader.AddInParameter(comm, "@priKeyName", DbType.String, pageInfo.PriKeyName);
            DbReader.AddInParameter(comm, "@fldNames", DbType.String, pageInfo.FieldNames);
            DbReader.AddInParameter(comm, "@PageSize", DbType.Int32, pageInfo.PageSize);
            DbReader.AddInParameter(comm, "@PageIndex", DbType.Int32, pageInfo.PageIndex);
            DbReader.AddInParameter(comm, "@OrderType", DbType.String, pageInfo.OrderType);
            DbReader.AddInParameter(comm, "@strWhere", DbType.String, pageInfo.StrWhere);
            DbReader.AddOutParameter(comm, "@TotalItem", DbType.Int32,4);
            DbReader.AddOutParameter(comm, "@TotalPage", DbType.Int32,4);
            DataSet ds = DbReader.ExecuteDataSet(comm);
            pageInfo.TotalItem = Convert.ToInt32(DbReader.GetParameterValue(comm,"@TotalItem"));
            pageInfo.TotalPage = Convert.ToInt32(DbReader.GetParameterValue(comm,"@TotalPage"));
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
            DbCommand comm = DbReader.GetStoredProcCommand(spName);
            DbReader.AddInParameter(comm, "@tblName", DbType.String, pageInfo.TableName);
            DbReader.AddInParameter(comm, "@priKeyName", DbType.String, pageInfo.PriKeyName);
            DbReader.AddInParameter(comm, "@fldNames", DbType.String, pageInfo.FieldNames);
            DbReader.AddInParameter(comm, "@totalflds", DbType.String, pageInfo.TotalFieldStr);
            DbReader.AddInParameter(comm, "@PageSize", DbType.Int32, pageInfo.PageSize);
            DbReader.AddInParameter(comm, "@PageIndex", DbType.Int32, pageInfo.PageIndex);
            DbReader.AddInParameter(comm, "@OrderType", DbType.String, pageInfo.OrderType);
            DbReader.AddInParameter(comm, "@strWhere", DbType.String, pageInfo.StrWhere);
            DbReader.AddInParameter(comm, "@strJoin", DbType.String, pageInfo.StrJoin);
            DbReader.AddOutParameter(comm, "@TotalItem", DbType.Int32,4);
            DbReader.AddOutParameter(comm, "@TotalPage", DbType.Int32,4);
            DataSet ds = DbReader.ExecuteDataSet(comm);
            pageInfo.TotalItem = Convert.ToInt32(DbReader.GetParameterValue(comm, "@TotalItem"));
            pageInfo.TotalPage = Convert.ToInt32(DbReader.GetParameterValue(comm, "@TotalPage"));
            return ds;
        }

        /// <summary>
        /// ���һ���µ����кţ�����Ϊ����Ӧ���ܹ��ṩһ�����������к�
        /// </summary>
        /// <param name="appname"></param>
        /// <returns></returns>
        public static int GetNewSerialNum(string appname)
        {
            string spName = "UP_UT_Serial_GetNewSerialNum";
            DbCommand comm = DbReader.GetStoredProcCommand(spName);
            DbReader.AddInParameter(comm, "@appname", DbType.String, appname);
            DbReader.AddOutParameter(comm, "@serialNum", DbType.Int32, 4);
            DbReader.ExecuteNonQuery(comm);
            return Convert.ToInt32(DbReader.GetParameterValue(comm, "@serialNum"));
        }
    }
}
