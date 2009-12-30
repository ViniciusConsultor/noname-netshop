using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using NoName.NetShop.Product.Model;
using NoName.NetShop.Common;

namespace NoName.NetShop.Product.DAL
{
	/// <summary>
	/// ���ݷ�����SalesInfoModelDal��
	/// </summary>
	public class SalesInfoModelDal
	{

        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

		public SalesInfoModelDal()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(SalesType)+1 from pdSalesInfo";
			
			object obj = dbr.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 1;
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int SalesType,int ProductId,int RuleType)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdSalesInfo_Exists");
			dbr.AddInParameter(dbCommand, "SalesType", DbType.Byte,SalesType);
			dbr.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);
			dbr.AddInParameter(dbCommand, "RuleType", DbType.Byte,RuleType);
			int result;
			object obj = dbr.ExecuteScalar(dbCommand);
			int.TryParse(obj.ToString(),out result);
			if(result==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Add(SalesInfoModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdSalesInfo_ADD");
			dbw.AddInParameter(dbCommand, "SalesType", DbType.Byte, model.SalesType);
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			dbw.AddInParameter(dbCommand, "RuleType", DbType.Byte, model.RuleType);
			dbw.AddInParameter(dbCommand, "SortValue", DbType.Int32, model.SortValue);
			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(SalesInfoModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdSalesInfo_Update");
			dbw.AddInParameter(dbCommand, "SalesType", DbType.Byte, model.SalesType);
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			dbw.AddInParameter(dbCommand, "RuleType", DbType.Byte, model.RuleType);
			dbw.AddInParameter(dbCommand, "SortValue", DbType.Int32, model.SortValue);
			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int SalesType,int ProductId,int RuleType)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdSalesInfo_Delete");
			dbw.AddInParameter(dbCommand, "SalesType", DbType.Byte,SalesType);
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);
			dbw.AddInParameter(dbCommand, "RuleType", DbType.Byte,RuleType);

			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public SalesInfoModel GetModel(int SalesType,int ProductId,int RuleType)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdSalesInfo_GetModel");
			dbr.AddInParameter(dbCommand, "SalesType", DbType.Byte,SalesType);
			dbr.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);
			dbr.AddInParameter(dbCommand, "RuleType", DbType.Byte,RuleType);

			SalesInfoModel model=null;
			using (IDataReader dataReader = dbr.ExecuteReader(dbCommand))
			{
				if(dataReader.Read())
				{
					model=ReaderBind(dataReader);
				}
			}
			return model;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SalesType,ProductId,RuleType,SortValue ");
			strSql.Append(" FROM pdSalesInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			return dbr.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_GetRecordByPage");
			dbr.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "pdSalesInfo");
			dbr.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
			dbr.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			dbr.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			dbr.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			dbr.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			dbr.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return dbr.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		public List<SalesInfoModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SalesType,ProductId,RuleType,SortValue ");
			strSql.Append(" FROM pdSalesInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<SalesInfoModel> list = new List<SalesInfoModel>();
			
			using (IDataReader dataReader = dbr.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// ����ʵ�������
		/// </summary>
		public SalesInfoModel ReaderBind(IDataReader dataReader)
		{
			SalesInfoModel model=new SalesInfoModel();
			object ojb; 
			ojb = dataReader["SalesType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SalesType=(int)ojb;
			}
			ojb = dataReader["ProductId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductId=(int)ojb;
			}
			ojb = dataReader["RuleType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RuleType=(int)ojb;
			}
			ojb = dataReader["SortValue"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SortValue=(int)ojb;
			}
			return model;
		}

		#endregion  ��Ա����
	}
}

