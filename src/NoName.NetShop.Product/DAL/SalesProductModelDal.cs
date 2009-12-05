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
	/// ���ݷ�����SalesProductModelDal��
	/// </summary>
	public class SalesProductModelDal
    {
        private Database dbw = DBFacroty.DbWriter;
        private Database dbr = DBFacroty.DbReader;

		public SalesProductModelDal()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ProductId)+1 from pdSalesProduct";
			
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
		public bool Exists(int ProductId,int SaleType,int SiteId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdSalesProduct_Exists");
			dbr.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);
			dbr.AddInParameter(dbCommand, "SaleType", DbType.Byte,SaleType);
			dbr.AddInParameter(dbCommand, "SiteId", DbType.Int32,SiteId);
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
		public void Add(SalesProductModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdSalesProduct_ADD");
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			dbw.AddInParameter(dbCommand, "SaleType", DbType.Byte, model.SaleType);
			dbw.AddInParameter(dbCommand, "SiteId", DbType.Int32, model.SiteId);
			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(SalesProductModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdSalesProduct_Update");
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			dbw.AddInParameter(dbCommand, "SaleType", DbType.Byte, model.SaleType);
			dbw.AddInParameter(dbCommand, "SiteId", DbType.Int32, model.SiteId);
			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ProductId,int SaleType,int SiteId)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdSalesProduct_Delete");
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);
			dbw.AddInParameter(dbCommand, "SaleType", DbType.Byte,SaleType);
			dbw.AddInParameter(dbCommand, "SiteId", DbType.Int32,SiteId);

			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public SalesProductModel GetModel(int ProductId,int SaleType,int SiteId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdSalesProduct_GetModel");
			dbr.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);
			dbr.AddInParameter(dbCommand, "SaleType", DbType.Byte,SaleType);
			dbr.AddInParameter(dbCommand, "SiteId", DbType.Int32,SiteId);

			SalesProductModel model=null;
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
			strSql.Append("select ProductId,SaleType,SiteId ");
			strSql.Append(" FROM pdSalesProduct ");
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
			dbr.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "pdSalesProduct");
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
		public List<SalesProductModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ProductId,SaleType,SiteId ");
			strSql.Append(" FROM pdSalesProduct ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<SalesProductModel> list = new List<SalesProductModel>();
			
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
		public SalesProductModel ReaderBind(IDataReader dataReader)
		{
			SalesProductModel model=new SalesProductModel();
			object ojb; 
			ojb = dataReader["ProductId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductId=(int)ojb;
			}
			ojb = dataReader["SaleType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SaleType=(int)ojb;
			}
			ojb = dataReader["SiteId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SiteId=(int)ojb;
			}
			return model;
		}

		#endregion  ��Ա����
	}
}

